using System;
using System.Collections;
using System.Windows.Forms;

namespace MyAlbumExplorer
{
    internal class MyListViewComparer : IComparer
    {
        //ListView to sort
        private ListView _listView;
        private ListView ListView
        {
            get { return _listView; }
        }

        //Track the current sorting column
        private int _sortColumn;
        public int SortColumn
        {
            get { return _sortColumn; }
            set { _sortColumn = value; }
        }

        public MyListViewComparer(ListView lv)
        {
            _listView = lv;
            _sortColumn = 0;
        }

        public int Compare(object x, object y)
        {
            //Throw exception if not list items
            ListViewItem item1 = (ListViewItem)x;
            ListViewItem item2 = (ListViewItem)y;

            //Swap items if descending oder
            if (ListView.Sorting == SortOrder.Descending)
            {
                ListViewItem temp = item1;
                item1 = item2;
                item2 = temp;
            }

            //Handle non-column case
            if (ListView.View != View.Details)
            {
                return CaseInsensitiveComparer.DefaultInvariant.Compare(item1.Text, item2.Text);
            }

            //Get the subitems to compare
            ListViewItem.ListViewSubItem sub1 = item1.SubItems[SortColumn];
            ListViewItem.ListViewSubItem sub2 = item2.SubItems[SortColumn];

            return CompareSubItems(sub1, sub2);
        }
        private static int CompareSubItems(ListViewItem.ListViewSubItem sub1, ListViewItem.ListViewSubItem sub2)
        {
            if (sub1.Tag == null || sub2.Tag == null)
            {
                //Compare as strings
                return CaseInsensitiveComparer.DefaultInvariant.Compare(sub1.Text, sub2.Text);

            }
            else if (sub1.Tag is Int32)
            {
                //Compare as integers
                int x1 = (Int32)sub1.Tag;
                int x2 = (Int32)sub2.Tag;

                return x1.CompareTo(x2);
            }
            else if(sub1.Tag is DateTime)
            {
                //Compare as dates
                DateTime x1 = (DateTime)sub1.Tag;
                DateTime x2 = (DateTime)sub2.Tag;
                return x1.CompareTo(x2);
            }
            throw new ArgumentException("Unable to compare ListviewItem instances");
        }
    }
}
