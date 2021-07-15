using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 창원cc.UC
{
    public partial class time : UserControl
    {
        public event EventHandler Button3_Evnet;
        public time()
        {
            InitializeComponent();
            radioButton3.Checked = true;
            bunifuDropdown1.selectedIndex = 0;
        }


        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (this.Button3_Evnet != null)
                Button3_Evnet(sender, e);
        }
    }
}
