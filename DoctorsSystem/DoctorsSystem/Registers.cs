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
    public partial class Registers : Form
    {
        public Registers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Registers would be dispaleyd for specific date");//A pop up message box will be displayed to the user upon clicking thus button 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("New register would be created ");
        }
    }
}
