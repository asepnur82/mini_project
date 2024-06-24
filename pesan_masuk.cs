//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
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

namespace WindowsFormsApp1
{
    public partial class pesan_masuk : Form
    {
        public pesan_masuk()
        {
            InitializeComponent();
        }
        ChromeDriver browser;
        string tgl = "2024-06-23";
        bool hasil_login = true;

        public static string SHA512(string input)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            using (var hash = System.Security.Cryptography.SHA512.Create())
            {
                var hashedInputBytes = hash.ComputeHash(bytes);
                var hashedInputStringBuilder = new System.Text.StringBuilder(128);
                foreach (var b in hashedInputBytes)
                    hashedInputStringBuilder.Append(b.ToString("X2"));
                return hashedInputStringBuilder.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var options = new ChromeOptions();
            //var chromeDriverService = ChromeDriverService.CreateDefaultService();

            //chromeDriverService.HideCommandPromptWindow = true;

            //options.AddArguments(@"user-data-dir=" + Application.StartupPath + "/profile");            
            //browser = new ChromeDriver(chromeDriverService, options);

            //browser.Navigate().GoToUrl("https://web.whatsapp.com/");            
            //System.Threading.Thread.Sleep(10000);
            //timer1.Enabled = true;


            if (System.IO.File.Exists("koneksidb.txt"))
            {
                databases.constr = File.ReadAllText(@"koneksidb.txt");
            }

            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(databases.constr);

            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
            cn.Open();
            using (SqlCommand getdata = new SqlCommand("SELECT id_user, nama FROM m_user", cn))
            {
                SqlDataAdapter da = new SqlDataAdapter(getdata);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show(dt.Rows[0]["id_user"].ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            browser.Quit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var rowdata = 1;

            var APIkey = "07d4c9c5-b36e-11ed-ac66-bac3ac349683";
            textBox1.Text = textBox3.Text + tgl;
            var sign = SHA512(APIkey + textBox1.Text).ToLower();

            var client = new RestClient("https://agra-api.com/wacenter/list_agen?city=" + textBox3.Text + "&sign=" + sign);
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("key", APIkey);

            var response = client.Execute(request);
            textBox2.Text = response.Content;

            var obj = JObject.Parse(response.Content);

            JToken token = obj["data"];

            if (token.Type != JTokenType.Null)
            {
                // Do your logic
                var nilai = (JArray)obj["data"];
                textBox2.Text = "";
                foreach (JObject root in nilai)
                {
                    foreach (KeyValuePair<String, JToken> app in root)
                    {
                        var appName = app.Key;
                        var Isi = (String)app.Value;

                        if (appName == "NamaAgen")
                        {
                            if (rowdata == 1)
                            {
                                textBox2.Text = textBox2.Text + "DAFTAR NAMA AGEN" + System.Environment.NewLine;
                                textBox2.Text = textBox2.Text + "=============================" + System.Environment.NewLine;
                                textBox2.Text = textBox2.Text + "Nama Agen : " + Isi + System.Environment.NewLine;
                            }
                            else
                            {
                                textBox2.Text = textBox2.Text + "=============================" + System.Environment.NewLine;
                                textBox2.Text = textBox2.Text + "Nama Agen : " + Isi + System.Environment.NewLine;
                            }
                        }
                        else if (appName == "NoHP")
                        {
                            textBox2.Text = textBox2.Text + "No HP : " + Isi + System.Environment.NewLine;
                        }
                        else if (appName == "Alamat")
                        {
                            textBox2.Text = textBox2.Text + "Alamat : " + Isi + System.Environment.NewLine;
                        }
                        rowdata = rowdata + 1;
                    }

                }
            }
            else
            { textBox2.Text = "Data Tidak Ditemukan"; }
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
                //IList<IWebElement> elements = browser.FindElements(By.ClassName("_ahlk"));
                IList<IWebElement> pesan_baru = browser.FindElements(By.CssSelector("span[class='x1rg5ohu x173ssrc x1xaadd7 x682dto x1e01kqd x12j7j87 x9bpaai x1pg5gke x1s688f xo5v014 x1u28eo4 x2b8uid x16dsc37 x18ba5f9 x1sbl2l xy9co9w x5r174s x7h3shv']"));
                if (pesan_baru.Count > 0)
                {
                    IList<IWebElement> elements = browser.FindElements(By.ClassName("_ahlk"));
                    foreach (IWebElement element in elements)
                    {
                        Console.WriteLine(element.Text);
                        try
                        {
                            element.FindElement(By.CssSelector("span[class='x1rg5ohu x173ssrc x1xaadd7 x682dto x1e01kqd x12j7j87 x9bpaai x1pg5gke x1s688f xo5v014 x1u28eo4 x2b8uid x16dsc37 x18ba5f9 x1sbl2l xy9co9w x5r174s x7h3shv']")).Click();
                            var pengirim = browser.FindElement(By.ClassName("_amig")).Text;
                        }
                        catch
                        { }

                    }
                }

                timer1.Enabled = true;
            }
        }
    }
}
