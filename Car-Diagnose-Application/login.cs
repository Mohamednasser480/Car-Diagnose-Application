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
    public partial class login : Form
    {
        public static int id = 0;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public login()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {


                
                
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                admin_profil f = new admin_profil();
                f.Show();
                this.Hide();
            }
            else
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                string user_cmd = "select * from USER_INFO where E_MAIL=:mail and PASSWORD=:password";
                string eng_cmd = "select * from ENGINEER where E_MAIL=:mail and PASSWORD=:password";
                string comm = " ";
                if (user_radioButton1.Checked == true)
                    comm = user_cmd;
                else if (eng_radioButton2.Checked == true)
                    comm = eng_cmd;

                cmd.Connection = conn;
                cmd.CommandText = comm;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("mail", textBox1.Text.ToString());
                cmd.Parameters.Add("password", textBox2.Text.ToString());
                OracleDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    id = Convert.ToInt32(dr[0]);

                    if (user_radioButton1.Checked == true)
                    {

                        USER_PROFILE f = new USER_PROFILE();
                        f.Show();
                        this.Hide();
                    }
                    if (eng_radioButton2.Checked == true)
                    {
                        ENGINEER_PROFILE f = new ENGINEER_PROFILE();
                        f.Show();
                        this.Hide();
                    }

                    else if (eng_radioButton2.Checked == false && user_radioButton1.Checked == false)
                    {
                        MessageBox.Show("ERROR>>YOU SHOULD SELECT(USER OR ENGINEER)");
                    }

                }

                else
                {
                    MessageBox.Show("invaild data");
                }
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (user_radioButton1.Checked == true)
            {

               USER_REGISTER f = new USER_REGISTER();
                f.Show();
                this.Hide();
            }
            if (eng_radioButton2.Checked == true)
            {
                eng_reg f = new eng_reg();
                f.Show();
                this.Hide();
            }
            else if (eng_radioButton2.Checked == false && user_radioButton1.Checked == false)

            {
                MessageBox.Show("ERROR>>YOU SHOULD SELECT(USER OR ENGINEER)");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void eng_radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void user_radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
