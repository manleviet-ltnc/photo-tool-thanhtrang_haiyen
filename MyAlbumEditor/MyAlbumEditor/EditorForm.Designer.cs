namespace MyAlbumEditor
{
    partial class EditorForm
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
            this.grpAlbums = new System.Windows.Forms.GroupBox();
            this.btnAlbumProps = new System.Windows.Forms.Button();
            this.grpPhotos = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnPhotoProps = new System.Windows.Forms.Button();
            this.lstPhotos = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbAlbums = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.grpAlbums.SuspendLayout();
            this.grpPhotos.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAlbums
            // 
            this.grpAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAlbums.Controls.Add(this.btnBrowse);
            this.grpAlbums.Controls.Add(this.cmbAlbums);
            this.grpAlbums.Controls.Add(this.btnAlbumProps);
            this.grpAlbums.Location = new System.Drawing.Point(13, 13);
            this.grpAlbums.Name = "grpAlbums";
            this.grpAlbums.Size = new System.Drawing.Size(359, 57);
            this.grpAlbums.TabIndex = 0;
            this.grpAlbums.TabStop = false;
            this.grpAlbums.Text = "&Albums";
            // 
            // btnAlbumProps
            // 
            this.btnAlbumProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAlbumProps.Enabled = false;
            this.btnAlbumProps.Location = new System.Drawing.Point(273, 19);
            this.btnAlbumProps.Name = "btnAlbumProps";
            this.btnAlbumProps.Size = new System.Drawing.Size(75, 23);
            this.btnAlbumProps.TabIndex = 1;
            this.btnAlbumProps.Text = "Propertie&s";
            this.btnAlbumProps.UseVisualStyleBackColor = true;
            this.btnAlbumProps.Click += new System.EventHandler(this.btnAlbumProps_Click);
            // 
            // grpPhotos
            // 
            this.grpPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpPhotos.Controls.Add(this.btnRemove);
            this.grpPhotos.Controls.Add(this.btnMoveDown);
            this.grpPhotos.Controls.Add(this.btnMoveUp);
            this.grpPhotos.Controls.Add(this.btnPhotoProps);
            this.grpPhotos.Controls.Add(this.lstPhotos);
            this.grpPhotos.Location = new System.Drawing.Point(13, 76);
            this.grpPhotos.Name = "grpPhotos";
            this.grpPhotos.Size = new System.Drawing.Size(359, 144);
            this.grpPhotos.TabIndex = 1;
            this.grpPhotos.TabStop = false;
            this.grpPhotos.Text = "&Photographs";
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(273, 77);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveDown.Location = new System.Drawing.Point(273, 48);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveDown.TabIndex = 3;
            this.btnMoveDown.Text = "Move &Down";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMoveUp.Location = new System.Drawing.Point(273, 19);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveUp.TabIndex = 2;
            this.btnMoveUp.Text = "Move &Up";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnPhotoProps
            // 
            this.btnPhotoProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhotoProps.Location = new System.Drawing.Point(273, 104);
            this.btnPhotoProps.Name = "btnPhotoProps";
            this.btnPhotoProps.Size = new System.Drawing.Size(75, 23);
            this.btnPhotoProps.TabIndex = 1;
            this.btnPhotoProps.Text = "Properti&es";
            this.btnPhotoProps.UseVisualStyleBackColor = true;
            this.btnPhotoProps.Click += new System.EventHandler(this.btnPhotoProps_Click);
            // 
            // lstPhotos
            // 
            this.lstPhotos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstPhotos.FormattingEnabled = true;
            this.lstPhotos.HorizontalScrollbar = true;
            this.lstPhotos.Location = new System.Drawing.Point(6, 19);
            this.lstPhotos.Name = "lstPhotos";
            this.lstPhotos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstPhotos.Size = new System.Drawing.Size(261, 108);
            this.lstPhotos.TabIndex = 0;
            this.lstPhotos.SelectedIndexChanged += new System.EventHandler(this.lstPhotos_SelectedIndexChanged);
            this.lstPhotos.DoubleClick += new System.EventHandler(this.lstPhotos_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point(154, 226);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbAlbums
            // 
            this.cmbAlbums.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAlbums.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAlbums.DropDownWidth = 400;
            this.cmbAlbums.FormattingEnabled = true;
            this.cmbAlbums.Location = new System.Drawing.Point(6, 20);
            this.cmbAlbums.Name = "cmbAlbums";
            this.cmbAlbums.Size = new System.Drawing.Size(180, 21);
            this.cmbAlbums.TabIndex = 2;
            this.cmbAlbums.SelectionChangeCommitted += new System.EventHandler(this.cmbAlbums_SelectionChangeCommitted);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(192, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 3;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // EditorForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpPhotos);
            this.Controls.Add(this.grpAlbums);
            this.Name = "EditorForm";
            this.Text = "MyAlbumEditor";
            this.grpAlbums.ResumeLayout(false);
            this.grpPhotos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAlbums;
        private System.Windows.Forms.GroupBox grpPhotos;
        private System.Windows.Forms.ListBox lstPhotos;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAlbumProps;
        private System.Windows.Forms.Button btnPhotoProps;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.ComboBox cmbAlbums;
        private System.Windows.Forms.Button btnBrowse;
    }
}

