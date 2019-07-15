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
    public partial class USER_REGISTER : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public USER_REGISTER()
        {
            InitializeComponent();
        }

        private void USER_REGISTER_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void register_button_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select max(user_id) from user_info";
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
            string comm = "insert into user_info (user_id, name, phone,password, address, age,ssn,e_mail ) values(:id, :name, :phone,:password, :address, :age,:ssn,:mail )";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = comm;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", maxID);
            cmd.Parameters.Add("name", name.Text.ToString());
            cmd.Parameters.Add("phone", phone.Text.ToString());
            cmd.Parameters.Add("password", password.Text.ToString());
            cmd.Parameters.Add("address", address.Text.ToString());
            cmd.Parameters.Add("age", age.Text.ToString());
            cmd.Parameters.Add("ssn", ssn.Text.ToString());
            cmd.Parameters.Add("mail",mail.Text.ToString());
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

        private void main_button_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }
    }
}
