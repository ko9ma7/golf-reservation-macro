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
            //bunifuDropdown1.selectedIndex = 0;
            //bunifuDropdown2.selectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }


        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (this.Button3_Evnet != null)
                Button3_Evnet(sender, e);
        }

        private void bunifuDropdown1_onItemSelected(object sender, EventArgs e)
        {
            bunifuDropdown2.selectedIndex = bunifuDropdown1.selectedIndex;
        }

        private void bunifuDropdown2_onItemSelected(object sender, EventArgs e)
        {
            if (bunifuDropdown2.selectedIndex < bunifuDropdown1.selectedIndex)
            {
                MessageBox.Show("예비 시간은 희망 시간보다 크거나 같아야 합니다.");
                bunifuDropdown2.selectedIndex = bunifuDropdown1.selectedIndex;
            }
        }
    }
}
