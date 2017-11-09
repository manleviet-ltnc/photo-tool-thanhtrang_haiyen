using System;
using System.IO;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;
using Manning.MyPhotoControls;

namespace MyAlbumExplorer
{
    internal interface IRefreshableNode
    {
        void RefreshNode();
    }
     
    internal class AlbumNode : TreeNode, IDisposable, IRefreshableNode
    {
        private string _albumPath;
        public string AlbumPath
        {
            get { return _albumPath; }
        }

        private AlbumManager _manager;
        
        public AlbumNode(string name, string albumPath) : base(name)
        {
            if (albumPath == null)
                throw new ArgumentNullException("albumPath");
            if (!File.Exists(albumPath))
                throw new ArithmeticException("albumPath is not a valid path");

            _manager = null;
            _albumPath = Path.GetFullPath(albumPath);
            this.Nodes.Add("child");
            if (AlbumStorage.IsEncrypted(albumPath))
            {
                this.ImageKey = "AlbumLock";
                this.SelectedImageKey = "AlbumLock";
            }
            else
            {
                this.ImageKey = "Album";
                this.SelectedImageKey = "AlbumSelect";
            }
        }

        public AlbumManager GetManager(bool interactive)
        {
            if (_manager == null)
            {
                string path = AlbumPath;
                string pwd = null;

                try
                {
                    if (AlbumStorage.IsEncrypted(path))
                    {
                        DialogResult result = DialogResult.None;

                        if (interactive)
                        {
                            result = MessageBox.Show("The album " + path + "is encrypted. "
                                                     + "Do you wish to open this album?",
                                                     "Encrypted Album",
                                                     MessageBoxButtons.YesNo,
                                                     MessageBoxIcon.Question,
                                                     MessageBoxDefaultButton.Button2);
                        }

                        if (result != DialogResult.Yes || !AlbumController.CheckAlbumPassword(path, ref pwd))
                            return null;
                    }
                    _manager = new AlbumManager(path, pwd);
                    this.ImageKey = "Album";
                    this.SelectedImageKey = "AlbumSelect";
                }
                catch (AlbumStorageException ex)
                {
                    if (interactive)
                        MessageBox.Show("The album could not be opened [" + ex.Message + "]");
                    this.ImageKey = "AlbumError";
                    this.SelectedImageKey = "AlbumError";
                    _manager = null;
                }
            }
            return _manager;
        }

        public PhotoAlbum GetAlbum(bool interactive)
        {
            AlbumManager mgr = GetManager(interactive);

            if (mgr == null) return null;
            else return mgr.Album;
        }

        public void RemoveChildren()
        {
            AlbumManager mgr = GetManager(false);
            if (mgr != null)
            {
                foreach (Photograph p in mgr.Album)
                    p.ReleaseImage();
            }
            Nodes.Clear();
            Nodes.Add("child");
        }

        public void Dispose()
        {
            if (_manager != null)
                _manager.Album.Dispose();
            _manager = null;
        }

        public void RefreshNode()
        {
            AlbumManager mgr = GetManager(false);
            if (mgr != null && this.Text != mgr.ShortName)
                this.Text = mgr.ShortName;
        }

        public bool RenameAlbum(string newName)
        {
            try
            {
                AlbumManager mgr = GetManager(false);
                if (mgr == null)
                    _albumPath = AlbumManager.RenameAlbum(AlbumPath, newName);
                else
                {
                    mgr.RenameAlbum(newName);
                    _albumPath = mgr.FullName;
                }
                return true;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Unable to rename album. An album with that name already exists.");
                return false;
            }
        }

        public void UpdatePath(string newPath)
        {
            if (!File.Exists(newPath))
                throw new ArgumentException("newPath must be valid path");

            AlbumManager mgr = GetManager(false);
            if (mgr != null)
            {
                _albumPath = mgr.FullName;
                Text = mgr.ShortName;
            }
            else
            {
                _albumPath = newPath;
                Text = Path.GetFileNameWithoutExtension(newPath);
            }
        }
    }
}
