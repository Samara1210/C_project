using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace loginAndRegApp
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        // assigning database commands to the variables
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=db_users.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void button1_Click(object sender, EventArgs e)
        {
            if (ConnectionState.Closed == con.State)
            {
                con.Open();
            }

            string login = "SELECT * FROM tbl_users WHERE username= '" + txtUsername.Text + "' and password= '" + txtpassword.Text + "'"; // get user input
            cmd = new OleDbCommand(login, con); // 
            OleDbDataReader dr = cmd.ExecuteReader(); // check if user exists

            if (dr.Read() == true) // if user exists
            {
                new userDashboard().Show();
                this.Hide();
            }
            else
            {
                // if user dosent exist
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtpassword.Text = "";
                txtUsername.Focus();
            }
        }

        // Clear fields
        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtUsername.Focus();
        }

        // Display passowrld check box
        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';

            }
            else
            {
                txtpassword.PasswordChar = '*';

            }
        }

        // logout function
        private void label6_Click(object sender, EventArgs e)
        {
            new registerForm().Show();
            this.Hide();
        }
    }
}
