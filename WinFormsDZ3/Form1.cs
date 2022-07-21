using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ3
{
    public partial class Form1 : Form
    {
        private int x, y;
        public Form1()
        {
            InitializeComponent();
            this.timer1.Interval = 40;
            this.timer1.Enabled = true;
            x = y = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.x = this.button1.Location.X;
            this.y = this.button1.Location.Y;
            this.button1.Location = new System.Drawing.Point(x+1, y);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;         
        }
    }
}
