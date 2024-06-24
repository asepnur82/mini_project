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
    public partial class pesan_wa : Form
    {
        public pesan_wa()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        SqlConnection cn = new SqlConnection(databases.constr);

        private void pesan_wa_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection cn = new SqlConnection(databases.constr);

            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
            cn.Open();
            using (SqlCommand getdata = new SqlCommand("SELECT * FROM inbox1", cn))
            {
                SqlDataAdapter da = new SqlDataAdapter(getdata);
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    //MessageBox.Show(dt.Rows[0]["id_user"].ToString());
                    Mst_grid_View.DataSource = dt;
                }
                else
                {
                    
                }
            }
            cn.Close();
        }
               
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtidpesan.Text = Mst_grid_View.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtnohp.Text = Mst_grid_View.Rows[e.RowIndex].Cells[2].Value.ToString();            
        }

        private void btnbalas_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                var command = new SqlCommand();
                command.Connection = cn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "[sp_tambahoutboxpenumpang]";
                command.Parameters.Add("@TUJUAN", SqlDbType.VarChar, 30).Value = txtnohp.Text;
                command.Parameters.Add("@PESAN", SqlDbType.Text).Value = txtpesan.Text;
                command.Parameters.Add("@PENGIRIM", SqlDbType.VarChar, 30).Value = "";
                command.Parameters.Add("@IDTUJUAN", SqlDbType.VarChar, 14).Direction = ParameterDirection.Output;

                var reader = command.ExecuteReader();
                txtnohp.Text = "";
                txtpesan.Text = "";
                reader.Close();

                string sqlstr;
                sqlstr = "update inbox1 set sts_balas= 1 where id_in ='" + txtidpesan.Text.Trim() + "'";
                var command1 = new SqlCommand();
                command1 = new SqlCommand();
                command1.Connection = cn;
                command1.CommandText = sqlstr;
                command1.ExecuteNonQuery();

                cn.Close();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void Mst_grid_View_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
