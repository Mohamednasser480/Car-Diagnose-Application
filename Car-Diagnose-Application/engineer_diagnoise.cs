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
    public partial class engineer_diagnoise : Form
    {
        public static int id = 0;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public engineer_diagnoise()
        {
            InitializeComponent();
        }

        private void engineer_diagnoise_Load(object sender, EventArgs e)
        {
            
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select history_id from car_history where diagnoise is null";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int car_id=0;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select car_id from car_history where history_id=:id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", comboBox1.SelectedItem.ToString());
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                car_id = Convert.ToInt32(dr[0]);
            }
            conn.Close();

            conn = new OracleConnection(ordb);
            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from car_info where car_id=:car_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("car_id",car_id);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox1.Text = dr[1].ToString();
                textBox2.Text = dr[2].ToString();
            }
            conn.Close();
            conn = new OracleConnection(ordb);

            conn.Open();
            cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from car_damage where history_id=:his_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("his_id", comboBox1.SelectedItem.ToString());
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
               
                textBox3.AppendText(dr[1].ToString());
                textBox3.AppendText("\n");
               
            }
            conn.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "update CAR_HISTORY set diagnoise=:d where history_id=:his_id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("d", textBox4.Text.ToString());
            cmd.Parameters.Add("his_id", comboBox1.SelectedItem.ToString());
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("diagnoised succefull");
                comboBox1.Items.Remove(comboBox1.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("ERROR");
            }

            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ENGINEER_PROFILE f = new ENGINEER_PROFILE();
            f.Show();
            this.Hide();
        }
    }
}
