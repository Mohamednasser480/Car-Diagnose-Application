using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace CAR_DIAGANOSE_APPLICATION
{
    public partial class nearstservies : Form

    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public nearstservies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from CENTER_SERVICE where ADDRESS=:address ";
            
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("address", textBox1.Text.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {

                textBox2.Text = dr[0].ToString();
                textBox2.Text +=","+ dr[1].ToString();
                textBox2.Text += ","+dr[2].ToString();


            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_PROFILE f = new USER_PROFILE();
            f.Show();
            this.Hide();
        }
    }
}
