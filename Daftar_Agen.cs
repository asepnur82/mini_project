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
    public partial class Daftar_Agen : Form
    {
        public Daftar_Agen()
        {
            InitializeComponent();
        }
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
            var rowdata = 1;

            var APIkey = "07d4c9c5-b36e-11ed-ac66-bac3ac349683";
            var kd_kota = "";
            string tgl_kd_kota;

            kd_kota = comboBox1.Text.Substring(0, 1);

            //textBox1.Text = textBox3.Text + tgl;
            tgl_kd_kota = kd_kota + textBox1.Text;

            var sign = SHA512(APIkey + tgl_kd_kota).ToLower();

            var client = new RestClient("https://agra-api.com/wacenter/list_agen?city=" + kd_kota + "&sign=" + sign);
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

        private void Daftar_Agen_Load(object sender, EventArgs e)
        {
            string tgl = DateTime.Now.ToString("yyyy-MM-dd");
            textBox1.Text = DateTime.Now.ToString("yyyy-MM-dd");

            comboBox1.Items.Add("5 - Solo");
            comboBox1.Items.Add("6 - Wonogiri");
            comboBox1.Items.Add("7 - Jakarta Selatan");
            comboBox1.Items.Add("8 - Jakarta Barat");
            comboBox1.Items.Add("9 - Jakarta Utara");
            comboBox1.SelectedIndex =0;
        }
    }
}
