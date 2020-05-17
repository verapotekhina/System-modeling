using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Histogram
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        Random rnd = new Random();
        private double[] histogram(int a, int b, int c, int d, double h, double step, int numberOfIntervals)
        {
            int n = int.Parse(textBoxN.Text);

            double M = h; //максимум плотности распределения

            double[] masY = new double[numberOfIntervals];

            double R1;
            double R2;
            int count = 0;

            double sum = 0.0;
            

            for (var i = 0; i < n; i++)
            {
                //находим R1, R2
                R1 = a + (d - a)*rnd.NextDouble();
                R2 = M*rnd.NextDouble();
                double yByR1;

                //косое произведение векторов a (x1,y1) b(x2,y2)
                //x1*y2-x2*y1
                //координаты вектора х2-х1; у2-у1

                double x2 = b - a;
                double y2 = h;
                double x1 = R1 - a;
                double y1 = R2;

                if (R1 <= b)
                {
                    x2 = b - a;
                    y2 = h;
                    x1 = R1 - a;
                    y1 = R2;
                }
                    //yByR1 = h * (R1 - a) / (b - a);
                else if (R1 <= c)
                {
                    x2 = c - b;
                    y2 = -h/2;
                    x1 = R1 - b;
                    y1 = R2 - h;
                }
                    //yByR1 = (-h * (R1 - b) /(2 * (c - b))) + h;
                else
                {
                    x2 = d - c;
                    y2 = -h/2;
                    x1 = R1 - c;
                    y1 = R2-h/2;
                }
                //yByR1 = (-h * (R1 - c) / (2 * (d - c))) + h/2;
                double skewProduct = x1 * y2 - x2 * y1;

                if (skewProduct >= 0)
                {
                    var ind = Convert.ToInt32(Math.Floor(R1/step));
                    masY[ind]++;
                    count++;
                    sum = sum + R1;
                }
            }

            var mas = new double[numberOfIntervals];

            for (int i = 0; i < numberOfIntervals; i++)
                mas[i] = masY[i];

            for (var i = 0; i < numberOfIntervals; i++)
                masY[i] = masY[i] / count /step;

            textSum.Text = (sum / count).ToString();

            return masY;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBoxA.Text);
            int b = int.Parse(textBoxB.Text);
            int c = int.Parse(textBoxC.Text);
            int d = int.Parse(textBoxD.Text);
            double step = double.Parse(textBoxStep.Text);

            var numberOfIntervals = Convert.ToInt32((d - a) / step);

            double h = 2.0 / (-a - (b / 2) + c + (d / 2));

            double[] masX = new double[numberOfIntervals];

            for (var i = 0; i < numberOfIntervals; i++)
                masX[i] = (a + step) / 2 + i * step;

            double[] masY = histogram(a,b,c,d, h, step, numberOfIntervals);

            //double[][] mas = {masY};

            //chart1.ChartAreas[0].AxisY.Interval = 1;
            //chart1.Series(0).IsVisibleInLegend = False;
            //chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series["Teoretical"].Points.AddXY(a, 0);
            chart1.Series["Teoretical"].Points.AddXY(b, h);
            chart1.Series["Teoretical"].Points.AddXY(c, h/2);
            chart1.Series["Teoretical"].Points.AddXY(d, 0);

            chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.Series["Experimental"].IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.Minimum = a;
            chart1.ChartAreas[0].AxisX.Maximum = d;
            chart1.Series["Experimental"]["PointWidth"] = "0.97";

            chart1.Series["Experimental"].Points.DataBindXY(masX, masY);

            //chart1.Series["Teoretical"].Points.DataBindXY(masX, masY2);
            //chart1.Series["Teoretical"].BorderWidth(2);



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
