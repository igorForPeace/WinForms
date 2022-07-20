using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsHomeWork1
{
    public partial class Form1 : Form
    {
        private Button[] buttons;
        private int i;
        private int x1;
        private int y1;
        private int x2;
        private int y2;
        private int width;
        private int height;


        public Form1()
        {
            InitializeComponent();
            this.buttons = new Button[100];
            this.i = 0;
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_DoubleClick(object sender, EventArgs evargs)
        {
            this.InitializeButton(this, evargs as MouseEventArgs);            
        }

        

        private void InitializeButton(Form frm, MouseEventArgs mouse)
        {
            this.buttons[this.i] = new Button();
            this.buttons[this.i].SuspendLayout(); 
            this.buttons[this.i].Location = new System.Drawing.Point(mouse.X, mouse.Y);
            this.buttons[this.i].Name = "button " + (i+1);
            this.buttons[this.i].Size = new System.Drawing.Size(75, 23);
            this.buttons[this.i].TabIndex = 0;
            this.buttons[this.i].Text = "button " + (i + 1);
            this.buttons[this.i].UseVisualStyleBackColor = true;
            frm.Controls.Add(this.buttons[this.i]);
            this.i++;
        }

        private void Form1_MouseDown(object sender , MouseEventArgs e)
        {
            x1 = e.X;
            y1 = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            this.buttons[this.i].Name = "button " + (i + 1);
            this.buttons[this.i].Size = new System.Drawing.Size(width, height);
            this.buttons[this.i].TabIndex = 0;
            this.buttons[this.i].Text = "button " + (i + 1);
            this.buttons[this.i].UseVisualStyleBackColor = true;
            this.Controls.Add(this.buttons[this.i]);
            this.i++;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {         
            this.buttons[this.i] = new Button();
            this.buttons[this.i].SuspendLayout();
            if (x1 <= e.X && y1 <= e.Y)
            {
                x2 = e.X;
                y2 = e.Y;
                width = x2 - x1;
                height = y2 - y1;
                this.buttons[this.i].Location = new System.Drawing.Point(x1, y1);
            }
            else if (x1 >= e.X && y1 >= e.Y)
            {
                x2 = e.X;
                y2 = e.Y;
                width = x1 - x2;
                height = y1 - y2;
                this.buttons[this.i].Location = new System.Drawing.Point(x2, y2);
            }
            else if (x1 <= e.X && y1 >= e.Y)
            {
                x2 = e.X;
                y2 = e.Y;
                width = x2 - x1;
                height = y1 - y2;
                this.buttons[this.i].Location = new System.Drawing.Point(x1, y2);
            }
            else if (x1 >= e.X && y1 <= e.Y)
            {
                x2 = e.X;
                y2 = e.Y;
                width = x1 - x2;
                height = y2 - y1;
                this.buttons[this.i].Location = new System.Drawing.Point(x2, y1);
            }
            
        }
    }
}
