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
    public partial class Menu : Form
    {
        public Menu(string Role)
        {
            InitializeComponent();
            label2.Text = Role;
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            label3.Text = "Logged in as: " + label2.Text;//will display who is logged in at the top of the form
            
            if (label2.Text == "PracticeManager")//if the login was by the practice manager
            {
                btnAddPatient.Enabled = false;//disable these buttons, they can be seen by the user but not clicked 
                btnAppointments.Enabled = false;
                btnBookAppointment.Enabled = false;
                btnRegisters.Enabled = false;

            }

            if (label2.Text == "Doctor")//if the Login was by the a doctor
            {
                btnAddPatient.Enabled = false;//disable these buttons
                btnAppointments.Enabled = false;
            }

            if (label2.Text == "Receptionist")//if the login was by a receptionist
            {

            }
        }

        private void btnViewPatients_Click(object sender, EventArgs e)//if this button is clicked 
        {
            ViewPatient frm = new ViewPatient();//load this form 
            frm.Show();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            AddPatient frm = new AddPatient();
            frm.Show();
        }

        private void btnAppointments_Click(object sender, EventArgs e)
        {
            Appointment frm = new Appointment();
            frm.Show();  
        }

        private void btnBookAppointment_Click(object sender, EventArgs e)
        {
            BookAppointment frm = new BookAppointment();
            frm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegisters_Click(object sender, EventArgs e)
        {
            Registers frm = new Registers();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)//if the exit button is clicked 
        {
            this.Close();//close this form
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            Reports frm = new Reports();
            frm.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This would load a timetable which would list when each doctor is and isnt available");
        }
    }
}
