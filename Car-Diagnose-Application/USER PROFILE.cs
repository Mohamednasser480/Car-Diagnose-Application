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
    public partial class USER_PROFILE : Form
    {
        
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public USER_PROFILE()
        {
           
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USER_ANDCAR_INFO f = new USER_ANDCAR_INFO();
            this.Hide();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nearstservies f = new nearstservies();
            this.Hide();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            car_history f = new car_history();
            this.Hide();
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int userid = login.id;
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from CAR_INFO where USER_ID=:id";
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", userid);
            OracleDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                car_damage f = new car_damage();
                this.Hide();
                f.Show();
                conn.Close();
            }
            else
            {
                MessageBox.Show("YOUR CAR INFORMATION IS MISSING >>>YOU SHOULD UPDATE IT.");
                conn.Close();
            }
            
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            login f = new login();
            this.Hide();
            f.Show();
        }
    }
}
