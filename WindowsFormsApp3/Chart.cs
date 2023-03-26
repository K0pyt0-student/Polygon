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
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        public void DrawChart(double[] timesArr)//1-только джарвиз, 2 - только поОпр, 3 - оба
        {
            for (int i = 0; i < timesArr.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i * 100, timesArr[i]);
            }
        }

        public void DrawChart(double[] timesArr_j, double[] timesArr_b)
        {
            for (int i = 0; i < timesArr_j.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i * 100, timesArr_j[i]);
            }
            for (int i = 0; i < timesArr_b.Length; i++)
            {
                chart1.Series[0].Points.AddXY(i * 100, timesArr_b[i]);
            }
        }

    }
}
