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
    public partial class Appointment : Form
    {

        String appTime;
        public Appointment()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateTimePicker1.Value.Date;//sets the start and end date of the schedule via user input 
            DateTime endDate = dateTimePicker2.Value.Date;
            if (endDate < startDate)
            {
                MessageBox.Show("The start date cannot be after the end date");//validation, message will be displayed of the end date chosen is before the start date 
            }

            DateTime currentDate = dateTimePicker1.Value.Date;

            while (currentDate <= endDate)
            {
                for (int a = 1; a < 12; a++)
                {
                    switch (a)//will create a schedule for each day spaning the 2 selected dates with the following times
                    {
                        case 1:
                            appTime = "09:30";
                            break;
                        case 2:
                            appTime = "10:00";
                            break;
                        case 3:
                            appTime = "10:30";
                            break;
                        case 4:
                            appTime = "11:00";
                            break;
                        case 5:
                            appTime = "11:30";
                            break;
                        case 6:
                            appTime = "13:00";
                            break;
                        case 7:
                            appTime = "13:30";
                            break;
                        case 8:
                            appTime = "14:00";
                            break;
                        case 9:
                            appTime = "14:30";
                            break;
                        case 10:
                            appTime = "15:00";
                            break;
                        case 11:
                            appTime = "15:30";
                            break;
                        
                    }//end switch

                    Appointments objApp = new Appointments();//calls method 

                    objApp.AppDate = currentDate;//will check these 2 variables in the database
                    objApp.AppTime = appTime;
                    Boolean isThereAppointment = objApp.CheckApp();//checks to see if a schedule for this date/time has already been created
                    if(isThereAppointment == false)//if there isnt already a schedule 
                    {
                        objApp.AddNewApp();//create a new schedule 

                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
