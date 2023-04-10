using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public event RadiusChangedDelegate RadiusChanged;

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (RadiusChanged != null)
                RadiusChanged(this, new RadiusEventArgs(trackBar1.Value));
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            RadiusChanged(this, new RadiusEventArgs(-1));
        }
    }
}
