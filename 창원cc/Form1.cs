using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 창원cc
{

    public partial class Form1 : Form
    {
        static public ChromeDriverService _driverService = null;
        static public ChromeOptions _options = null;
        static public ChromeDriver _driver = null;

        UC.time frm3 = new UC.time();

        UC.Info frm2 = new UC.Info();

        UC.login frm = new UC.login();

        

        public Form1()
        {

            InitializeComponent();
            frm3.bunifuDatepicker1.Value= DateTime.Now;
            this.Load += Load_Form;

            frm.Button1_Evnet += Button1_Click_Event;
            frm2.Button2_Evnet += Button2_Click_Event;
            frm3.Button3_Evnet += Button3_Click_Event;

            _driverService = ChromeDriverService.CreateDefaultService();
            _driverService.HideCommandPromptWindow = true;

            _options = new ChromeOptions();
            //_options.AddArgument("--headless");
            _options.AddArgument("--mute-audio");
            _options.AddArgument("disable-gpu");
        }

        public void Load_Form(object sender, EventArgs e)
        {
            panel1.Controls.Add(frm);
            panel2.Controls.Add(frm2);
            panel3.Controls.Add(frm3);
        }

        public void Button1_Click_Event(object sender, EventArgs e)
        {

            Form1._driver = new ChromeDriver(Form1._options);
            Form1._driver.Navigate().GoToUrl("https://changwoncountryclub.co.kr/Member/Login.aspx");
            Form1._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            //Thread.Sleep(1500);

            var element = Form1._driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_userID']"));
            element.SendKeys(frm.textBox2.Text); //아이디 
            element = Form1._driver.FindElement(By.XPath("//*[@id='ctl00_ContentPlaceHolder1_userPass']"));
            element.SendKeys(frm.textBox3.Text); //패스워드
            element = Form1._driver.FindElement(By.XPath("//*[@id='section']/div/div[1]/div/ul[2]/li[2]/a"));
            element.Click();

            //Form1._driver.SwitchTo().Alert().Text;
            Thread.Sleep(100);

            try
            {
                if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                {
                    _driver.SwitchTo().Alert().Accept();
                    MessageBox.Show("로그인 오류");
                }
                else
                {
                    panel1.Visible = false;
                    this.Size= new Size(737, 243);
                    panel2.Visible = true;
                    Information();
                }
            }
            catch (Exception ex)
            {
                panel1.Visible = false;
                this.Size = new Size(737, 243);
                panel2.Visible = true;
                Information();
            }

        }

        public void Information()
        {
            Form1._driver.Navigate().GoToUrl("https://changwoncountryclub.co.kr/Reservation/CompanionPost.aspx");
            //textBox1.Text=Form1._driver.PageSource;
            var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[1]/td"));
            var booker = Regex.Split(element.Text, @"회원번호");
            frm2.label2.Text = booker[0];
            frm2.label4.Text = booker[1];
        }

        public void Button2_Click_Event(object sender, EventArgs e)
        {
            bool check = true;
            if (frm2.radioButton2.Checked)
            {
                var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[2]/td[1]/ul/li[2]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='memberName2']"));
                element.Clear();
                element.SendKeys(frm2.textBox1.Text);
            }
            else
            {
                var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[2]/td[1]/ul/li[1]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='txtGmemno2']"));
                element.Clear();
                element.SendKeys(frm2.textBox1.Text);

                element = Form1._driver.FindElement(By.XPath("//*[@id='btn2']"));
                element.Click();

                Thread.Sleep(100);

                try
                {
                    if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                    {
                        _driver.SwitchTo().Alert().Accept();
                        MessageBox.Show("동반자1 회원번호가 올바르지않습니다.");
                        check = false;
                    }

                }
                catch (Exception ex)
                {
                }
            }

            if (frm2.radioButton4.Checked)
            {
                var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[4]/td[1]/ul/li[2]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[3]/td[1]/ul/li[2]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='memberName3']"));
                element.Clear();
                element.SendKeys(frm2.textBox2.Text);
            }
            else
            {
                var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[3]/td[1]/ul/li[1]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='txtGmemno3']"));
                element.Clear();
                element.SendKeys(frm2.textBox2.Text);

                element = Form1._driver.FindElement(By.XPath("//*[@id='btn3']"));
                element.Click();

                Thread.Sleep(100);

                try
                {
                    if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                    {
                        _driver.SwitchTo().Alert().Accept();
                        MessageBox.Show("동반자2 회원번호가 올바르지않습니다.");
                        check = false;
                    }
                }
                catch (Exception ex)
                {
                }
            }

            if (frm2.radioButton6.Checked)
            {
                var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[4]/td[1]/ul/li[2]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='memberName4']"));
                element.Clear();
                element.SendKeys(frm2.textBox3.Text);
            }
            else
            {
                var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[1]/div/table/tbody/tr[4]/td[1]/ul/li[1]/label"));
                element.Click();

                element = Form1._driver.FindElement(By.XPath("//*[@id='txtGmemno4']"));
                element.Clear();
                element.SendKeys(frm2.textBox3.Text);

                element = Form1._driver.FindElement(By.XPath("//*[@id='btn4']"));
                element.Click();

                Thread.Sleep(100);

                try
                {
                    if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                    {
                        _driver.SwitchTo().Alert().Accept();
                        MessageBox.Show("동반자3 회원번호가 올바르지않습니다.");
                        check = false;
                    }
                }
                catch (Exception ex)
                {
                }
            }

            if (check)
            {
                panel2.Visible = false;
                this.Size = new Size(490, 243);
                panel3.Visible = true;
            }

        }

        public void GetGoogleDateTime()
        {

            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 09, 00, 00);
            bool cc = true;
            while (cc)
            {
                //리턴 할 날짜 선언
                DateTime dateTime = DateTime.MinValue;

                
                try
                {
                    //WebRequest 객체로 구글사이트 접속 해당 날짜와 시간을 로컬 형태의 포맷으로 리턴 일자에 담는다.

                    using (var response = WebRequest.Create("https://changwoncountryclub.co.kr/main/Default.aspx").GetResponse())

                        dateTime = DateTime.ParseExact(response.Headers["date"],

                            "ddd, dd MMM yyyy HH:mm:ss 'GMT'",

                            CultureInfo.InvariantCulture.DateTimeFormat,

                            DateTimeStyles.AssumeUniversal);
                }
                catch (Exception)
                {
                    //오류 발생시 로컬 날짜그대로 리턴
                    dateTime = DateTime.Now;
                }

                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        textBox1.Text = dateTime.ToString();
                    }));
                }
                else
                {
                    textBox1.Text = dateTime.ToString();
                }

                abc:
                bool c = false;
                if (InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (dt <= dateTime)
                        {
                            var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[2]/a[2]"));
                            //element.Click();
                            _driver.ExecuteScript("arguments[0].click();", element);

                            try
                            {
                                if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                                {
                                    _driver.SwitchTo().Alert().Accept();
                                    c = true;
                                }
                                else
                                {
                                    Time_Click();
                                }
                            }
                            catch (Exception ex)
                            {
                                Time_Click();
                            }
                        }
                    }));
                }
                else
                {
                    if (dt <= dateTime)
                    {
                        var element = Form1._driver.FindElement(By.XPath("//*[@id='container']/div[2]/a[2]"));
                        //element.Click();
                        _driver.ExecuteScript("arguments[0].click();", element);

                        try
                        {
                            if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                            {
                                _driver.SwitchTo().Alert().Accept();
                                c = true;
                            }
                            else
                            {
                                Time_Click();
                            }
                        }
                        catch (Exception ex)
                        {
                            Time_Click();
                        }
                    }
                        
                }

                if (c)
                {
                    goto abc;
                }
                else
                {
                    cc = false;
                }
            }
        }

        public void Time_Click()
        {
            string date = frm3.bunifuDatepicker1.Value.ToString("yyyyMMdd");
            //Thread.Sleep(100);
            try
            {
                var element = Form1._driver.FindElements(By.XPath("//*[@id='container']/table/tbody/tr/td/a"));
                //var element = Form1._driver.FindElements(By.XPath(".//*[@id='container']/table/tbody/tr/td"));

                foreach (IWebElement ee in element)
                {

                    if (ee.GetAttribute("href").Contains(date))
                    {
                        //textBox2.Text += ee.Text+"\r\n";
                        if (frm3.radioButton1.Checked && ee.GetAttribute("href").Contains("'22'"))
                            continue;

                        if (frm3.radioButton2.Checked && ee.GetAttribute("href").Contains("'11'"))
                            continue;

                        if (Convert.ToInt32(ee.Text.Substring(0, 2)) >= Convert.ToInt32(frm3.comboBox1.SelectedItem.ToString().Split(':')[0])&& Convert.ToInt32(ee.Text.Substring(0, 2)) <= Convert.ToInt32(frm3.comboBox2.SelectedItem.ToString().Split(':')[0]))
                        {
                            _driver.ExecuteScript("arguments[0].click();", ee);

                            try
                            {
                                if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                                {
                                    _driver.SwitchTo().Alert().Accept();
                                }
                                else
                                {
                                    Thread.Sleep(500);
                                    var element2 = Form1._driver.FindElement(By.XPath("//*[@id='btnSendAuthCode']"));
                                    //element.Click();
                                    //Actions actionProvider = new Actions(_driver); 
                                    //actionProvider.MoveToElement(element2).Click().Perform();

                                    Thread.Sleep(500);
                                    if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                                    {
                                        _driver.SwitchTo().Alert().Accept();
                                    }

                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Thread.Sleep(500);
                                var element2 = Form1._driver.FindElement(By.XPath("//*[@id='btnSendAuthCode']"));
                                //element.Click();
                                //Actions actionProvider = new Actions(_driver);
                                //actionProvider.MoveToElement(element2).Click().Perform();

                                Thread.Sleep(500);
                                if (Form1._driver.SwitchTo().Alert().ToString() == "OpenQA.Selenium.Remote.RemoteAlert")
                                {
                                    _driver.SwitchTo().Alert().Accept();
                                }

                                break;
                            }

                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Button3_Click_Event(object sender, EventArgs e)
        {
            Thread acceptThread = new Thread(() => GetGoogleDateTime());
            acceptThread.IsBackground = true;   // 부모 종료시 스레드 종료
            acceptThread.Start();

            panel3.Visible = false;
            panel4.Visible = true;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox2.Text = frm3.comboBox1.SelectedItem.ToString();
            //if (dt2 > dt)
            //textBox2.Text = "이게더크다";
            /*
            Thread acceptThread = new Thread(() => GetGoogleDateTime());
            acceptThread.IsBackground = true;   // 부모 종료시 스레드 종료
            acceptThread.Start();
            */
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //Form1._driver = new ChromeDriver(@"C:\chrom", Form1._options);
            //Form1._driver.Navigate().GoToUrl("https://changwoncountryclub.co.kr/Reservation/RemainTime.aspx");
            //Form1._driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            try
            {
                var element = Form1._driver.FindElements(By.XPath("//*[@id='container']/table/tbody/tr/td/a"));
                //var element = Form1._driver.FindElements(By.XPath(".//*[@id='container']/table/tbody/tr/td"));
                
                foreach (IWebElement ee in element)
                {
                    textBox2.Text += ee.Text + "\r\n";
                    textBox2.Text += ee.ToString() + "\r\n";
                    textBox2.Text += ee.GetAttribute("href") + "\r\n"; //이거다
                    if (ee.GetAttribute("href").Contains("20210729")&& ee.GetAttribute("href").Contains("1153"))
                    {
                        ee.Click();
                        break;
                    }
                    //ee.Click();
                }
                
                
            }
            catch (Exception)
            {
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
