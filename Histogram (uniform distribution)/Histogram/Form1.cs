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

        int step = 1; //было без заданного значения
        double teorP;
        private double[] histogram()
        {
            
            int n = int.Parse(textBox1.Text);
            int down = int.Parse(textBox2.Text);
            int high = int.Parse(textBox3.Text);
            int count = int.Parse(textBox3.Text) - int.Parse(textBox2.Text); //тут было +1
            //step = nod(count);
            teorP = 1/((double)count / step);
            //double teorP = count / step;
            textBox5.Text = Convert.ToString(Math.Round(teorP,4));

            double[] lst = new double[n];

            //список диапазонов
            //int size2 = Convert.ToInt32((high - down) / step + 1);
            int size2 = Convert.ToInt32((high - down)); //для интервалов
            double[] lst2 = new double[size2];
            for (int i = 0; i < size2; i++)
            {
                lst2[i] = 0;
            }

            //массив рандомных ДРОБНЫХ чисел
            Random rnd = new Random();
            for (int ctr = 0; ctr < n; ctr++)
                lst[ctr] = down + (high-down)*rnd.NextDouble();

            double min = down;
            double max = down + step;

            for (int i = 0; i < lst2.Length; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((lst[j] >= min) && (lst[j] < max))
                    {
                        lst2[i]++;
                    }
                }
                min += step;
                max += step;
            }
           
            for (int i = 0; i < lst2.Length; i++)
            {
                lst2[i] = Math.Round(lst2[i] / n,4);
            }

            double[] masY = lst2;
            return masY;
        }

        private int nod(int count)
        {
            for (int i = 2; i < count / 2; i++)
            {
                if (count % i == 0)
                    return i;
            }
            return 1;
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            double[] masY = histogram();

            double[][] mas = {masY};
            
            int count = Convert.ToInt32((int.Parse(textBox3.Text) - int.Parse(textBox2.Text))/ step);

            double[] masX = new double[count];

            masX[0] = (double)step / 2 + int.Parse(textBox2.Text);

            /*if ((double.Parse(textBox2.Text) + step) % 2 == 0)
                masX[0] = (double.Parse(textBox2.Text) + step) / 2 + 0.5;
            else
                masX[0] = (double.Parse(textBox2.Text) + step - 1) / 2;*/


            ////
            for (int i = 1; i < count; i++)
                masX[i] = masX[i-1] + step;

            textBox4.Text = step.ToString();

            /*for (int i = 0; i < masX.Length; i++)
                textBox6.Text = textBox6.Text + masX[i].ToString();

            for (int i = 0; i < masY.Length; i++)
                textBox7.Text = textBox7.Text + masY[i].ToString();*/
            double[] masY2 = new double[masY.Length];
            for (int i = 0;  i < masY.Length; i++)
            {
                masY2[i] = Math.Round(teorP,4);
            }

            //chart1.ChartAreas[0].AxisY.Interval = 1;
            //chart1.Series(0).IsVisibleInLegend = False;
            //chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series["Teoretical"].Points.AddXY(int.Parse(textBox2.Text)-1, teorP);
            chart1.Series["Teoretical"].Points.AddXY(int.Parse(textBox3.Text)+1, teorP);

            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.Series["Experimental"].IsValueShownAsLabel = true;
            //chart1.ChartAreas.
            chart1.ChartAreas[0].AxisX.Minimum = int.Parse(textBox2.Text);
            chart1.ChartAreas[0].AxisX.Maximum = int.Parse(textBox3.Text);
            chart1.Series["Experimental"]["PointWidth"] = "0.97";

            chart1.Series["Experimental"].Points.DataBindXY(masX, mas);

            //chart1.Series["Teoretical"].Points.DataBindXY(masX, masY2);
            //chart1.Series["Teoretical"].BorderWidth(2);



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
