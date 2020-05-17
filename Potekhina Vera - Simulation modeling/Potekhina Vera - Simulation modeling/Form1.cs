using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Potekhina_Vera___Simulation_modeling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var lumba = int.Parse(textBox1.Text);
            //var mu = int.Parse(textBox2.Text);
            var m = int.Parse(textBox3.Text);

            var ro = int.Parse(textBox4.Text);
            var step = 0.1;
            var count = Convert.ToInt32(ro / step);

            double[] masX = new double[count+1];
            double[] masY = new double[count+1];

            

            for (var i = 0; i < count+1; i++)
            {
                var x = i * step;
                
                masX[i] = x;
                if (x == 1)
                {
                    //var str = -(Math.Pow(x, m + 2) / (1 - x)) + ((1 - Math.Pow(x, m + 2)) * x / ((1 - x) * (1 - x) * (m + 2)));
                    x = x + step;
                    var nextX = (x / (1 - x)) - ((m + 2) * Math.Pow(x, m + 2) / (1 - Math.Pow(x, m + 2)));
                    masY[i] = masY[i - 1] + (nextX - masY[i - 1]) / 2;


                }
                else
                    masY[i] = (x / (1 - x)) - ((m + 2) * Math.Pow(x, m + 2) / (1 - Math.Pow(x, m + 2)));
                //masY[i] = (x / (1 - Math.Pow(x, m + 2))) * ((1 - (m + 2 - x * m - x) * Math.Pow(x, m + 1)) / (1 - x));

            }

            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Maximum = ro;

            chart1.Series["N(ro,m)"].Points.DataBindXY(masX, masY);
        }
    }
}
