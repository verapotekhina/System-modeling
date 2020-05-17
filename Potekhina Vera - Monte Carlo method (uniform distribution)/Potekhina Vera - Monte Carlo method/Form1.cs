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
        private void teorParabola(int alfa, int betta, int A, int B, int nX, double step)
        {
            masX = new double[nX];
            masY = new double[nX];


            for (var i = 0; i < nX; i++)
            {
                masX[i] = A + step * i;
                var x = masX[i];
                var chisl = (alfa * (x - A) * (x - A) + betta * (x - B) * (x - B));
                masY[i] = chisl / (2 * (B - A));
            }

            double minTeorX = 0.0;
            double minTeorY = 1000000.0;
            minimumMonteCarlo(masX, masY, ref minTeorX, ref minTeorY);
            textMinTeorX.Text = minTeorX.ToString();
            textMinTeorY.Text = minTeorY.ToString();
        }

        private double monteCarlo(int alfa, int betta, int A, int B, double xi, int i, int nX)
        {
            var nq = 100;
            var arrRnd = randomArray(A, B, nq);
            masQ = new double[nq];
            double sum = 0;

            for (int j = 0; j < nq; j++)
            {
                if (arrRnd[j] < xi)
                    masQ[j] = alfa * (xi - arrRnd[j]);
                else
                    masQ[j] = betta * (arrRnd[j] - xi);
                sum += masQ[j];

            }
            meanSquareDeviation(i, nX);
            return sum / nq;

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

        private void meanSquareDeviation(int indX, int nX) //надо передать индекс x
        {
            double sumMSD = 0;
            //сюда мы зайдем для каждого х
            for (var i = 0; i < masQ.Length; i++)
            {
                var qMSD = (masQ[i] - masY[indX]) * (masQ[i] - masY[indX]);
                sumMSD += qMSD;
            }
            masMSD[indX] = Math.Sqrt(sumMSD / (masQ.Length - 1));
        }

        private static readonly Random rnd = new Random();
        private double[] randomArray(int A, int B, int nq)
        {
            //массив рандомных ДРОБНЫХ чисел
            
            
            double[] arrRnd = new double[nq];
            for (int i = 0; i < nq; i++)
                arrRnd[i] = A + (B - A) * rnd.NextDouble();
            return arrRnd;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int alfa = int.Parse(textAlfa.Text);
            int betta = int.Parse(textBetta.Text);
            int A = int.Parse(textA.Text);
            int B = int.Parse(textB.Text);

            var step = 0.2;
            var nX = Convert.ToInt32((B - A) / step + 1);

            teorParabola(alfa, betta, A, B, nX, step);
            masMCY = new double[nX];
            masMSD = new double[nX];

            for (var i = 0; i < nX; i++)
            {
                var xi = masX[i];
                masMCY[i] = monteCarlo(alfa, betta, A, B, xi, i, nX);
            }

            double minX = 0.0;
            double minY = 1000000.0;
            minimumMonteCarlo(masX, masMCY, ref minX, ref minY);
            textMinX.Text = minX.ToString();
            textMinQ.Text = minY.ToString();

            chart1.ChartAreas[0].AxisX.Minimum = int.Parse(textA.Text);
            chart1.ChartAreas[0].AxisX.Maximum = int.Parse(textB.Text);
            chart1.Series["Parabola"].Points.DataBindXY(masX, masY);
            chart1.Series["Monte Carlo"].Points.DataBindXY(masX, masMCY);

            //for (var i = 0; i < masMSD.Length; i++)


            var strMSD = "";
            for (var i = 0; i < masMSD.Length; i++)
                strMSD = strMSD + Convert.ToString(masMSD[i]) + " ";

            //textBox1.Text = Convert.ToString(masQ[0] + " " + masY[0]);
            chart1.Series["MSD"].Points.DataBindXY(masX, masMSD);
        }
    }
}
