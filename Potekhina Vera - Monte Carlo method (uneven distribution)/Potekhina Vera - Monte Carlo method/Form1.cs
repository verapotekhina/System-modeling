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
        double[] masY;
        double[] masMCY;
        double[] masMSD;
        double[] masQ;

        private void teorParabola(int alfa, int betta, int a, int d, int nX, double step)
        {
            masX = new double[nX];
            masY = new double[nX];


            for (var i = 0; i < nX; i++)
            {
                masX[i] = a + step * i;
                var x = masX[i];
                var chisl = (alfa * (x - a) * (x - a) + betta * (x - d) * (x - d));
                masY[i] = chisl / (2 * (d - a));
            }
            double minTeorX = 0.0;
            double minTeorY = 1000000.0;
            minimumMonteCarlo(masX, masY, ref minTeorX, ref minTeorY);
            textMinTeorX.Text = minTeorX.ToString();
            textMinTeorY.Text = minTeorY.ToString();

            
        }

        private double monteCarlo(int alfa, int betta, int a, int b, int c, int d, double h, double xi, int i)
        {
            var n = int.Parse(textN.Text); //количество чисел для генерации
            int count = 0;
            var arrRnd = randomArray(a, b, c, d, n, h, ref count);
            masQ = new double[count];
            double sum = 0;

            for (int j = 0; j < count; j++)
            {
                if (arrRnd[j] < xi)
                    masQ[j] = alfa * (xi - arrRnd[j]);
                else
                    masQ[j] = betta * (arrRnd[j] - xi);
                sum += masQ[j];

            }
            double averageQ = sum / count;
            meanSquareDeviation(i, averageQ);
            return averageQ;

        }

        private void meanSquareDeviation(int indX, double averageQ) //надо передать индекс x
        {
            double sumMSD = 0;
            //сюда мы зайдем для каждого х
            for (var i = 0; i < masQ.Length; i++)
            {
                var qMSD = (masQ[i] - averageQ) * (masQ[i] - averageQ);
                sumMSD += qMSD;
            }
            masMSD[indX] = Math.Sqrt(sumMSD / (masQ.Length - 1));
        }

        private void minimumMonteCarlo(double[] masX, double[] masYMC, ref double minX, ref double minY)
        {
            for (var i = 0; i < masYMC.Length; i++)
            {
                if (masYMC[i] < minY)
                {
                    minY = masYMC[i];
                    minX = masX[i];
                }                
            }
        }

        private static readonly Random rnd = new Random();
        private double[] randomArray(int a, int b, int c, int d, int n, double h, ref int count)
        {
            //массив рандомных ДРОБНЫХ чисел
            
            double[] arrRnd = new double[n];

            double M = h; //максимум плотности распределения

            double R1;
            double R2;

            for (var i = 0; i < n; i++)
            {
                //находим R1, R2
                R1 = a + (d - a) * rnd.NextDouble();
                R2 = M * rnd.NextDouble();
                //double yByR1;

                //косое произведение векторов a (x1,y1) b(x2,y2)
                //x1*y2-x2*y1
                //координаты вектора х2-х1; у2-у1

                double x2;
                double y2;
                double x1;
                double y1;

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
                    y2 = -h / 2;
                    x1 = R1 - b;
                    y1 = R2 - h;
                }
                //yByR1 = (-h * (R1 - b) /(2 * (c - b))) + h;
                else
                {
                    x2 = d - c;
                    y2 = -h / 2;
                    x1 = R1 - c;
                    y1 = R2 - h / 2;
                }
                //yByR1 = (-h * (R1 - c) / (2 * (d - c))) + h/2;
                double skewProduct = x1 * y2 - x2 * y1;

                if (skewProduct >= 0)
                {
                    arrRnd[count] = R1;
                    count++;
                }
            }

            return arrRnd;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int alfa = int.Parse(textAlfa.Text);
            int betta = int.Parse(textBetta.Text);
            int a = int.Parse(textA.Text);
            int b = int.Parse(textB.Text);
            int c = int.Parse(textC.Text);
            int d = int.Parse(textD.Text);
            var step = 0.1;

            double h = 2.0 / (-a - (b / 2) + c + (d / 2));


            var nX = Convert.ToInt32((d - a) / step + 1);

            masMCY = new double[nX]; //массив игреков монте карло
            masMSD = new double[nX];

            teorParabola(alfa, betta, a, d, nX, step);

            masX = new double[nX];

            for (var i = 0; i < nX; i++)
            {
                masX[i] = a + step * i;
            }

            for (var i = 0; i < nX; i++) //для каждого x запускается метод монте карло
            {
                var xi = masX[i];
                masMCY[i] = monteCarlo(alfa, betta, a, b, c, d, h, xi, i);
            }
            double minX = 0.0;
            double minY = 1000000.0;
            minimumMonteCarlo(masX, masMCY, ref minX, ref minY);
            textMinX.Text = minX.ToString();
            textMinQ.Text = minY.ToString();


            chart1.ChartAreas[0].AxisX.Minimum = a;
            chart1.ChartAreas[0].AxisX.Maximum = d;
            //chart1.Series["Parabola"].Points.DataBindXY(masX, masY);
            chart1.Series["Monte Carlo"].Points.DataBindXY(masX, masMCY);
            chart1.Series["Theoretical"].Points.DataBindXY(masX, masY);
            

            //for (var i = 0; i < masMSD.Length; i++)


            var strMSD = "";
            for (var i = 0; i < masMSD.Length; i++)
                strMSD = strMSD + Convert.ToString(masMSD[i]) + " ";

            //textBox1.Text = Convert.ToString(masQ[0] + " " + masY[0]);
            chart1.Series["MSD"].Points.DataBindXY(masX, masMSD);
        }
    }
}
