using System;
using System.IO;
using System.Windows.Forms;

namespace MyAlbumExplorer
{
    internal class AlbumDirectoryNode : TreeNode
    {
        private string _albumDir;
        public string AlbumDirectory
        {
            get { return _albumDir; }
        }

        public string[] AlbumFiles
        {
            get { return Directory.GetFiles(AlbumDirectory, "*.abm"); }
        }

        private AlbumNode[] _albumNodes = null;
        public AlbumNode[] AlbumNodes
        {
            get
            {
                CreateAlbumNodes();
                return _albumNodes;
            }
        }

        public AlbumDirectoryNode(string name, string albumDir) : base(name)
        {
            if (albumDir == null)
                throw new ArgumentNullException("albumDir");
            if (!Directory.Exists(albumDir))
                throw new ArgumentException("albumDir is not valid directory");

            _albumDir = albumDir;
            this.Nodes.Add("child");
            this.ImageKey = "AlbumDir";
            this.SelectedImageKey = "AlbumDir";
        }

        public void CreateAlbumNodes()
        {
            string[] files = AlbumFiles;
            int count = files.Length;
            if (_albumNodes == null || _albumNodes.Length != count)
            {
                Nodes.Clear();
                _albumNodes = new AlbumNode[count];
                for (int i = 0; i < count; i++)
                {
                    // Add album node
                    string s = files[i];
                    string name = Path.GetFileNameWithoutExtension(s);
                    _albumNodes[i] = new AlbumNode(name, s);
                }
                Nodes.AddRange(_albumNodes);
            }
        }
    }
}
