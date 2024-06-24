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
    public partial class Form1 : Form        
    {        
        public Form1()
        {          
            InitializeComponent();            
        }               
        private void Form1_Load(object sender, EventArgs e)
        {         
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists("koneksidb.txt"))
            {
                databases.constr = File.ReadAllText(@"koneksidb.txt");
            }
            else
            {
                MessageBox.Show("File koneksidb.txt tidak ditemukan");
                return;
            }

            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(databases.constr);

            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
            cn.Open();
            using (SqlCommand getdata = new SqlCommand("SELECT id_user, nama FROM m_user where nama = '"
                    + txtnama.Text + "' and password = '" + txtpassword.Text + "'", cn))
            {
                SqlDataAdapter da = new SqlDataAdapter(getdata);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show(dt.Rows[0]["id_user"].ToString());
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("User tidak ditemukan");
                }
            }
            cn.Close();
        }

        private void btnkeluar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
