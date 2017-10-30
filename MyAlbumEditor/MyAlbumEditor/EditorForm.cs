using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;
using Manning.MyPhotoControls;
using System.IO;

namespace MyAlbumEditor
{
    public partial class EditorForm : Form
    {
        private AlbumManager _manager;
        private AlbumManager Manager
        {
            get { return _manager; }
            set { _manager = value; }
        }
        public EditorForm()
        {
            InitializeComponent();
            Manager = new AlbumManager();
        }
        private bool CloseAlbum()
        {
            if (Manager != null)
            {
                DialogResult result = AlbumController.AskForSave(Manager);
                switch (result)
                {
                    case DialogResult.Yes:
                        Manager.Save();
                        break;
                    case DialogResult.Cancel:
                        return true;
                }
                Manager.Album.Dispose();
                Manager = null;
            }
            return false;
        }

        protected override void OnLoad(EventArgs e)
        {
            cmbAlbums.DataSource = Directory.GetFiles(AlbumManager.DefaultPath, "*.abm");
            OpenAlbum(cmbAlbums.Text);
            base.OnLoad(e);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = CloseAlbum();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenAlbum(string path)
        {
            string password = null;
            if (path != null && path.Length >0
                && AlbumController.CheckAlbumPassword(path, ref password))
            {
                if (CloseAlbum())
                    return; //cancel open
                try
                {
                    Manager = new AlbumManager(path, password);
                }
                catch (AlbumStorageException)
                {
                    Manager = null;
                }
            }
            DisplayAlbum();
            EnablePhotoButtons();
        }
        private void DisplayAlbum()
        {
            if (Manager == null)
            {
                grpPhotos.Enabled = false;
                btnAlbumProps.Enabled = false;
                Text = " The selected album could be not opened";
                lstPhotos.BackColor = SystemColors.Control;
                lstPhotos.Items.Clear();
            }
            else
            {
                grpPhotos.Enabled = true;
                btnAlbumProps.Enabled = true;
                Text = " Album" + Manager.ShortName;
                lstPhotos.BackColor = SystemColors.Window;

                lstPhotos.FormatString = Manager.Album.GetDescriptorFormat();
                if (Manager.Album.PhotoDescriptor == PhotoAlbum.DescriptorOption.DateTaken)
                    lstPhotos.FormatString = "dMMMM dd,yyyy ";

                lstPhotos.BeginUpdate();
                lstPhotos.Items.Clear();
                foreach (Photograph p in Manager.Album)
                    lstPhotos.Items.Add(p);
                lstPhotos.EndUpdate();
            }
        }

        private void btnAlbumProps_Click(object sender, EventArgs e)
        {
            if (Manager == null)
                return;
            using (AlbumEditDialog dlg = new AlbumEditDialog(Manager))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    DisplayAlbum();
            }
        }

        private void btnPhotoProps_Click(object sender, EventArgs e)
        {
            if (Manager == null || lstPhotos.SelectedIndex < 0)
                return;
            Manager.Index = lstPhotos.SelectedIndex;
            using (PhotoEditDialog dlg = new PhotoEditDialog(Manager))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    DisplayAlbum();
            }
        }

        private void lstPhotos_DoubleClick(object sender, EventArgs e)
        {
            btnPhotoProps.PerformClick();
        }

        private void lstPhotos_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnablePhotoButtons();
        }
        private void EnablePhotoButtons()
        {
            int selCount = lstPhotos.SelectedIndices.Count;
            bool someSelected = (selCount > 0);

            if (someSelected)
            {
                bool firstSelected = lstPhotos.GetSelected(0);
                bool lastSelected = lstPhotos.GetSelected(lstPhotos.Items.Count - 1);

                btnMoveUp.Enabled = !firstSelected;
                btnMoveDown.Enabled = !lastSelected;

            }
            else
            {
                btnMoveUp.Enabled = false;
                btnMoveDown.Enabled = false;
            }
            btnRemove.Enabled = someSelected;
            btnPhotoProps.Enabled = (selCount == 1);
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection indices = lstPhotos.SelectedIndices;
            int count = indices.Count;
            int[] newIndices = new int[count];

            //Move each selection up
            for (int i = 0; i < count; i++)
            {
                int x = indices[i];
                Manager.MoveItemBackward(x);
                newIndices[i] = x - 1;
            }
            ReselectMovedItems(newIndices);
        }
        private void ReselectMovedItems(int[] newIndices)
        {
            DisplayAlbum();

            //Reselect moved items 
            foreach (int x in newIndices)
                lstPhotos.SetSelected(x, true);
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection indices = lstPhotos.SelectedIndices;
            int count = indices.Count;
            int[] newIndices = new int[count];

            // Move each selection down 
            for (int i = count - 1; i >= 0; i--)
            {
                int x = indices[i];
                Manager.MoveItemForward(x);
                newIndices[i] = x + 1;
            }
            ReselectMovedItems(newIndices);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListBox.SelectedIndexCollection indices = lstPhotos.SelectedIndices;
            int count = indices.Count;

            string msg;
            if (count == 1)
                msg = "Do you really want to remove the selected photograpth ";
            else
                msg = string.Format("Do you really want to remove the {0} selected photograpths?", count);
            DialogResult result = MessageBox.Show(msg, "Remove Photos?",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                for (int i = count - 1; i >= 0; i--)
                    Manager.Album.RemoveAt(indices[i]);

                DisplayAlbum();
            }
        }

        private void cmbAlbums_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string path = cmbAlbums.Text;

            //Don't reopen the existing album
            if (Manager != null && path == Manager.FullName)
                return;

            //Open the new album
            OpenAlbum(path);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Select an album file directory to add to the dialog.";
                dlg.SelectedPath = AlbumManager.DefaultPath;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (CloseAlbum())
                        return; //cancel browse

                    cmbAlbums.Text = null;
                    cmbAlbums.DataSource = Directory.GetFiles(dlg.SelectedPath, "*.abm");

                    OpenAlbum(cmbAlbums.Text);
                }
            }
        }
    }
}
