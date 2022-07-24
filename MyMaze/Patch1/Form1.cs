using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsMyMaze
{
    public partial class Form1 : Form
    {
        private int sizeX; //размер игрового окна по ширине
        private int sizeY; //размер игрового окна по высоте
        private int sizeOfLabel; //размер поля игры (квадрата с текстурой)
        public static Random r = new Random();
        private MazeObjects[,] mazeObj; // массив объектов
        private int typeOfObj; //тип объекта лабиринта
        private int smileX;
        private int smileY;
        public Form1()
        {
            this.sizeX = 40;
            this.sizeY = 20;
            this.mazeObj = new MazeObjects[sizeY, sizeX];
            this.sizeOfLabel = 16;
            InitializeComponent();
            Options();
            MakeField();
        }

        public void MakeField() //создание 
        {
            smileX = 0;
            smileY = 2;
            for (int i = 0; i < this.sizeY; i++)
            {
                for (int j = 0; j < this.sizeX; j++)
                {
                    //this.labaelArr[i, j] = new Label();
                    //this.labaelArr[i, j].Parent = this;
                    //this.labaelArr[i, j].Text = (j + 1).ToString();
                    //this.labaelArr[i, j].Size = new Size(this.sizeOfLabel, this.sizeOfLabel);
                    //this.labaelArr[i, j].Location = new Point(j * this.sizeOfLabel, i * this.sizeOfLabel);
                    //this.labaelArr[i, j].Visible = true;
                    //this.labaelArr[i, j].ForeColor = Color.Coral;

                    this.typeOfObj = 0;
                    // в 1 случае из 5 - ставим стену
                    if (r.Next(5) == 0) this.typeOfObj = 1;                   
                    // в 1 случае из 250 - кладём денежку
                    if (r.Next(250) == 0) this.typeOfObj = 2;                   
                    // в 1 случае из 250 - размещаем врага
                    if (r.Next(250) == 0) this.typeOfObj = 3;
                    // стены по периметру обязательны
                    if (i == 0 || j == 0 || i == this.sizeY - 1 | j == this.sizeX - 1) this.typeOfObj = 1;                    
                    // наш персонажик
                    if (j == smileX && i == smileY) this.typeOfObj = 4;                 
                    //для персонажа всегда должен быть выход из начальной точки
                    if (j== smileX+1&& i == smileY) this.typeOfObj = 0;                  
                    //выход из карты
                    if ((j == sizeX-1&&i==sizeY-3)||(j == sizeX - 2 && i == sizeY - 3)) this.typeOfObj = 0;

                    mazeObj[i, j] = new MazeObjects(this.sizeOfLabel, i, j, this, this.typeOfObj);                  
                }
            }
        }

        public void Options()
        {
            this.Text = "Maze";
            this.BackColor = Color.FromArgb(255, 92, 118, 137);
            this.Width = sizeX * 16 + 16;
            this.Height = sizeY * 16 + 40;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.Text = String.Format(e.KeyValue + "  " + e.KeyCode);
            int xMove = 0;
            int yMove = 0;
            if (e.KeyValue == 38)
            {
                yMove -= 1;
            }
            else if (e.KeyValue == 39)
            {
                xMove += 1;
            }
            else if (e.KeyValue == 40)
            {
                yMove += 1;
            }
            else if (e.KeyValue == 37)
            {
                if (smileX==0) xMove = 0;
                else xMove -= 1;
            }

            this.mazeObj[smileY, smileX].ChangeImage(0);
            smileX += xMove;
            smileY += yMove;
            this.mazeObj[smileY, smileX].ChangeImage(4);
            

        }

        public void MakeMove(int moveX, int moveY)
        {
            this.mazeObj[this.smileY, this.smileX] = new MazeObjects(sizeOfLabel,this.smileX*sizeOfLabel, this.smileY*sizeOfLabel, this, 0 );
            this.smileX += moveX;
            this.smileY += moveY;
            this.mazeObj[this.smileY, this.smileX] =new MazeObjects(sizeOfLabel, this.smileX * sizeOfLabel, this.smileY * sizeOfLabel, this, 4);           
        }
    }
}
