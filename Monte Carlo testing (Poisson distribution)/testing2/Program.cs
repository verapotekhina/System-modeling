using System;
using System.Collections.Generic;
using System.Linq;

namespace testing2
{
    class Program
    {
        static double[] arrIn;
        static double[] arrOut;
        static void Main(string[] args)
        {
            Console.Write("Введите n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите m: ");
            int m = int.Parse(Console.ReadLine());
            Console.Write("Введите ro: ");
            double ro = double.Parse(Console.ReadLine());
            double mu = 1;
            var step = 0.2;
            var count = Convert.ToInt32(ro / step);
            double[] masExpX = new double[count];
            double[] masExpY = new double[count];

            for (int i = 0; i < count; i++)
            {
                masExpX[i] = 0.01 + i * step;
                arrIn = randomArray(n, masExpX[i]);
                arrOut = randomArray(n, mu);
                List<int> k = countTasks(n, m);
                int[] tasks = k.ToArray();
                double mean = tasks.Average();
                masExpY[i] = mean;
                Console.WriteLine(masExpX[i].ToString() + "\t \t" + masExpY[i].ToString() + "\n");

            }

            //arrIn = randomArray(n, lambda);
            //arrIn = new double[4] { 0.1, 0.8, 0.3, 0.2};
            //arrOut = randomArray(n, mu);
            //arrOut = new double[4] { 0.6, 1.2, 0.5, 0.4 };
            /*for (var i = 0; i < arrIn.Length; i++)
            {
                Console.WriteLine(arrIn[i].ToString() + " " + arrOut[i].ToString() + "\n");
            }*/
            /*List<int> k = countTasks(n, m);
            int[] tasks = k.ToArray();
            double mean = tasks.Average();*/

            /*string strTasks = "";

            for (var i = 0; i < tasks.Length; i++)
                strTasks = strTasks + tasks[i].ToString() + " ";

            Console.WriteLine(strTasks + "\n" + mean);*/
            //Console.WriteLine(mean);
        }

        private static readonly Random rnd = new Random();
        private static double[] randomArray(int n, double coef)
        {
            //массив рандомных ДРОБНЫХ чисел по пуассноновскому распределению
            double[] R = new double[n];
            for (int i = 0; i < n; i++)
                R[i] = rnd.NextDouble();

            double[] arrRnd = new double[n];
            for (var i = 0; i < n; i++)
            {
                //arrRnd[i] = Math.Log(1 - R[i]) / (-coef);
                arrRnd[i] = Math.Round(Math.Log(1 - R[i]) / (-coef), 1);
            }
            return arrRnd;
        }

        private static List<int> countTasks(int n, int m)
        {
            //int[] k = new int[n];
            List<int> k = new List<int> { };
            int kCurr = 0;
            int[] turn = new int[m];
            double tCurr = 0; //текущее время
            double deltaT = 0.1;
            double tIn = arrIn[0]; //время входа следующей заявки
            double tOut = tIn + arrOut[0]; //время выхода первой заявки
            bool processor = false;
            int availablePlaces = m;
            int indAP = 0;
            int i = 0;
            int count = 0;
            int countOut = 0;
            int countIn = 0;

            while (true)
            {
                tCurr += deltaT;
                tCurr = Math.Round(tCurr, 1);
                //ДОБАВИТЬ ПОДСЧЁТ k[хм]-когда их считать то??
                //сначала проверяем всё про выход заявки из системы, а потом про вход
                //проверяем, равно ли текущее время времени выхода заявки из процессора
                //if (tCurr >= tOut)
                if ((tCurr >= tOut) && (countOut < countIn))
                {
                    kCurr--;
                    tOut = 10000000;
                    processor = false;
                    //Если текущее время равно времени выхода заявки
                    if (turn[0] != 0)
                    {
                        //если в очереди есть заявка,
                        //процессор тру, меняем время tOut, +1 кколичеству мест в очереди
                        processor = true;
                        tOut = tCurr + arrOut[turn[0]];
                        //i++; //???
                        availablePlaces++;
                        indAP--;
                        //сдвигаем очередь
                        for (int j = 0; j < turn.Length; j++)
                        {
                            if (j != turn.Length - 1)
                                turn[j] = turn[j + 1];
                            else
                                turn[j] = 0;
                        }
                    }

                    //если нет в очереди - ничего не делаем
                }

                if (tCurr >= tIn)
                {
                    //если текущее время равно времени входа заявки
                    //то проверяем процессор, очередь, либо теряем
                    if (processor == false)
                    {
                        //если процессор пуст, заявку в процессор (processor = true), меняем время tOut и tIn, i++
                        processor = true;
                        countIn++;
                        //если это первая заявка, то не прибавляем
                        if (i != 0)
                            tOut = tCurr + arrOut[i];
                        kCurr++;
                        //шагаем на следующую заявку
                        if (i == n - 1)
                        {
                            i++;
                            tIn = 1000000;
                        }

                        else if (i < n - 1)
                        {
                            i++;
                            tIn = tCurr + arrIn[i]; //типа уже новое время прихода новой заявки
                        }
                    }
                    else
                    {
                        //если процессор занят проверяем место в очереди
                        if (availablePlaces > 0)
                        {
                            //если место есть, то добавляем индекс заявки в очередь, -1 от количества свободных мест
                            turn[indAP] = i;
                            indAP++;
                            kCurr++;
                            availablePlaces--;

                            //шагаем на следующую заявку
                            if (i == n - 1)
                            {
                                tIn = 10000000;
                                i++;
                            }

                            else if (i < n - 1)
                            {
                                i++;
                                tIn = tCurr + arrIn[i]; //типа уже новое время прихода новой заявки
                            }
                        }
                        else
                        {
                            //если места нет - теряем заявку, i++
                            //шагаем на следующую заявку
                            if (i == n - 1)
                            {
                                tIn = 10000000;
                                i++;
                            }

                            else if (i < n - 1)
                            {
                                i++;
                                tIn = tCurr + arrIn[i]; //типа уже новое время прихода новой заявки
                            }
                        }
                    }
                }
                count++;
                if (count % 5 == 0)
                    k.Add(kCurr);
                if ((i == n) && (availablePlaces == m) && (processor == false))
                    break;
            }
            return k;
        }
    }
}