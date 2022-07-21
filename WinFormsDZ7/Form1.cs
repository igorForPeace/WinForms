using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ7
{
    public partial class Form1 : Form
    {
        private int i;
        private int j;
        private int seconds;
        private int size;
        private int[] rounds;
        public Form1()
        {
            InitializeComponent();
            this.i = 0;
            this.j = 0; 
            this.size = 3;
            this.rounds = new int[size];
            this.seconds = 20;
            this.label1.Text = "seconds";
            this.label2.Text = "round #1: ";
            this.label3.Text = "round #2: ";
            this.label4.Text = "round #3: ";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            this.i++;
            this.button1.Text = "button1\n" + this.i.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.seconds--;
            this.label1.Text = this.seconds.ToString();
            if (seconds == 0)
            {            
                this.timer1.Stop();
                MessageBox.Show("Your result is " + i);
                this.rounds[j] = i;
                if (j == 0) this.label2.Text = "round #1: " + this.rounds[j].ToString();
                if (j == 1) this.label3.Text = "round #2: " + this.rounds[j].ToString();
                if (j == 2) this.label4.Text = "round #3: " + this.rounds[j].ToString();
                if (j==2)
                {
                    MessageBox.Show("Your best count is " + rounds.Max());
                    MessageBox.Show("Good bye!");
                    Environment.Exit(0);
                }
                j++;
                this.i = 0;
                this.seconds = 20;          
            }
            
        }
    }
}
