using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;

namespace Manning.MyPhotoControls
{
    public partial class AlbumEditDialog : Manning.MyPhotoControls.BaseEditDialog
    {
        private AlbumManager _manager;
        private AlbumManager Manager
        {
            get { return _manager; }
        }

        public AlbumEditDialog(AlbumManager mgr)
        {
            if (mgr == null)
                throw new ArgumentException("AlbumManager cannot be null");

            InitializeComponent();

            _manager = mgr;
            ResetDialog();
        }

        private void cbxPassword_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = cbxPassword.Checked;
            txtPassword.Enabled = enabled;
            lblConfirm.Enabled = enabled;
            txtConfirm.Enabled = enabled;

            // if enabled, assign focus
            if (enabled)
                txtPassword.Focus();
        }

        protected override void ResetDialog()
        {
            PhotoAlbum album = Manager.Album;

            // Assign text boxes
            txtAlbumFile.Text = Manager.FullName;
            txtTitle.Text = album.Title;

            // Assign radio button
            switch (album.PhotoDescriptor)
            {
                case PhotoAlbum.DescriptorOption.Caption:
                    rbtnCaption.Checked = true;
                    break;
                case PhotoAlbum.DescriptorOption.DateTaken:
                    rbtnDateTaken.Checked = true;
                    break;
                case PhotoAlbum.DescriptorOption.FileName:
                    rbtnFileName.Checked = true;
                    break;
            }

            // Assign check box
            string pwd = Manager.Password;
            cbxPassword.Checked = (pwd != null && pwd.Length > 0);
            txtPassword.Text = pwd;
            txtConfirm.Text = pwd;
        }

        private bool ValidPassword()
        {
            if (cbxPassword.Checked)
                return (txtPassword.TextLength > 0 &&
                        txtConfirm.Text == txtPassword.Text);
            else
                return true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (!ValidPassword())
                {
                    DialogResult result = MessageBox.Show("The current password is blank "
                                                          + "or the two password entries "
                                                          + "do not match.",
                                                          "Invalid Password",
                                                          MessageBoxButtons.OK,
                                                          MessageBoxIcon.Information);

                    e.Cancel = true;
                }

                if (!e.Cancel)
                    SaveSettings();
            }
        }

        private void SaveSettings()
        {
            PhotoAlbum album = Manager.Album;
            if (album != null)
            {
                album.Title = txtTitle.Text;

                if (rbtnCaption.Checked)
                    album.PhotoDescriptor = PhotoAlbum.DescriptorOption.Caption;
                else if (rbtnDateTaken.Checked)
                    album.PhotoDescriptor = PhotoAlbum.DescriptorOption.DateTaken;
                else if (rbtnFileName.Checked)
                    album.PhotoDescriptor = PhotoAlbum.DescriptorOption.FileName;

                if (cbxPassword.Checked && ValidPassword())
                    Manager.Password = txtPassword.Text;
                else
                    Manager.Password = null;
            }
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            Text = txtTitle.Text + " - Album Properties";
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.TextLength > 0)
                errorProvider1.SetError(txtPassword, "");
            else
                errorProvider1.SetError(txtPassword, "The assigned password cannot be blank");
        }

        private void txtConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirm.Text == txtPassword.Text)
                errorProvider1.SetError(txtConfirm, "");
            else
                errorProvider1.SetError(txtConfirm, "The password and confirmation entries do not match");
        }
    }
}
