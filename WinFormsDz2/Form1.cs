using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsHW_2_RunWin
{
    public partial class Form1 : Form
    {
        private int x_next;
        private int y_next;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            x_next = 0;
            y_next = 0;
        }

        private void button1_MouseEnter(object sender , EventArgs e)
        {
            NewLocation(this);
            this.button1.Location = new System.Drawing.Point(x_next, y_next);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.Controls.Add(this.button1);   
        }

        private void NewLocation(Form form)
        {
            random = new Random();
            this.x_next = random.Next(10, form.Size.Width - 10);
            this.y_next = random.Next(10, form.Size.Height - 10);
        }
    }
}
