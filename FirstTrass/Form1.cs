using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstTrass
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Скорость РН 
        /// </summary>
        public static double V, V0;
        /// <summary>
        /// Высота
        /// </summary>
        public static double H, H0;
        /// <summary>
        /// Плотность воздуха
        /// </summary>
        public static double po;
        /// <summary>
        /// Атмосферное давление
        /// </summary>
        public static double P;
        /// <summary>
        /// Температура окружающей среды
        /// </summary>
        public static double T;
        /// <summary>
        /// Скорость звука
        /// </summary>
        public static double a;
        /// <summary>
        /// Угол атаки
        /// </summary>
        public static double alpha, alpha0, alpha1, alpha2;
        /// <summary>
        /// Тяга двигательной установки
        /// </summary>
        public static double PENG, PENG1, PENG2, PENG3;
        /// <summary>
        /// Секундный расход топлива
        /// </summary>
        public static double dM;
        /// <summary>
        /// Радиус Земли
        /// </summary>
        public static double R;
        /// <summary>
        /// Скорость истечения газов из двигателя
        /// </summary>
        public static double w, w1, w2, w3;
        /// <summary>
        /// Стартовая масса РН
        /// </summary>
        public static double M1;
        /// <summary>
        /// Угол наклона вектора скорости к местному горизонту
        /// </summary>
        public static double Y, Y0;
        /// <summary>
        /// Текущая масса РН
        /// </summary>
        public static double m;
        /// <summary>
        /// Коэффициент лобового сопротивления
        /// </summary>
        public static double CX;
        /// <summary>
        /// Производная коэффициента подъемной силы
        /// </summary>
        public static double CY;
        /// <summary>
        /// Площадь Миделя РН
        /// </summary>
        public static double S;
        /// <summary>
        /// Ускорение свободного падения
        /// </summary>
        public static double g;
        /// <summary>
        /// Начальный полярный угол
        /// </summary>
        public static double N, N0;
        /// <summary>
        /// Шаг дифференцирования (шаг времени)
        /// </summary>
        public static double t;
        /// <summary>
        /// Время полета от начала пуска
        /// </summary>
        public static double time;
        /// <summary>
        /// Число Маха
        /// </summary>
        public static double Mah;

        private void button3_Click(object sender, EventArgs e)
        {
            new Form3().Show();
            this.Hide();
        }

        /// <summary>
        /// Время начала пуска
        /// </summary>
        public static double t0;
        /// <summary>
        /// Максимальный диаметр блока РН
        /// </summary>
        public static double D;
        /// <summary>
        /// Время отделения ступени
        /// </summary>
        public static double T1, T2, T3;
        /// <summary>
        /// Угол наклона траектории (программный)
        /// </summary>
        public static double Ott;
        /// <summary>
        /// Угол тангажа
        /// </summary>
        public static double U;
        /// <summary>
        /// Угол наклона траектории (реальный)
        /// </summary>
        public static double ER, ER0;
        /// <summary>
        /// Координата РН
        /// </summary>
        public static double x,y;
        /// <summary>
        /// Масса топлива
        /// </summary>
        public static double mt1, mt2, mt3;
        /// <summary>
        /// Точка разделения
        /// </summary>
        public static bool stage1, stage2, stage3;

        private void button1_Click(object sender, EventArgs e)
        {
            /// Объявление глобальных констант
            D = 5;
            g = 9.81;
            S = Math.PI * Math.Pow((D/2), 2);
            //w = 3000;
            //PENG = 2800*4000;
            M1 = 847350;
            H0 = 0; 
            Y0 = Math.PI/2;
            //dM = PENG / w;
            V0 = 0.1;
            R = 6371000;
            N0 = 0;
            t0 = 0;
            alpha0 = 0;
            t = 1;
            
            x = 0;
            y = 0;
            /// Объявление коэффициентов угла атаки
            alpha1 = Convert.ToDouble(textBox8.Text);
            alpha2 = Convert.ToDouble(textBox9.Text);
            mt1 = 542500;
            mt2 = 171450;
            mt3 = 44275;
            w1 = Form3.w1;
            w2 = 3400;
            w3 = 3500;
            PENG1 = 2800 * 4000;
            PENG2 = 3200000;
            PENG3 = 820000;
            
            /*
            T1 = Math.Ceiling(mt1 / (PENG1 / w1));
            T2 = Math.Floor(T1 + mt2 / (PENG2 / w2));
            T3 = Math.Ceiling(T2 + mt3 / (PENG3 / w3));
            */
            /*
            T1 = Math.Round(mt1 / (PENG1 / w1),1);
            T2 = Math.Round(T1 + mt2 / (PENG2 / w2),1);
            T3 = Math.Round(T2 + mt3 / (PENG3 / w3),1);
            */
            T1 = (mt1 / (PENG1 / w1));
            T2 = (T1 + mt2 / (PENG2 / w2));
            T3 = (T2 + mt3 / (PENG3 / w3));

            textBox10.Text = Convert.ToString(T1);
            textBox11.Text = Convert.ToString(T2);
            textBox12.Text = Convert.ToString(T3);
            /// Система дифференциальных уравнений движения РН
            double dV(double vv, double ii)
            {
                return (PENG ) / m - CX * S * po * Math.Pow(vv, 2) / (2 * m) - g * Math.Sin(ii);  
               
            }
            double dY(double hh, double vv, double ii)
            {
                return (PENG * Math.PI * alpha / 180) / (m*vv) + (CY * ((Math.PI * alpha) / 180) * S * (po * Math.Pow(vv, 2)) / 2) / (m*vv) - ((g * (1 - Math.Pow(vv, 2) / (g * (R+hh))) * Math.Cos(ii)))/vv;
                
            }
            double dN(double hh, double vv, double ii)
            {
                return (vv /(R+hh))* Math.Cos(ii);
            }
            double dH(double vv, double ii)
            {
                return vv * Math.Sin(ii);
            }
            /// Объявление начальных значений параметров
            V = V0;
            H = H0;
            m = M1;
            time = t0;
            Y = Y0;
           
            alpha = alpha0;
            N = N0;
            U = Y - N + Math.PI*alpha/180;
            stage1 = true;
            stage2 = true;
            stage3 = true;

            /// Создание графиков
            chart1.Series[0].Points.Clear();
            chart2.Series[0].Points.Clear();
            chart3.Series[0].Points.Clear();
            chart4.Series[0].Points.Clear();
            chart5.Series[0].Points.Clear();
            chart6.Series[0].Points.Clear();
            chart7.Series[0].Points.Clear();
            chart9.Series[0].Points.Clear();
            chart8.Series[0].Points.Clear();

            chart1.Series[0].Points.AddXY(time, m);
            chart4.Series[0].Points.AddXY(time, V);
            chart6.Series[0].Points.AddXY(time, H);
            chart5.Series[0].Points.AddXY(time, N);
            chart3.Series[0].Points.AddXY(time, Y);
            chart7.Series[0].Points.AddXY(time, Ott);
            chart9.Series[0].Points.AddXY(time, U);
            chart8.Series[0].Points.AddXY(x, y);

            /// Задание параметров каждой ступени

            while (time < T3+1)
            {
                if (time <= T1)
                {


                    PENG = PENG1;
                    w = w1;
                    dM = PENG1 / w1;

                }

                if (time > T1 && time <= T2)
                {
                    if (stage1)
                    {
                        m -= 38750;
                        stage1 = false;
                    }
                    //m -= 38750;
                    PENG = PENG2;
                    w = w2;
                    dM = PENG2 / w2;
                }

                if (time > T2 && time <= T3)
                {
                    if (stage2)
                    {
                        m -= 19050;
                        stage2 = false;
                    }
                    //m -= 19050;
                    PENG = PENG3;
                    w = w3;
                    dM = PENG3 / w3;
                }

                if (time > T3) 
                {
                    //m -= 6325;
                    if (stage3)
                    {
                        m -= 6325;
                        stage3 = false;
                    }
                    //PENG = 0;
                    //w = 0;
                    dM = 0;
                }
                /// Введение атмосферы
                if (H < 90000)
                {
                    /// Аппроксимирующие функции параметров атмосферы
                    T = -0.000000000001498 * Math.Pow(H, 3) + 0.0000001776 * Math.Pow(H, 2) - 0.005346 * H + 272.2;
                    po = Math.Exp(0.3158 - 0.0001391 * H);
                    P = Math.Exp(11.53 - 0.0001438 * H);
                    a = -0.0000000000009735 * Math.Pow(H, 3) + 0.0000001149 * Math.Pow(H, 2) - 0.003443 * H + 330.85;
                    /// Коэффициенты аэродинамической силы
                    Mah = V / a;
                    if (Mah <= 0.8)
                    {
                        CX = 0.29;
                    }
                    else
                    {
                        if (Mah >= 1.068)
                        {
                            CX = 0.091 + 0.5 / Mah;
                        }
                        else
                        {
                            CX = Mah - 0.51;
                        }
                    }
                    if (Mah <= 0.25)
                    {
                        CY = 2.8;
                    }
                    else
                    {
                        if (Mah >= 3.6)
                        {
                            CY = 3.55;
                        }
                        else
                        {
                            if (Mah > 0.25 && Mah <= 1.1)
                            {
                                CY = 2.8 + 0.447 * (Mah - 0.25);
                            }
                            else
                            {
                                if (Mah > 1.1 && Mah <= 1.6)
                                {
                                    CY = 3.18 - 0.66 * (Mah - 1.1);
                                }
                                else
                                {
                                    CY = 2.85 - 0.35 * (Mah - 1.6);
                                }
                            }
                        }
                    }
                }
                else
                    T = 0;
                    po = 0;
                    P = 0;
                    a = 0;
                    CX = 0;
                    CY = 0;

                //Решение дифференциальных уравнений методом Эйлера
                H += t * dH(V, Y);
                V += t * dV(V, Y);
                Y += t * dY(H, V, Y);
                N += t * dN(H, V, Y) ;
                


                x += t * V* Math.Cos(Y);
                y += t * V* Math.Sin(Y);

                /// Расчет угла тангажа
                U = Y - N + Math.PI*alpha/180;
                ER = Y - N;

                // Программа изменения угла атаки
                if (time > 15 && time < 20)
                {
                    alpha = alpha1;
                }
                else

                if (time >= T1)
                {
                    alpha = alpha2 * Math.Sqrt((time - T1));
                }
                else
                alpha = alpha0;
                /// Программа изменения угла наклона траектории
                
                if (time < 15)
                    Ott = 90;
                else
                if (time >= 15 && time<=T1)
                    Ott = (90 - 30) * Math.Pow((T1 - time), 2) / Math.Pow((T1- 15), 2) + 30;
                else
                    if (time > T1 && time <= T2)
                    Ott = 30-(30-0.2*30)*(time - T1)/(T2-T1);
                else
                    if (time > T2 && time <= T3)
                    Ott = 0.2 * 30 - (0.2 * 30 - 0) * (time - T2) / (T3 - T2);
                else
                    Ott = 90;
                


                /// Время полета
                time += t;
                /// Изменение массы РН
                
                m -= t * dM;
                /// Вывод результатов моделирования на графиках
                chart1.Series[0].Points.AddXY(time, m);
                chart1.ChartAreas[0].AxisX.Title = "t,c";
                chart1.ChartAreas[0].AxisY.Title = "m, кг";
                chart1.Series[0].Name = "Масса РН";

                chart4.Series[0].Points.AddXY(time, V);
                chart4.ChartAreas[0].AxisX.Title = "t,c";
                chart4.ChartAreas[0].AxisY.Title = "V, км/с";
                chart4.Series[0].Name = "Скорость РН";

                chart6.Series[0].Points.AddXY(time, H/1000);
                chart6.ChartAreas[0].AxisX.Title = "t,c";
                chart6.ChartAreas[0].AxisY.Title = "H, км";
                chart6.Series[0].Name = "Высота полета";

                chart5.Series[0].Points.AddXY(time, N*180/Math.PI);
                chart5.ChartAreas[0].AxisX.Title = "t,c";
                chart5.ChartAreas[0].AxisY.Title = "N, град";
                chart5.Series[0].Name = "Полярный угол";

                chart3.Series[0].Points.AddXY(time, Y*180/Math.PI);
                chart3.ChartAreas[0].AxisX.Title = "t,c";
                chart3.ChartAreas[0].AxisY.Title = "Y, град";
                chart3.Series[0].Name = "Наклон к горизонту";
             
                chart2.Series[0].Points.AddXY(time, alpha);
                chart2.ChartAreas[0].AxisX.Title = "t,с";
                chart2.ChartAreas[0].AxisY.Title = "alpha, град";
                chart2.Series[0].Name = "Угол атаки";

                chart7.Series[0].Points.AddXY(time, ER * 180 / Math.PI);

                chart7.ChartAreas[0].AxisX.Title = "t,с";
                chart7.ChartAreas[0].AxisY.Title = "Ott, град";
                chart7.Series[0].Name = "Угол наклона траектории";


                chart9.Series[0].Points.AddXY(time, U*180/Math.PI);
                chart9.ChartAreas[0].AxisX.Title = "t,с";
                chart9.ChartAreas[0].AxisY.Title = "U, град";
                chart9.Series[0].Name = "Угол тангажа";

                chart8.Series[0].Points.AddXY(x/1000, y/1000);
                chart8.ChartAreas[0].AxisX.Title = "x, км";
                chart8.ChartAreas[0].AxisY.Title = "y, км";
                chart8.Series[0].Name = "Траектория";

                /// Вывод конечных значений параметров
                textBox1.Text = Convert.ToString(Ott);
                textBox2.Text = Convert.ToString(m);
                textBox5.Text = Convert.ToString(V);
                textBox6.Text = Convert.ToString(H/1000);
                textBox3.Text = Convert.ToString(N);
                textBox4.Text = Convert.ToString(Y*180/Math.PI);
                textBox7.Text = Convert.ToString(time);
                textBox13.Text = Convert.ToString(U * 180 / Math.PI);
            }
        }
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
