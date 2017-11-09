using System;
using System.IO;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;

namespace MyAlbumExplorer
{
    internal class PhotoNode : TreeNode, IRefreshableNode
    {
        private Photograph _photo;
        public Photograph Photograph
        {
            get { return _photo; }
        }

        public PhotoNode(Photograph photo) : base ()
        {
            if (photo == null)
                throw new ArgumentNullException("photo");
            _photo = photo;
            Text = photo.Caption;
            ImageKey = "Photo";
            SelectedImageKey = "Photo";
        }

        public void RefreshNode()
        {
            Text = Photograph.Caption;
        }
    }
}
