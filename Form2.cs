using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

using Newtonsoft.Json.Linq;
using RestSharp;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using Keys = System.Windows.Forms.Keys;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        
        ChromeDriver browser;
        //string tgl = "2024-06-23";       

        bool hasil_login = true;
        string gbldari;
        TextBox txtpesan;

        DataTable dt = new DataTable();
        SqlConnection cn = new SqlConnection(databases.constr);
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {           
            string tgl = DateTime.Now.ToString("yyyy-MM-dd");

            if (System.IO.File.Exists("koneksidb.txt"))
            {
                databases.constr = File.ReadAllText(@"koneksidb.txt");
            }
            else
            {
                MessageBox.Show("File koneksidb.txt tidak ditemukan");
                return;
            }
                                             

            try
            {
                var options = new ChromeOptions();
                var chromeDriverService = ChromeDriverService.CreateDefaultService();

                chromeDriverService.HideCommandPromptWindow = true;

                options.AddArguments("user-data-dir=" + Application.StartupPath + "/profile");
                browser = new ChromeDriver(chromeDriverService);

                browser.Navigate().GoToUrl("https://web.whatsapp.com/");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //var options = new ChromeOptions();
            //var chromeDriverService = ChromeDriverService.CreateDefaultService();

            //chromeDriverService.HideCommandPromptWindow = true;

            //options.AddArguments("user-data-dir=" + Application.StartupPath + "/profile");
            //browser = new ChromeDriver(chromeDriverService, options);

            //browser.Navigate().GoToUrl("https://web.whatsapp.com/");
            System.Threading.Thread.Sleep(10000);
            timer1.Enabled = true;


        }

        private bool ceklogin()
        {
            try
            {
                browser.FindElement(By.CssSelector("div[class='_akaz']"));
                hasil_login = false;
            }
            catch
            {
                hasil_login = true;
            }

            return hasil_login;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //browser.FindElement(By.CssSelector("div[class='_akaz']"));
            ceklogin();
            if (hasil_login = true)
            {
                timer1.Enabled = false;
                               
                IList<IWebElement> pesan_baru = browser.FindElements(By.CssSelector("span[class='x1rg5ohu x173ssrc x1xaadd7 x682dto x1e01kqd x12j7j87 x9bpaai x1pg5gke x1s688f xo5v014 x1u28eo4 x2b8uid x16dsc37 x18ba5f9 x1sbl2l xy9co9w x5r174s x7h3shv']"));
                if (pesan_baru.Count > 0)
                {
                    IList<IWebElement> elements = browser.FindElements(By.ClassName("_ahlk"));
                    foreach (IWebElement element in elements)
                    {                        
                        try
                        {
                            element.FindElement(By.CssSelector("span[class='x1rg5ohu x173ssrc x1xaadd7 x682dto x1e01kqd x12j7j87 x9bpaai x1pg5gke x1s688f xo5v014 x1u28eo4 x2b8uid x16dsc37 x18ba5f9 x1sbl2l xy9co9w x5r174s x7h3shv']")).Click();
                            var pengirim = browser.FindElement(By.ClassName("_amig")).Text;

                            if(pengirim.Substring(0,1) == "+")
                            {
                                pengirim = pengirim.Replace(" ", "").Replace("-", "");
                            }

                            gbldari = "";
                            gbldari = pengirim.Trim();
                            cn.Open();
                            var command = new SqlCommand();                            
                            command.Connection = cn;
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = "[sp_tambahpenumpang]";
                            command.Parameters.Add("@notelp", SqlDbType.VarChar, 20).Value = pengirim;
                            var reader = command.ExecuteReader();
                            cn.Close();
                        }
                        catch
                        { }

                    }
                    txtpesan = new TextBox();

                    IList<IWebElement> newmsg1 = browser.FindElements(By.CssSelector("div[class='message-in focusable-list-item _amjy _amjz _amjw']"));
                    foreach (IWebElement pesan in newmsg1)
                    {
                        string isipesan = pesan.FindElement(By.CssSelector("span[class='_ao3e selectable-text copyable-text']")).Text;

                        if (isipesan.Length >= 768)
                        {
                            browser.FindElement(By.CssSelector("span[data-testid='caption-read-more-button']")).Click();
                            string isipesanpanjang = pesan.FindElement(By.CssSelector("span[class='_ao3e selectable-text copyable-text']")).Text;
                            txtpesan.Text = isipesanpanjang;
                        }
                        else
                        { txtpesan.Text = isipesan; }
                        cn.Open();
                        var command = new SqlCommand();
                        command.Connection = cn;
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "[sp_tambahinbox]";
                        command.Parameters.Add("@PENGIRIM", SqlDbType.VarChar, 30).Value = gbldari.Trim();
                        command.Parameters.Add("@PESAN", SqlDbType.Text).Value = txtpesan.Text.Trim();
                        var reader = command.ExecuteReader();
                        cn.Close();
                    }
                }                                    
                timer2.Enabled = true;
            }
        }

        private void pesanMasukToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pesan_wa frm = new pesan_wa();
            frm.Show();
        }

        private void daftarAgenAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Daftar_Agen frm = new Daftar_Agen();
            frm.Show();
        }

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            browser.Quit();
            System.Windows.Forms.Application.Exit();            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string sTujuan;
            txtpesan = new TextBox();
            timer2.Enabled = false;
            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
            cn.Open();
            using (SqlCommand getdata = new SqlCommand("SELECT TOP(1) * from Outbox1 with(nolock) where proses='0' order by id_out", cn))
            {
                SqlDataAdapter da = new SqlDataAdapter(getdata);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show(dt.Rows[0]["id_user"].ToString());
                    sTujuan = dt.Rows[0]["tujuan"].ToString();
                    txtpesan.Text = dt.Rows[0]["pesan"].ToString();
                    try
                    {                       
                        browser.FindElement(By.CssSelector("p[class='selectable-text copyable-text x15bjb6t x1n2onr6']")).SendKeys(sTujuan);
                        browser.FindElement(By.CssSelector("p[class='selectable-text copyable-text x15bjb6t x1n2onr6']")).SendKeys(OpenQA.Selenium.Keys.Enter);
                        //element.FindElement(By.CssSelector("span[class='x1rg5ohu x173ssrc x1xaadd7 x682dto x1e01kqd x12j7j87 x9bpaai x1pg5gke x1s688f xo5v014 x1u28eo4 x2b8uid x16dsc37 x18ba5f9 x1sbl2l xy9co9w x5r174s x7h3shv']")).Click();
                        System.Threading.Thread.Sleep(1000);
                    }
                    catch
                    { }

                    if(dt.Rows[0]["pesan"].ToString() != "")                       
                    {
                        txtpesan.SelectAll();
                        txtpesan.Copy();

                        try
                        {
                            browser.FindElement(By.CssSelector("div[class='x1hx0egp x6ikm8r x1odjw0f x1k6rcq7 x6prxxf']")).SendKeys(OpenQA.Selenium.Keys.Control + "v");
                            browser.FindElement(By.CssSelector("span[data-icon='send']")).Click();
                        }
                        catch
                        { }
                    }

                    var command = new SqlCommand();
                    command.CommandText = "update outbox1 set proses='1' where tujuan ='" + dt.Rows[0]["tujuan"].ToString() + "'" +
                                          " and proses = 0 ";
                    command.Connection = cn;
                    command.ExecuteNonQuery();                    
                }
                
            }
            cn.Close();
            timer1.Enabled = true;
        }
    }
}
