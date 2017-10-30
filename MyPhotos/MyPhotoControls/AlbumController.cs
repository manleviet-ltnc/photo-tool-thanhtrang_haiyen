using System;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;

namespace Manning.MyPhotoControls
{
    public static class AlbumController
    {
        public static bool OpenAlbumDialog(ref string path, ref string password)
        {
            // Allow user to select a new album
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Album";
                dlg.Filter = "Album files (*.abm)|*.abm"
                             + "|All files (*.*)|*.*";
                dlg.InitialDirectory = AlbumManager.DefaultPath;
                dlg.RestoreDirectory = true;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.FileName;
                    return CheckAlbumPassword(path, ref password);
                }
            }
            return false;
        }

        public static bool CheckAlbumPassword(string path, ref string password)
        {
            // Get password if encrypted
            if (AlbumStorage.IsEncrypted(path))
            {
                using (AlbumPasswordDialog pwdDlg = new AlbumPasswordDialog())
                {
                    pwdDlg.Album = path;
                    if (pwdDlg.ShowDialog() != DialogResult.OK)
                        return false;

                    password = pwdDlg.Password;
                }
            }
            return true;
        }

        public static bool SaveAlbumDialog(ref string path)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Save Album";
                dlg.DefaultExt = "abm";
                dlg.Filter = "Album files (*.abm)|*.abm"
                             + "|All files (*.*)|*.*";
                dlg.InitialDirectory = AlbumManager.DefaultPath;
                dlg.RestoreDirectory = true;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    path = dlg.FileName;
                    return true;
                }
            }
            return false;
        }

        public static DialogResult AskForSave(AlbumManager manager)
        {
            if (manager.Album.HasChanged)
            {
                string msg;
                if (string.IsNullOrEmpty(manager.FullName))
                    msg = "Do you wish to save your changes?";
                else
                    msg = String.Format("Do you wish to save your changes to \n{0}?", manager.ShortName);

                DialogResult result = MessageBox.Show(msg, "Save Changes?",
                                                      MessageBoxButtons.YesNoCancel,
                                                      MessageBoxIcon.Question);
                return result;
            }
            return DialogResult.No;
        }
    }
}
