namespace MyAlbumExplorer
{
    partial class ExplorerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.atvAlbumTree = new MyAlbumExplorer.AlbumTreeView();
            this.imageListSmall = new System.Windows.Forms.ImageList(this.components);
            this.lvAlbumList = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.spbxPhoto = new Manning.MyPhotoControls.ScrollablePictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditLabel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spbxPhoto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.atvAlbumTree);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvAlbumList);
            this.splitContainer1.Panel2.Controls.Add(this.spbxPhoto);
            this.splitContainer1.Size = new System.Drawing.Size(434, 237);
            this.splitContainer1.SplitterDistance = 144;
            this.splitContainer1.TabIndex = 0;
            // 
            // atvAlbumTree
            // 
            this.atvAlbumTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.atvAlbumTree.HideSelection = false;
            this.atvAlbumTree.ImageIndex = 0;
            this.atvAlbumTree.ImageList = this.imageListSmall;
            this.atvAlbumTree.LabelEdit = true;
            this.atvAlbumTree.Location = new System.Drawing.Point(0, 0);
            this.atvAlbumTree.Name = "atvAlbumTree";
            this.atvAlbumTree.SelectedImageIndex = 0;
            this.atvAlbumTree.Size = new System.Drawing.Size(144, 237);
            this.atvAlbumTree.TabIndex = 0;
            this.atvAlbumTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.atvAlbumTree_BeforeSelect);
            this.atvAlbumTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.atvAlbumTree_AfterSelect);
            // 
            // imageListSmall
            // 
            this.imageListSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSmall.ImageStream")));
            this.imageListSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListSmall.Images.SetKeyName(0, "Photo");
            this.imageListSmall.Images.SetKeyName(1, "Album");
            this.imageListSmall.Images.SetKeyName(2, "AlbumSelect");
            this.imageListSmall.Images.SetKeyName(3, "AlbumError");
            this.imageListSmall.Images.SetKeyName(4, "AlbumLock");
            this.imageListSmall.Images.SetKeyName(5, "AlbumDir");
            // 
            // lvAlbumList
            // 
            this.lvAlbumList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAlbumList.FullRowSelect = true;
            this.lvAlbumList.LabelEdit = true;
            this.lvAlbumList.LargeImageList = this.imageList1;
            this.lvAlbumList.Location = new System.Drawing.Point(0, 0);
            this.lvAlbumList.Name = "lvAlbumList";
            this.lvAlbumList.Size = new System.Drawing.Size(286, 237);
            this.lvAlbumList.SmallImageList = this.imageListSmall;
            this.lvAlbumList.TabIndex = 1;
            this.lvAlbumList.UseCompatibleStateImageBehavior = false;
            this.lvAlbumList.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvAlbumList_AfterLabelEdit);
            this.lvAlbumList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAlbumList_ColumnClick);
            this.lvAlbumList.ItemActivate += new System.EventHandler(this.lvAlbumList_ItemActivate);
            this.lvAlbumList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvAlbumList_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Photo");
            this.imageList1.Images.SetKeyName(1, "Album");
            this.imageList1.Images.SetKeyName(2, "AlbumSelect");
            this.imageList1.Images.SetKeyName(3, "AlbumError");
            this.imageList1.Images.SetKeyName(4, "AlbumLock");
            this.imageList1.Images.SetKeyName(5, "AlbumDir");
            // 
            // spbxPhoto
            // 
            this.spbxPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spbxPhoto.Image = null;
            this.spbxPhoto.Location = new System.Drawing.Point(0, 0);
            this.spbxPhoto.Name = "spbxPhoto";
            this.spbxPhoto.Size = new System.Drawing.Size(286, 237);
            this.spbxPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.spbxPhoto.TabIndex = 0;
            this.spbxPhoto.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(92, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditLabel,
            this.mnuEditProperties});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.DropDownOpening += new System.EventHandler(this.mnuEdit_DropDownOpening);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewLarge,
            this.mnuViewSmall,
            this.mnuViewList,
            this.mnuViewDetails,
            this.mnuViewTiles});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "&View";
            this.mnuView.DropDownOpening += new System.EventHandler(this.mnuView_DropDownOpening);
            this.mnuView.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuView_DropDownItemClicked);
            // 
            // mnuViewLarge
            // 
            this.mnuViewLarge.Name = "mnuViewLarge";
            this.mnuViewLarge.Size = new System.Drawing.Size(134, 22);
            this.mnuViewLarge.Tag = "LargeIcon";
            this.mnuViewLarge.Text = "&Large Icons";
            // 
            // mnuViewSmall
            // 
            this.mnuViewSmall.Name = "mnuViewSmall";
            this.mnuViewSmall.Size = new System.Drawing.Size(134, 22);
            this.mnuViewSmall.Tag = "SmallIcon";
            this.mnuViewSmall.Text = "S&mall Icons";
            // 
            // mnuViewList
            // 
            this.mnuViewList.Name = "mnuViewList";
            this.mnuViewList.Size = new System.Drawing.Size(134, 22);
            this.mnuViewList.Tag = "List";
            this.mnuViewList.Text = "&List";
            // 
            // mnuViewDetails
            // 
            this.mnuViewDetails.Name = "mnuViewDetails";
            this.mnuViewDetails.Size = new System.Drawing.Size(134, 22);
            this.mnuViewDetails.Tag = "Details";
            this.mnuViewDetails.Text = "&Details";
            // 
            // mnuViewTiles
            // 
            this.mnuViewTiles.Name = "mnuViewTiles";
            this.mnuViewTiles.Size = new System.Drawing.Size(134, 22);
            this.mnuViewTiles.Tag = "Tiles";
            this.mnuViewTiles.Text = "&Tiles";
            // 
            // mnuEditProperties
            // 
            this.mnuEditProperties.Name = "mnuEditProperties";
            this.mnuEditProperties.Size = new System.Drawing.Size(152, 22);
            this.mnuEditProperties.Text = "&Properties";
            this.mnuEditProperties.Click += new System.EventHandler(this.mnuEditProperties_Click);
            // 
            // mnuEditLabel
            // 
            this.mnuEditLabel.Name = "mnuEditLabel";
            this.mnuEditLabel.Size = new System.Drawing.Size(152, 22);
            this.mnuEditLabel.Text = "&Label";
            this.mnuEditLabel.Click += new System.EventHandler(this.mnuEditLabel_Click);
            // 
            // ExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 261);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ExplorerForm";
            this.Text = "Album Explorer";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spbxPhoto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ImageList imageListSmall;
        private System.Windows.Forms.ImageList imageList1;
        private AlbumTreeView atvAlbumTree;
        private Manning.MyPhotoControls.ScrollablePictureBox spbxPhoto;
        private System.Windows.Forms.ListView lvAlbumList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuViewLarge;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSmall;
        private System.Windows.Forms.ToolStripMenuItem mnuViewList;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuViewTiles;
        private System.Windows.Forms.ToolStripMenuItem mnuEditProperties;
        private System.Windows.Forms.ToolStripMenuItem mnuEditLabel;
    }
}

