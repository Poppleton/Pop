using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorsSystem
{
    public partial class AddPatient : Form
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)//when the add button is clicked
        {
            Patients objAddPatient = new Patients();//calls the add patient method 
            objAddPatient.PatientName = txtName.Text;//informs the method which values it uses, each one below sending the method a variable based on what the user has inputted into the form
            objAddPatient.PatientAge = int.Parse(txtAge.Text);
            objAddPatient.Gender = txtGender.Text;
            objAddPatient.Address = txtAddress.Text;
            objAddPatient.Number = txtNumber.Text;
            objAddPatient.PostCode = txtPostCode.Text;
            objAddPatient.DOB = txtDOB.Text;
            objAddPatient.Notes = txtNotes.Text;

            objAddPatient.AddNewPatient();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
