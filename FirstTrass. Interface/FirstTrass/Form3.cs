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

    public partial class Form3 : Form
    {
        public static double w1,w2,w3;
        public static double PENG1, PENG2, PENG3;
        public static double mb1, mb2, mb3;
        public static double mpn;
        public static double D;
        public static double s1,s2,s3;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide();
           // Form1 fm2 = new Form1();
            w1 = Convert.ToDouble(textBox9.Text);
            w2 = Convert.ToDouble(textBox8.Text);
            w3 = Convert.ToDouble(textBox7.Text);
            PENG1 = Convert.ToDouble(textBox12.Text);
            PENG2 = Convert.ToDouble(textBox11.Text);
            PENG3 = Convert.ToDouble(textBox10.Text);
            mb1 = Convert.ToDouble(textBox6.Text);
            mb2 = Convert.ToDouble(textBox5.Text);
            mb3 = Convert.ToDouble(textBox4.Text);
            mpn = Convert.ToDouble(textBox13.Text);
            D = Convert.ToDouble(textBox15.Text);
            s1 = Convert.ToDouble(textBox1.Text);
            s2 = Convert.ToDouble(textBox2.Text);
            s3 = Convert.ToDouble(textBox3.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
    static class FirstTrass
    {

    }
}
