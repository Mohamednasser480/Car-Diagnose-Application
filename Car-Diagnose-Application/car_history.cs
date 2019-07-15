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
    public partial class car_history : Form
    {
        List<int> history_id = new List<int>();
        int userid , car_id;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public car_history()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            USER_PROFILE f = new USER_PROFILE();
            f.Show();
            this.Hide();
        }

      

        private void car_history_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);

            conn.Open();
            int user_id = login.id;
            string comm1 = "select car_id from car_info where user_id=:id ";
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = comm1;
            cmd1.Parameters.Add("id", user_id);
            OracleDataReader d = cmd1.ExecuteReader();
            if (d.Read())
            {
                car_id = Convert.ToInt32(d[0].ToString());
            }
            conn.Close();
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select history_id from car_history where car_id=:id";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id", car_id);
            OracleDataReader dr = cmd2.ExecuteReader();
            while(dr.Read()){
                comboBox1.Items.Add(dr[0].ToString());
            }
            conn.Close();
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
              
             conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select * from car_info where car_id=:id";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id", car_id);
            OracleDataReader dr = cmd2.ExecuteReader();
           if(dr.Read()){
                car_type.Text=dr[2].ToString();
                car_model.Text=dr[1].ToString();
                car_color.Text = dr[3].ToString();
                car_lic.Text=dr[4].ToString();

            }
            conn.Close();


          int   userid = login.id;
           conn = new OracleConnection(ordb);
           conn.Open();
           cmd2 = new OracleCommand();
           cmd2.Connection = conn;
           cmd2.CommandText = "select SSN from user_info where user_id=:id";
           cmd2.CommandType = CommandType.Text;
           cmd2.Parameters.Add("id", userid);
           dr = cmd2.ExecuteReader();
            while(dr.Read()){
                SSN.Text = dr[0].ToString();
            }
            conn.Close();
        




   conn = new OracleConnection(ordb);
            conn.Open();
             cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select diagnoise from car_history where history_id=:id2";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id2", comboBox1.SelectedItem.ToString());
            dr = cmd2.ExecuteReader();
            if(dr.Read()){
                textBox6.Text = dr[0].ToString();
            }
            conn.Close();




            conn = new OracleConnection(ordb);
            conn.Open();
            cmd2 = new OracleCommand();
            cmd2.Connection = conn;
            cmd2.CommandText = "select damage_type from car_damage where history_id=:id3";
            cmd2.CommandType = CommandType.Text;
            cmd2.Parameters.Add("id3", comboBox1.SelectedItem.ToString());
            dr = cmd2.ExecuteReader();
            while (dr.Read())
            {
                textBox7.Text += dr[0].ToString();
                textBox7.Text += "\n";
            }
            conn.Close();

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }



        }
    }

