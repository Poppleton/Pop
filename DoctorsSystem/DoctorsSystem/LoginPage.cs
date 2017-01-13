using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoctorsSystem
{
    public partial class LoginPage : Form
    {
        System.Data.SqlClient.SqlConnection newCon;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\Year 3\Software Engineering\DoctorsSystem\DoctorsSystem\Surgery.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");//opens up connection to database
            SqlDataAdapter sda = new SqlDataAdapter("Select Role From tblLogin where UserName='" + txtName.Text + "' and Password ='" + txtPassword.Text + "'", con);//select role by the usrname and password entered
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);//populate the dataset
            if(dt.Rows.Count ==1)//if the username and password are correct
            {
                this.Hide();//hide this page from the user
                Menu frm = new Menu(dt.Rows[0][0].ToString());//load the main menu page
                frm.Show();
                //((Form)frm).Controls["label2"].Text = dt.Rows[0][0].ToString();

            }

            else//if the username of password are incorrect
            {
                MessageBox.Show("Please check your Username and Password");//display this message to the user
            }



        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)//if the exit button is clicked
        {
            this.Close();//close the form 
        }
    }
}
