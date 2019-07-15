using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAR_DIAGANOSE_APPLICATION
{
    public partial class admin_profil : Form
    {
        public admin_profil()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login f = new login();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           edit_service_data f = new edit_service_data();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           edit_engineer_data f = new edit_engineer_data();
            f.Show();
            this.Hide();
        }
    }
}
