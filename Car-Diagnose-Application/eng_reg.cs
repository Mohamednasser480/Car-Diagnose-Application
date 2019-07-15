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
    public partial class eng_reg : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public eng_reg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select max(id) from engineer";
            cmd1.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd1.ExecuteReader();
            int maxID = 0;
            if (dr1.Read())
            {
                maxID = Convert.ToInt32(dr1[0].ToString());
                maxID++;
            }
            else
                maxID = 1;

            conn.Close();




            conn = new OracleConnection(ordb);
            conn.Open();
            int user_id = login.id;
            string comm = "insert into engineer (id, name,password, e_mail ) values(:id, :name, :password, :mail )";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = comm;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", maxID);
            cmd.Parameters.Add("name", textBox1.Text.ToString());
            cmd.Parameters.Add("password", textBox2.Text.ToString());
            cmd.Parameters.Add("mail", textBox3.Text.ToString());
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Successful", "Row Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                login f = new login();
                f.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();

        }
    }
}
