using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ6
{
    public partial class Form1 : Form
    {
        private int r;
        private int g;
        private int b;
        
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
            this.r = 250;
            this.g = 10;
            this.b = 10;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(this.r, this.g, this.b);
            if (this.g==10&&this.b==250) this.r++;
            if (this.r==10&&this.b==250) this.g--;
            if (this.r==10&&this.g==250) this.b++;
            if (this.g==250&&this.b==10) this.r--;
            if (this.r==250&&this.b==10) this.g++;
            if (this.r==250&&this.g==10) this.b--;
        }
    }
}
