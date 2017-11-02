using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manning.MyPhotoAlbum;
using Manning.MyPhotoControls;

namespace MyAlbumEditor
{
    public partial class AlbumCalendar : UserControl
    {
        private AlbumManager _manager = null;
        public AlbumManager  Manager
        {
            get { return _manager; }
            set
            {
                _manager = value;
                UpdateCalendar();
            }
        }

        public AlbumCalendar()
        {
            InitializeComponent();
        }

        private void UpdateCalendar()
        {
            DateTime minDate = DateTime.MaxValue;
            DateTime maxDate = DateTime.MinValue;
            callDates.RemoveAllBoldedDates();


            if (Manager == null)
            {
                minDate = DateTime.Now;
                maxDate = DateTime.Now.AddMonths(2);
            }
            else
            {
                foreach (Photograph p in Manager.Album)
                {
                    DateTime date = p.DateTaken;
                    callDates.AddBoldedDate(date);

                    if (date < minDate) minDate = date;
                    if (date > maxDate) maxDate = date;
                }
            }

            callDates.MinDate = minDate;
            callDates.MaxDate = maxDate;
            callDates.TodayDate = minDate;
            callDates.SelectionStart = minDate;
            callDates.UpdateBoldedDates();
        }

        private void callDates_MouseDown(object sender, MouseEventArgs e)
        {
            // Ignore click if no album selected
            if (Manager == null) return;

            MonthCalendar.HitTestInfo info = callDates.HitTest(e.X, e.Y);

            if (info.HitArea == MonthCalendar.HitArea.Date)
            {
                ContextMenuStrip cms = new ContextMenuStrip();
                cms.ShowImageMargin = false;

                // See if any photos at date
                for (int i = 0; i < Manager.Album.Count; i++)
                {
                    Photograph p = Manager.Album[i];
                    if (p.DateTaken.Date == info.Time.Date)
                    {
                        ToolStripItem mnuItem = cms.Items.Add(p.FileName);
                        mnuItem.Tag = i;
                        mnuItem.Click += cmsItem_Click;
                    }
                }

                if (cms.Items.Count > 0)
                    cms.Show(callDates, e.Location);
            }
        }

        private void cmsItem_Click(object sender, EventArgs e)
        {
            ToolStripItem item = sender as ToolStripItem;

            if (item != null && item.Tag is int)
            {
                Manager.Index = (int)item.Tag;
                using (PhotoEditDialog dlg = new PhotoEditDialog(Manager))
                {
                    DateTime oldDate = Manager.Current.DateTaken;
                    if (dlg.ShowDialog() == DialogResult.OK
                        && oldDate != Manager.Current.DateTaken)
                    {
                        // DateTaken was modified
                        UpdateCalendar();
                    }
                }
            }
        }
    }
}
