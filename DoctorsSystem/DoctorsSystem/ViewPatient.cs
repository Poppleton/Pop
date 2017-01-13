using System;
using System.Collections.Generic;
using System.Collections;
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
    public partial class ViewPatient : Form
    {
        Patients editPatients;
        DataSet dsPatient;
        public ViewPatient()
        {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            Patients viewPatients = new Patients();//calls method
            viewPatients.GetPatientByPatientID(int.Parse(txtPatientID.Text));//will collect info fro databsde depending of the ID number entered 
            txtPatientName.Text = viewPatients.PatientName;//informs of what data to be displayed to the user.
            txtPatientAge.Text = viewPatients.PatientAge.ToString();
            txtGender.Text = viewPatients.Gender;
            txtAddress.Text = viewPatients.Address;
            txtNumber.Text = viewPatients.Number;
            txtPostCode.Text = viewPatients.PostCode;
            txtDOB.Text = viewPatients.DOB;
            txtNotes.Text = viewPatients.Notes;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtPatientName.Text = editPatients.PatientName;
            txtPatientAge.Text = editPatients.PatientAge.ToString();
            txtGender.Text = editPatients.Gender;
            txtAddress.Text = editPatients.Address;
            txtNumber.Text = editPatients.Number;
            txtPostCode.Text = editPatients.PostCode;
            txtDOB.Text = editPatients.DOB;
            txtNotes.Text = editPatients.Notes;
            
            editPatients = new Patients();
            editPatients.UpdatePatient(dsPatient);
            

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Patients details currently being viewed would be removed from database");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
