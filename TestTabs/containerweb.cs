using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireTabs;

namespace TestTabs
{
    public partial class containerweb : FireTitle
    {
        public containerweb()
        {
            InitializeComponent();
            TabRenderer = new FireTabRenderer(this);
            AeroPeekEnabled = true;
        }

        public override FireTitleTab CreateTab()
        {
            return new FireTitleTab(this)
            {
                Content = new Browser
                {
                    Text = "Fire Browser"
                }
            };
        }
    }
}
