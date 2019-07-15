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
    public partial class USER_ANDCAR_INFO : Form
    {
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        bool has_car = false;
        public USER_ANDCAR_INFO()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void USER_ANDCAR_INFO_Load(object sender, EventArgs e)
        {
            int userid = login.id;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from USER_INFO where USER_ID=:id";
            cmd.Parameters.Add("id", userid);
            cmd.CommandType = CommandType.Text;

            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                name.Text = dr[1].ToString();
                phone.Text = dr[2].ToString();
                email.Text = dr[3].ToString();
                add.Text = dr[4].ToString();
                ssn.Text = dr[5].ToString();
                age.Text = dr[6].ToString();
                password.Text = dr[7].ToString();


            }


            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = "select * from CAR_INFO where USER_ID=:id";
            cmd1.Parameters.Add("id", userid);
            cmd1.CommandType = CommandType.Text;

            OracleDataReader dr1 = cmd1.ExecuteReader();
           
            if (dr1.Read())
            {
                has_car = true;
                model.Text = dr1[1].ToString();
                type.Text = dr1[2].ToString();
                plate.Text = dr1[3].ToString();
                color.Text = dr1[4].ToString();
               

            }


            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (has_car == true)
            {
                conn = new OracleConnection(ordb);
                conn.Open();
                int user_id = login.id;
                string comm = "update car_info set CAR_MODEL=:model , TYPE=:type , DRIVE_LICENCE=:plate , COLOr = :color where USER_ID=:id ";
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = comm;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("model", model.Text.ToString());
                cmd.Parameters.Add("type", type.Text.ToString());
                cmd.Parameters.Add("plate", plate.Text.ToString());
                cmd.Parameters.Add("color", color.Text.ToString());

                cmd.Parameters.Add("id", user_id);
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Successful", "Row Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Wrong", "Email or Password are not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                conn.Close();
            }
            else
            {
                conn.Open();
                string ID = "select Max(CAR_ID) from CAR_INFO ";
                int maxID = 0;
                OracleCommand id = new OracleCommand();
                id.Connection = conn;
                id.CommandText = ID;
                id.CommandType = CommandType.Text;
                OracleDataReader IDS = id.ExecuteReader();
                if (IDS.Read())
                {
                    maxID = Convert.ToInt32(IDS[0]);
                    maxID++;
                  
                }
                else
                {
                    maxID = 1;
                }
               

                conn.Close();

                conn = new OracleConnection(ordb);
                conn.Open();
                int user_id = login.id;
                string comm = "insert into car_info (car_id, CAR_MODEL, TYPE, DRIVE_LICENCE, COLOR , USER_ID ) values(:car_id, :model , :type , :plate , :color , :id )";
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = comm;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("car_id", maxID);
                cmd.Parameters.Add("model", model.Text.ToString());
                cmd.Parameters.Add("type", type.Text.ToString());
                cmd.Parameters.Add("plate", plate.Text.ToString());
                cmd.Parameters.Add("color", color.Text.ToString());
                cmd.Parameters.Add("id", user_id);
                int r = cmd.ExecuteNonQuery();
                if (r != -1)
                {
                    MessageBox.Show("Successful", "Row Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Wrong", "Email or Password are not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                conn.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            int user_id = login.id;
            string comm = " update user_info set NAME=:name , PHONE=:phone, E_MAIL=:mail,ADDRESS=:address,SSN=:ssn,AGE=:age, password=:pass where user_id=:id ";

            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = comm;
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("name", name.Text.ToString());
            cmd2.Parameters.Add("phone", phone.Text.ToString());
            cmd2.Parameters.Add("mail", email.Text.ToString());
            cmd2.Parameters.Add("address", add.Text.ToString());
            cmd2.Parameters.Add("ssn", ssn.Text.ToString());
            cmd2.Parameters.Add("age", age.Text.ToString());
            cmd2.Parameters.Add("pass", password.Text.ToString());
            cmd2.Parameters.Add("id", user_id);
 
            int r = cmd2.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Successful", "Row Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Wrong", "Email or Password are not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            USER_PROFILE f = new USER_PROFILE();
            f.Show();
            this.Hide();
        }
    }
}
