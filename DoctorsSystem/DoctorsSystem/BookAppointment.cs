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
    public partial class BookAppointment : Form
    {
        public BookAppointment()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Appointments objAddAppointment = new Appointments();//calls method 
            objAddAppointment.PatientName = txtPatientName.Text;//sets variables to be used 
            objAddAppointment.DoctorName = txtDoctorName.Text;
            objAddAppointment.BookingDate = dateTimePicker3.Value.Date;
            objAddAppointment.BookingTime = comboBox1.SelectedItem.ToString();
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
