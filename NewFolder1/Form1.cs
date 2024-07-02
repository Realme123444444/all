using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form3 s = new Form3();
            s.Show();
            this.Hide();

        }

        public void button2_Click(object p, EventArgs empty)
        {
            Form3 s = new Form3();
            s.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 s = new Form2();
            s.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 s = new Form4();
            s.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 s = new Form6();
            s.Show();
            this.Hide();
        }

        public void button1_Click1(object p, EventArgs empty)
        {
            Form2 s = new Form2();
            s.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 s = new Form5();
            s.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
           
            Form3 s = new Form3();
            s.Show();
            this.Hide();

        }

        public void button3_Click1(object p, EventArgs empty)
        {
            Form4 s = new Form4();
            s.Show();
            this.Hide();
        }

        public void button4_Click1(object p, EventArgs empty)
        {
            Form5 s = new Form5();
            s.Show();
            this.Hide();
        }

        public void button5_Click1(object p, EventArgs empty)
        {
            Form6 s = new Form6();
            s.Show();
            this.Hide();
        }
    }
}
