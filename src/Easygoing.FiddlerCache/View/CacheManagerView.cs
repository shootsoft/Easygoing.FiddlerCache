using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Easygoing.FiddlerCache.View
{
    public partial class CacheManagerView : UserControl
    {
        public CacheManagerView()
        {
            InitializeComponent();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {

        }

        internal void LoadViewItem(IEnumerable<Model.CacheItem> items)
        {
            foreach (var item in items)
            {
                TreeListViewCache.AddObject(item);
            }
        }
    }
}
