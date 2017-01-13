using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace DoctorsSystem
{
    class Appointments
    {

        private int m_AppointmentID;//declares variables to be used, delcares variable type, this is an (int)
        private DateTime m_AppDate;
        private string m_AppTime;//delcares varaible to be a (string)
        private string m_PatientName;
        private string m_DoctorName;
        private DateTime m_BookingDate;//dlecraes variable to be a (DateTime)
        private string m_BookingTime;



        public int AppointmentID//gets varaible value from user iput and sets value for databae entry 
        {
            get
            {
                return m_AppointmentID;
            }

            set
            {
                m_AppointmentID = value;
            }
        }

        public DateTime AppDate
        {
            get
            {
                return m_AppDate;
            }

            set
            {
                m_AppDate = value;
            }
        }

        public string AppTime
        {
            get
            {
                return m_AppTime;
            }

            set
            {
                m_AppTime = value;
            }
        }

        public string PatientName
        {
            get
            {
                return m_PatientName;
            }

            set
            {
                m_PatientName = value;
            }
        }

        public string DoctorName
        {
            get
            {
                return m_DoctorName;
            }

            set
            {
                m_DoctorName = value;
            }
        }

        public DateTime BookingDate
        {
            get
            {
                return m_BookingDate;
            }

            set
            {
                m_BookingDate = value;
            }
        }

        public string BookingTime
        {
            get
            {
                return m_BookingTime;
            }

            set
            {
                m_BookingTime = value;
            }
        }


        public Boolean CheckApp()//declares mathod
        {
            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;//opens up connection to sql database
            Boolean CheckAppYN = false;
            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();
            SqlCommand cmAppointment = new SqlCommand();
            cmAppointment.Connection = cnTB;
            cmAppointment.CommandType = CommandType.Text;

            string DateString = m_AppDate.ToString("MM/dd/yyyy");//delcares the format the date varaible will be kept in  (days,months,year)
            cmAppointment.CommandText = "Select *  From tblAppointments where AppDate = '" + DateString + "' AND AppTime = '" + m_AppTime + "'";
            SqlDataReader drAppList = cmAppointment.ExecuteReader();
            if (drAppList.HasRows)
            {
                CheckAppYN = true;
            }
            else
            {
                CheckAppYN = false;
            }

            cnTB.Close();
            return CheckAppYN;
        }

        

        public void AddNewApp()//declares method
        {
            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;
            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();
            SqlCommand cmAppointment = new SqlCommand();
            cmAppointment.Connection = cnTB;
            cmAppointment.CommandType = CommandType.Text;

            SqlCommand cmd = new SqlCommand("AppointmentID");

            string DateString = m_AppDate.ToString("MM/dd/yyyy");

            cmAppointment.CommandText = "INSERT INTO tblAppointments(AppDate, AppTime) VALUES('" + DateString + "','" + m_AppTime + "')";
            cmAppointment.ExecuteNonQuery();

            cmAppointment.CommandText = "Select MAX(AppointmentID) FROM tblAppointments";
            m_AppointmentID = (int)cmAppointment.ExecuteScalar();

            cnTB.Close();
        }



        public void BookAppointment()
        {
            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;
            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();
            SqlCommand cmAppointment = new SqlCommand();
            string DateString = m_BookingDate.ToString("MM/dd/yyyy");

            cmAppointment.Connection = cnTB;
            cmAppointment.CommandType = CommandType.Text;

            cmAppointment.CommandText = "INSERT INTO tblAppointments(PatientName, DoctorName) VALUES('" + m_PatientName + "','" + m_DoctorName + "') where BookingDate == '" + DateString + "' AND BookingTime == '" + m_AppTime + "'";
            cmAppointment.ExecuteNonQuery();
        }
    }
}
