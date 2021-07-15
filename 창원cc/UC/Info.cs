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
    public partial class Info : UserControl
    {
        public event EventHandler Button2_Evnet;

        public bool test = false;
        TextBox[] txtList;
        string Placeholder1 = "회원번호 숫자만 입력";
        string Placeholder2 = "회원번호 숫자만 입력";
        string Placeholder3 = "회원번호 숫자만 입력";
        public Info()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            radioButton5.Checked = true;

            txtList = new TextBox[] { textBox1, textBox2 , textBox3 };
            foreach (var txt in txtList)
            {
                //처음 공백 Placeholder 지정
                txt.ForeColor = Color.DarkGray;
                if (txt == textBox1) txt.Text = Placeholder1;
                else if (txt == textBox2) txt.Text = Placeholder2;
                else if (txt == textBox3) txt.Text = Placeholder3;
                //텍스트박스 커서 Focus 여부에 따라 이벤트 지정
                txt.GotFocus += RemovePlaceholder;
                txt.LostFocus += SetPlaceholder;
            }

        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.Text == Placeholder1 | txt.Text == Placeholder2 | txt.Text == Placeholder3)
            { //텍스트박스 내용이 사용자가 입력한 값이 아닌 Placeholder일 경우에만, 커서 포커스일때 빈칸으로 만들기
                txt.ForeColor = Color.Black; //사용자 입력 진한 글씨
                txt.Text = string.Empty;
                //if (txt == textBox2) textBox2.PasswordChar = '●';
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                //사용자 입력값이 하나도 없는 경우에 포커스 잃으면 Placeholder 적용해주기
                txt.ForeColor = Color.DarkGray; //Placeholder 흐린 글씨
                if (txt == textBox1) txt.Text = Placeholder1;
                else if (txt == textBox2) { txt.Text = Placeholder2; }
                else if (txt == textBox3) { txt.Text = Placeholder3; }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = false;
            Placeholder1 = "이름";
            textBox1.Text = Placeholder1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label8.Visible = true;
            Placeholder1 = "회원번호 숫자만 입력";
            textBox1.Text = Placeholder1;

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = true;
            Placeholder2 = "회원번호 숫자만 입력";
            textBox2.Text = Placeholder2;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
            Placeholder2 = "이름";
            textBox2.Text = Placeholder2;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label10.Visible = true;
            Placeholder3 = "회원번호 숫자만 입력";
            textBox3.Text = Placeholder3;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label10.Visible = false;
            Placeholder3 = "이름";
            textBox3.Text = Placeholder3;
        }

        private void bunifuTileButton1_Click(object sender, EventArgs e)
        {
            if (this.Button2_Evnet != null)
                Button2_Evnet(sender, e);
        }
    }
}
