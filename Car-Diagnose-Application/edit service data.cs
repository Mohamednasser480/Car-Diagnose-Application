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
    public partial class edit_service_data : Form
    {

        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        public static int id = 0;
        string ordb = "Data source=orcl;User Id=hr; Password=hr;";
        OracleConnection conn;
        public edit_service_data()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
            MessageBox.Show("SAVED SUCCESSFULL..");
        }

        private void edit_service_data_Load(object sender, EventArgs e)
        {
            string constr = "Data Source=orcl; User Id=hr;Password=hr;";
            string cmdstr = "";
            cmdstr = "select * from CENTER_SERVICE";
              adapter = new OracleDataAdapter(cmdstr, constr);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            admin_profil f = new admin_profil();
            f.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            int user_id = login.id;
            string comm = "delete CENTER_SERVICE where name=:name ";
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = comm;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("name",textBox1.Text.ToString());
           
            int r = cmd.ExecuteNonQuery();
            if (r != -1)
            {
                MessageBox.Show("Successful", "Row Updated Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string constr = "Data Source=orcl; User Id=hr;Password=hr;";
                string cmdstr = "";
                cmdstr = "select * from CENTER_SERVICE";
                adapter = new OracleDataAdapter(cmdstr, constr);
                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];     
            }
            else
            {
                MessageBox.Show("Wrong", "Email or Password are not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            conn.Close();

        }
    }
}
