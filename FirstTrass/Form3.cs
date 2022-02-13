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
        public static double w1;

        
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
