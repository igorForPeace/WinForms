using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDZ5
{
    public partial class Form1 : Form
    {
        private DateTime newYear = new DateTime(2023, 1, 1, 0, 0, 0);
        private DateTime myBirthday = new DateTime(2023,3,29,2,0,0);
        private DateTime today = new DateTime();
        private TimeSpan beforeNewYear = new TimeSpan();
        private TimeSpan beforeMyBirthday = new TimeSpan();
        
        public Form1()
        {
            InitializeComponent();          
            today = DateTime.Now;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.today = DateTime.Now;
            this.beforeNewYear = this.newYear.Subtract(this.today);
            this.label1.Text = "До нового года осталось: "+ this.beforeNewYear.ToString().Remove(12);
            this.beforeMyBirthday = this.myBirthday.Subtract(this.today);
            this.label2.Text = "До моего дня рождения осталось: "+ this.beforeMyBirthday.ToString().Remove(12);
        }
    }
}
