using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potekhina_Vera___Monte_Carlo_method
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[] masX;
        double[] masTeorY;
        private double[] teorLine(int count, int m, double step)
        {
            masTeorY = new double[count];

            for (var i = 0; i < count; i++)
            {
                var x = masX[i];
                if (x == 1)
                {
                    x = x + step;
                    var nextX = (x / (1 - x)) - ((m + 2) * Math.Pow(x, m + 2) / (1 - Math.Pow(x, m + 2)));
                    masTeorY[i] = masTeorY[i - 1] + (nextX - masTeorY[i - 1]) / 2;
                }
                else
                    masTeorY[i] = (x / (1 - x)) - ((m + 2) * Math.Pow(x, m + 2) / (1 - Math.Pow(x, m + 2)));
            }
            return masTeorY;
        }
         private void button1_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textM.Text);
            int n = int.Parse(textN.Text);
            double ro = double.Parse(textRo.Text);
            var step = 0.2;
            var count = Convert.ToInt32(ro / step) + 1;

            masX = new double[count];
            for (int i = 0; i < count; i++)
                masX[i] = 0.01 + i * step;
            teorLine(count, m, step);
            double[] masExpY = Class1.MethodForCallingTheCountsTasks(n,m,ro,masTeorY,step,count);
            double[] masMSD = Class1.MethodForCallingTheMeanSquareDeviation();

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = ro;
            chart1.Series["Theoretical line"].Points.DataBindXY(masX, masTeorY);
            chart1.Series["Experiment"].Points.DataBindXY(masX, masExpY);
            chart1.Series["MSD"].Points.DataBindXY(masX, masMSD);
        }
    }
}
