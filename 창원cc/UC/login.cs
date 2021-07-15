using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace 창원cc.UC
{

    public partial class login : UserControl 
    {
        public event EventHandler Button1_Evnet;

        public login()
        {
            InitializeComponent();
            //bunifuTileButton1.Click += bunifuTileButton1_Click;
            radioButton1.Checked = true;
        }

        public void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (this.Button1_Evnet != null)
                Button1_Evnet(sender, e);
        }
    }
}
