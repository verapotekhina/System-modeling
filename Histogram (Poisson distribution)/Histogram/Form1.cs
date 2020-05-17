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
        double[] masTau;
        double[] masTeorTau;
        private double[] TeoreticalLine(double lambda, double tauMax, double tauMin, double dTau)
        {
            int nTeor = Convert.ToInt32(tauMax / dTau);
            masTeorTau = new double[nTeor];
            double[] masTeorY = new double[nTeor];

            for (int i = 0; i < nTeor; i++)
            {
                masTeorTau[i] = i * dTau;
            }

            var tau = tauMin;
            for (int i = 0; i < nTeor; i++)
            {
                masTeorY[i] = lambda * Math.Exp(-lambda * tau);
                tau += dTau;
            }
            return masTeorY;
        }

        private double[] RandomNumber(int n)
        {
            double[] R = new double[n];
            for (int i = 0; i < n; i++)
                R[i] = rnd.NextDouble();
            return R;
        }
        private double[] histogram(int countColumns, double lambda, double tauMax, double tauMin, double dTau, int n)
        {
            double[] masD = new double[n];
            double[] masExpY = new double[countColumns];

            for (int i = 0; i < masExpY.Length; i++)
                masExpY[i] = 0.0;

            for (var i = 0; i < n; i++)
            {
                var R = RandomNumber(n);
                masD[i] = Math.Log(1 - R[i]) / (-lambda);
            }
            // int column = 0;
            for (double i = tauMin, column = 0; i < tauMax; i += dTau, column++)
            {
                double leftTau = i;
                double rightTau = i + dTau;

                for (var j = 0; j < masD.Length; j++)
                {
                    var column1 = Convert.ToInt32(column);
                    if ((masD[j] > leftTau) && (masD[j] < rightTau))
                        masExpY[column1] += 1;
                }
                //column++;
            }

            for (int i = 0; i < masExpY.Length; i++)
                masExpY[i] = masExpY[i] / n/dTau;

            return masExpY;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBoxN.Text);
            double dTau = double.Parse(textBoxDeltaTau.Text);
            double lambda = double.Parse(textBoxLambda.Text);

            double tauMin = 0.0;
            int countColumns = 20;
            double tauMax = dTau * countColumns;
            masTau = new double[countColumns];
            

            for (var i = 0; i < countColumns; i++)
                masTau[i] = dTau/2 + i * dTau;

            double[] masExpY = histogram(countColumns, lambda, tauMax, tauMin, dTau, n);
            double[] masTeorY = TeoreticalLine(lambda, tauMax, tauMin, dTau);

            //double[][] mas = {masY};

            //chart1.ChartAreas[0].AxisY.Interval = 1;
            //chart1.Series(0).IsVisibleInLegend = False;
            //chart1.Series[0].IsVisibleInLegend = false;

            chart1.ChartAreas[0].AxisX.Interval = 1;
            //chart1.Series["Experimental"].IsValueShownAsLabel = true;

            chart1.ChartAreas[0].AxisX.Minimum = tauMin;
            chart1.ChartAreas[0].AxisX.Maximum = tauMax;
            chart1.Series["Experimental"]["PointWidth"] = "0.95";

            chart1.Series["Experimental"].Points.DataBindXY(masTau, masExpY);
            chart1.Series["Teoretical"].Points.DataBindXY(masTeorTau, masTeorY);

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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
