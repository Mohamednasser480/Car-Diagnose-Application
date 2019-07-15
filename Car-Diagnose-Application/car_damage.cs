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
    public partial class car_damage : Form
    {
        int maxID ;
        bool addhistoryid = false;
        int userid;  
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
         List<string> selected_item=new List<string>();
         List<string> selected_item1 = new List<string>();

        public car_damage()
        {
            InitializeComponent();
        }
        private void insert_car_history(){
            addhistoryid = true;
                conn = new OracleConnection(ordb);

                conn.Open();
                int user_id = login.id;
                string comm1 = "select car_id from car_info where user_id=:id ";
                OracleCommand cmd1 = new OracleCommand();
                cmd1.Connection = conn;
                cmd1.CommandText = comm1;
                cmd1.Parameters.Add("id", user_id);
                OracleDataReader d = cmd1.ExecuteReader();
                int car_id = 0;
                if (d.Read())
                {
                    car_id = Convert.ToInt32(d[0]);
                }
                conn.Close();

                conn = new OracleConnection(ordb);
                conn.Open();
                string comm = "insert into car_history (car_id,history_id) values(:car_id,:history_id) ";
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = comm;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("car_id", car_id);
               // cmd.Parameters.Add("date",System.DateTime.Now.ToString() );
                cmd.Parameters.Add("history_id", maxID);
                int r = cmd.ExecuteNonQuery();
                conn.Close();
    }
      

        private void car_damage_Load(object sender, EventArgs e)
        {
            userid = login.id;
            conn = new OracleConnection(ordb);

            conn.Open();
            int user_id = login.id;
            string comm1 = "select car_id from car_info where user_id=:id ";
            OracleCommand cmd1 = new OracleCommand();
            cmd1.Connection = conn;
            cmd1.CommandText = comm1;
            cmd1.Parameters.Add("id", user_id);
            OracleDataReader d = cmd1.ExecuteReader();
            int car_id = 0;
            if (d.Read())
            {
                car_id = Convert.ToInt32(d[0]);
            }
            conn.Close();
            conn = new OracleConnection(ordb);
            conn.Open();
            cmd1.Connection = conn;
            cmd1.CommandText = "select count(history_id) from car_history";
            cmd1.CommandType = CommandType.Text;
            OracleDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                maxID = Convert.ToInt32(dr1[0].ToString());
                maxID++;
            }
            else
                maxID = 1;

            conn.Close();

            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select type from damage ";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());

            }
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selected_item.Add(comboBox1.SelectedItem.ToString());
           comboBox1.Items.Remove(selected_item[selected_item.Count()-1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selected_item.Count == 0)
            {
                MessageBox.Show("You should select damages");
            }
            else
            {
                int userid = login.id;
               if(!addhistoryid)   insert_car_history();
                    for (int i = 0; i < selected_item.Count; i++)
                    {
                        conn = new OracleConnection(ordb);
                       conn.Open();
                        string comm2 = "insert into car_damage (history_id,damage_type) values(:history_id,:type) ";
                        OracleCommand cmd2 = new OracleCommand();
                        cmd2.Connection = conn;
                        cmd2.CommandText = comm2;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.Add("history_id", maxID);
                        cmd2.Parameters.Add("type", selected_item[i].ToString());

                        int r1 = cmd2.ExecuteNonQuery();

                    }
                    MessageBox.Show("wait for diagnoise from engineer");

                }
                conn.Close();

            }

       
        private void button4_Click(object sender, EventArgs e)
        {
            selected_item1.Add(textBox1.Text.ToString());
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!addhistoryid) insert_car_history();

             conn = new OracleConnection(ordb);
                conn.Open();
           for (int i = 0; i < selected_item1.Count; i++){
                        string comm2 = "insert into car_damage (history_id,damage_type) values(:history_id,:type) ";
                        OracleCommand cmd2 = new OracleCommand();
                        cmd2.Connection = conn;
                        cmd2.CommandText = comm2;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.Parameters.Add("history_id", maxID);
                        cmd2.Parameters.Add("type", selected_item1[i].ToString());
                        int r1 = cmd2.ExecuteNonQuery();
                    }
                    MessageBox.Show("wait for diagnoise from engineer");
                conn.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            USER_PROFILE f = new USER_PROFILE();
            f.Show();
            this.Hide();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }

}
