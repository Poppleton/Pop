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
    class Patients
    {
        private int m_PatientID;
        private string m_PatientName;
        private int m_PatientAge;
        private string m_Gender;
        private string m_Address;
        private string m_Number;
        private string m_PostCode;
        private string m_DOB;
        private string m_Notes;
        

        public int PatientID//thi will declare the variables to be used and there variable type
        {
            get
            {
                return m_PatientID;
            }

            set
            {
                m_PatientID = value;
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


        public int PatientAge
        {
            get
            {
                return m_PatientAge;
            }

            set
            {
                m_PatientAge = value;
            }
        }


        public string Gender
        {
            get
            {
                return m_Gender;
            }

            set
            {
                m_Gender = value;
            }
        }


        public string Address
        {
            get
            {
                return m_Address;
            }

            set
            {
                m_Address = value;
            }
        }


        public string Number
        {
            get
            {
                return m_Number;
            }

            set
            {
                m_Number = value;
            }
        }


        public string PostCode
        {
            get
            {
                return m_PostCode;
            }

            set
            {
                m_PostCode = value;
            }
        }

        public string DOB
        {
            get
            {
                return m_DOB;
            }

            set
            {
                m_DOB = value;
            }
        }

        public string Notes
        {
            get
            {
                return m_Notes;
            }

            set
            {
                m_Notes = value;
            }
        }



        public void GetPatientByPatientID(int PatientID)
        {
            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;

            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();
            SqlCommand cmPatient = new SqlCommand();
            cmPatient.Connection = cnTB;
            cmPatient.CommandType = CommandType.Text;
            cmPatient.CommandText = "Select PatientID, PatientName, PatientAge, Gender, Address, ContactNumber, PostCode, DOB, Notes from tblPatients where PatientID = '" + PatientID + "'";//get information fro these databse columns where the PatientID = what was entered by the user 
            SqlDataReader drPatientList = cmPatient.ExecuteReader();
            if (!drPatientList.HasRows)
            {
                throw new Exception("Patient Not Found");
            }
            else
            {
                drPatientList.Read();
                m_PatientID = (int)drPatientList[0];
                m_PatientName = drPatientList[1].ToString();
                m_PatientAge = (int)drPatientList[2];
                m_Gender = drPatientList[3].ToString();
                m_Address = drPatientList[4].ToString();
                m_Number = drPatientList[5].ToString();
                m_PostCode = drPatientList[6].ToString();
                m_DOB = drPatientList[7].ToString();
                m_Notes = drPatientList[8].ToString();
            }
        }


        public void AddNewPatient()
        {
            
            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;

            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();//open connection
            SqlCommand cmPatient = new SqlCommand();
            cmPatient.Connection = cnTB;
            cmPatient.CommandType = CommandType.Text;

            cmPatient.CommandText = "INSERT INTO tblPatients(PatientName, PatientAge, Gender, Address, ContactNumber, PostCode, DOB, Notes) VALUES ('" + PatientName + "','" + PatientAge + "','" + Gender + "','" + Address + "','" + Number + "','" + PostCode + "','" + DOB + "','" + Notes + "')";//insert into these database columns the follwing values
            cmPatient.ExecuteNonQuery();//perform command given above
            

            //read the last Patient
            cmPatient.CommandText = "Select MAX(PatientID) FROM tblPatients";//assign new patient with an patient ID, ID numbers will increase incrementally with each new patient 
            int m_PatientID = (int)cmPatient.ExecuteScalar();

            cnTB.Close();//close connection
            
        }


        public void UpdatePatient(DataSet dsPatient)
        {

            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;

            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();
            SqlCommand cmPatient = new SqlCommand();
            cmPatient.Connection = cnTB;
            cmPatient.CommandType = CommandType.Text;
            cmPatient.CommandText = "Select * from tblPatients";
            SqlDataAdapter daPatient = new SqlDataAdapter(cmPatient);

            SqlCommandBuilder builder = new SqlCommandBuilder(daPatient);
            builder.GetUpdateCommand();

            daPatient.Update(dsPatient);
            cnTB.Close();
            return;

        }

        
        
        
        
        
        public void DeletePatient()
        {
            string SGConnectionString = ConfigurationManager.ConnectionStrings["SurgeryConnectionString"].ConnectionString;

            SqlConnection cnTB = new SqlConnection(SGConnectionString);
            cnTB.Open();
            SqlCommand cmPatient = new SqlCommand();
            cmPatient.Connection = cnTB;
            cmPatient.CommandType = CommandType.Text;

            cmPatient.CommandText = "REMOVE FROM tblPatients(PatientName, PatientAge, Gender, Address, ContactNumber, PostCode, DOB, Notes) VALUES ('" + PatientName + "','" + PatientAge + "','" + Gender + "','" + Address + "','" + Number + "','" + PostCode + "','" + DOB + "','" + Notes + "')";
            cmPatient.ExecuteNonQuery();

  
            cnTB.Close();
        }

    }
}
