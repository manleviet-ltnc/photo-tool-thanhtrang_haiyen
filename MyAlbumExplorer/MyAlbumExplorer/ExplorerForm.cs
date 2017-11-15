using System;
using System.IO;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;
using Manning.MyPhotoControls;

namespace MyAlbumExplorer
{
    public partial class ExplorerForm : Form
    {
        private Photograph _currentPhoto = null;
        private bool _showingAlbums = true;
        private bool ShowingAlbums
        {
            get { return _showingAlbums; }
            set { _showingAlbums = value; }
        }

        private MyListViewComparer _comparer;
        private MyListViewComparer MyComparer
        {
            get { return _comparer; }
        }

        public ExplorerForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Assign title bar
            Version v = new Version(Application.ProductVersion);

            this.Text = string.Format("MyAlbumExplorer {0:#}.{1:#}",
                                      v.Major, v.Minor);

            atvAlbumTree.Nodes.Clear();
            atvAlbumTree.AddAlbumDirectory("Default Albums", AlbumManager.DefaultPath);

            _comparer = new MyListViewComparer(lvAlbumList);
            lvAlbumList.ListViewItemSorter = MyComparer;

            base.OnLoad(e);
        }

        private void atvAlbumTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            if (_currentPhoto != null)
            {
                spbxPhoto.Image = null;
                _currentPhoto.ReleaseImage();
                _currentPhoto = null;
            }
        }

        private void atvAlbumTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                bool oldShowingAlbums = ShowingAlbums;
                lvAlbumList.BeginUpdate();
                lvAlbumList.Clear();

                lvAlbumList.Sorting = SortOrder.None;
                if (e.Node is AlbumDirectoryNode)
                    ListAlbumData(e.Node as AlbumDirectoryNode);
                else if (e.Node is AlbumNode)
                    ListPhotoData(e.Node as AlbumNode);
                else if (e.Node is PhotoNode)
                    DisplayPhoto(e.Node as PhotoNode);
                else
                    throw new ArgumentException("Unrecognized node");

                if (lvAlbumList.Visible && ShowingAlbums != oldShowingAlbums)
                {
                    //Solumns changed, so reset sorting
                    MyComparer.SortColumn = 0;
                    lvAlbumList.Sorting = SortOrder.Ascending;
                }
            }
            finally
            {
                lvAlbumList.EndUpdate();
            }
        }

        private void DisplayPhoto(PhotoNode photoNode)
        {
            spbxPhoto.Visible = true;
            lvAlbumList.Visible = false;
            _currentPhoto = photoNode.Photograph;
            spbxPhoto.Image = _currentPhoto.Image;
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mnuView_DropDownOpening(object sender, EventArgs e)
        {
            View v = lvAlbumList.View;
            mnuViewLarge.Checked = (v == View.LargeIcon);
            mnuViewSmall.Checked = (v == View.SmallIcon);
            mnuViewList.Checked = (v == View.List);
            mnuViewDetails.Checked = (v == View.Details);
            mnuViewTiles.Checked = (v == View.Tile);
        }

        private void mnuView_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            string enumVal = item.Tag as string;
            if (enumVal != null)
            {
                lvAlbumList.View = (View)Enum.Parse(typeof(View), enumVal);
            }
        }
        private void ListAlbumData(AlbumDirectoryNode dirNode)
        {
            //Show album in list view
            spbxPhoto.Visible = false;
            lvAlbumList.Visible = true;
            ShowingAlbums = true;

            //Presume list cleared, so recreate colums
            lvAlbumList.Columns.Add("Name", 80);
            lvAlbumList.Columns.Add("Tittle", 120);
            lvAlbumList.Columns.Add("Size", 40, HorizontalAlignment.Center);

            //Add them albums for given node
            foreach (AlbumNode aNode in dirNode.AlbumNodes)
            {
                string text = Path.GetFileNameWithoutExtension(aNode.AlbumPath);
                ListViewItem item = lvAlbumList.Items.Add(text);

                AlbumManager mgr = aNode.GetManager(false);
                item.ImageKey = aNode.ImageKey;
                AssignSubItems(item, aNode.AlbumPath, mgr);
            }
        }
        private void AssignSubItems(ListViewItem item, string path, AlbumManager mgr)
        {
            item.SubItems.Clear();
            item.Text = Path.GetFileNameWithoutExtension(path);

            ListViewItem.ListViewSubItem subitem;
            if (mgr == null)
            {
                item.Tag = path;
                item.SubItems.Add("");
                subitem = item.SubItems.Add("?");
                subitem.Tag = 999;
            }
            else
            {
                PhotoAlbum album = mgr.Album;
                int count = album.Count;

                item.Tag = mgr;
                item.SubItems.Add(album.Title);
                subitem = item.SubItems.Add(count.ToString());
                subitem.Tag = count;
            }
        }

        private void ListPhotoData(AlbumNode albumNode)
        {
            //Show photographs in list view
            spbxPhoto.Visible = false;
            lvAlbumList.Visible = true;
            ShowingAlbums = false;

            //Presume contents cleared, so recreate columns
            lvAlbumList.Columns.Add("Caption", 120);
            lvAlbumList.Columns.Add("Photographer", 100);
            lvAlbumList.Columns.Add("Taken", 80, HorizontalAlignment.Center);
            lvAlbumList.Columns.Add("File Name", 200);

            //Add the photos for given node
            AlbumManager mgr = albumNode.GetManager(true);
            if (mgr != null)
            {
                foreach (Photograph p in mgr.Album)
                {
                    ListViewItem item = new ListViewItem(p.Caption, "Photo");
                    AssignSubItems(item, p);
                    lvAlbumList.Items.Add(item);
                }
            }
        }
        private void AssignSubItems(ListViewItem item, Photograph photo)
        {
            item.SubItems.Clear();
            item.Text = photo.Caption;
            item.Tag = photo;
            ListViewItem.ListViewSubItem subitem;
            item.SubItems.Add(photo.Photographer);
            subitem = item.SubItems.Add(photo.DateTaken.ToString("dd MMM yyyy"));
            subitem.Tag = photo.DateTaken;
            item.SubItems.Add(photo.FileName);
        }

        private void lvAlbumList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == MyComparer.SortColumn)
            {
                //Switch the sort order for this column
                if (lvAlbumList.Sorting == SortOrder.Ascending)
                    lvAlbumList.Sorting = SortOrder.Descending;
                else
                    lvAlbumList.Sorting = SortOrder.Ascending;
            }
            else
            {
                //Define new sort column and order
                MyComparer.SortColumn = e.Column;
                lvAlbumList.Sorting = SortOrder.Ascending;
            }
            lvAlbumList.Sort();
        }

        private void mnuEditProperties_Click(object sender, EventArgs e)
        {
            if (lvAlbumList.Focused)
                DisplayListItemProperties();
            else
                DisplayTreeNodeProperties();

        }

        private void DisplayTreeNodeProperties()
        {
            TreeNode node = atvAlbumTree.SelectedNode;
            if (node is AlbumNode)
            {
                AlbumNode aNode = (AlbumNode)node;
                AlbumManager mgr = aNode.GetManager(true);
                if (mgr != null)
                    DisplayAlbumProperties(mgr);
            }
            else if (node is PhotoNode)
            {
                PhotoNode pNode = (PhotoNode)node;
                DisplayPhotoProperties(pNode.Photograph);
            }
            atvAlbumTree.SaveAlbumChanges();
            atvAlbumTree.RefreshNode();
        }

        private void DisplayListItemProperties()
        {
            if (lvAlbumList.SelectedItems.Count == 1)
            {
                ListViewItem item = lvAlbumList.SelectedItems[0];
                if (item.Tag is AlbumManager)
                {
                    AlbumManager mgr = (AlbumManager)item.Tag;
                    DisplayAlbumProperties(mgr);
                    AssignSubItems(item, mgr.FullName, mgr);

                    if (mgr.Album.HasChanged)
                        mgr.Save();
                }
                else if (item.Tag is Photograph)
                {
                    Photograph photo = (Photograph)item.Tag;
                    DisplayPhotoProperties(photo);

                    if (photo.HasChanged)
                    {
                        AssignSubItems(item, photo);
                        atvAlbumTree.SaveAlbumChanges();
                    }
                }
                else
                    MessageBox.Show("The properties for this item cannot be displayed.");
            }

           
        }
        private void DisplayAlbumProperties (AlbumManager mgr)
        {
            using (AlbumEditDialog dlg = new AlbumEditDialog(mgr))
            {
                dlg.ShowDialog();
            }
        }
        private void DisplayPhotoProperties(Photograph photo)
        {
            using (PhotoEditDialog dlg = new PhotoEditDialog(photo))
            {
                dlg.ShowDialog();
            }
        }

        private void mnuEdit_DropDownOpening(object sender, EventArgs e)
        {
            mnuEditLabel.Enabled = true;
            if (lvAlbumList.Focused)
                mnuEditLabel.Text = "Captio&n";
            else if (atvAlbumTree.Focused)
                mnuEditLabel.Text = "&Name";
            else
                mnuEditLabel.Enabled = false;
        }

        private void mnuEditLabel_Click(object sender, EventArgs e)
        {
            if (lvAlbumList.Focused)
            {
                if (lvAlbumList.FocusedItem != null)
                    lvAlbumList.FocusedItem.BeginEdit();
            }
            else if (atvAlbumTree.Focused)
            {
                if (atvAlbumTree.SelectedNode != null)
                    atvAlbumTree.SelectedNode.BeginEdit();
            }
        }

        private void lvAlbumList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (lvAlbumList.FocusedItem != null)
                    lvAlbumList.FocusedItem.BeginEdit();
                e.Handled = true;
            }
        }

        private void lvAlbumList_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (String.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            ListViewItem item = lvAlbumList.Items[e.Item];

            if (item.Tag is Photograph)
            {
                Photograph photo = (Photograph)item.Tag;
                photo.Caption = e.Label;
                if (photo.HasChanged)
                    atvAlbumTree.SaveAlbumChanges();
            }
            else
            {
                RenameAlbum(item, e.Label);
            }
        }

        private void RenameAlbum(ListViewItem item, string newName)
        {
            try
            {
                string oldPath = null;
                string newPath = null;
                if (item.Tag is AlbumManager)
                {
                    AlbumManager mgr = (AlbumManager)item.Tag;
                    oldPath = mgr.FullName;
                    mgr.RenameAlbum(newName);
                    newPath = mgr.FullName;
                }
                else if (item.Tag is string)
                {
                    oldPath = (string)item.Tag;
                    newPath = AlbumManager.RenameAlbum(oldPath, newName);
                    item.Tag = newPath;
                }
                if (oldPath != null)
                {
                    AlbumNode aNode = atvAlbumTree.FindAlbuNode(oldPath);
                    if (aNode != null)
                        aNode.UpdatePath(newPath);
                }
            }
            catch (ArgumentException aex)
            {
                MessageBox.Show("unable to rename album. [" + aex.Message + "]");
            }
        }

        private void lvAlbumList_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem item = lvAlbumList.SelectedItems[0];
            TreeNode node = null;
            if (ShowingAlbums)
            {
                string albumPath;
                AlbumManager mgr = item.Tag as AlbumManager;
                if (mgr == null)
                    albumPath = item.Tag as string;
                else
                    albumPath = mgr.FullName;
                if (albumPath != null)
                    node = atvAlbumTree.FindAlbuNode(albumPath);
            }
            else
            {
                Photograph photo = item.Tag as Photograph;
                if (photo != null)
                    node = atvAlbumTree.FindPhotoNode(photo);
            }
            if (node != null)
                atvAlbumTree.SelectedNode = node;
        }
    }

}
