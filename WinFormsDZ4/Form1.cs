using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ4
{
    public partial class Form1 : Form
    {
        private int i;
        public Form1()
        {
            this.i = 0;
            InitializeComponent();
            
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = i.ToString();
            i+=11;
        }
    }
}
