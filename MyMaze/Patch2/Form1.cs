using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
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
        private Label medal;
        private Label numberOfMedal; //поле для отрисовки количество медалей       
        private Image medalImage;
        private Label heart; //поле отрисовки сердца
        private Label HpLevel; //поле отрисовки количества жизней
        private Image heartImage;
        private int HP; // поле количества жизней
        private int typeOfObj; //тип объекта лабиринта
        private int smileX;
        private int smileY;
        private int countOfMedals; //общее количество медалей
        private SoundPlayer player;

        public Form1()
        {
            //инициализация полей (размер карты)
            this.sizeX = 40;
            this.sizeY = 20;

            //массив объектов
            this.mazeObj = new MazeObjects[sizeY, sizeX];
            //размер объекта
            this.sizeOfLabel = 16;
            //количество медалей
            this.countOfMedals = 0;

            //значек медали справа от карты
            this.medal = new Label();
            this.medal.Parent = this;
            this.medal.Size = new Size(sizeOfLabel, sizeOfLabel);
            this.medal.Location = new Point(900, 40);
            this.medalImage = Image.FromFile(@"C:\1\medal.png");
            this.medal.Image = this.medalImage;

            //запись количества медалей
            this.numberOfMedal = new Label();
            this.numberOfMedal.Parent = this;
            this.numberOfMedal.Size = new Size(sizeOfLabel + 40, sizeOfLabel);
            this.numberOfMedal.Location = new Point(920, 40);

            //значек сердца
            this.heart = new Label();
            this.heart.Parent = this;
            this.heart.Size = new Size(sizeOfLabel, sizeOfLabel);
            this.heart.Location = new Point(900, 60);
            this.heartImage = Image.FromFile(@"C:\1\heart.png");
            this.heart.Image = this.heartImage;

            //запись количества HP
            this.HpLevel = new Label();
            this.HpLevel.Parent = this;
            this.HpLevel.Size = new Size(sizeOfLabel + 40, sizeOfLabel);
            this.HpLevel.Location = new Point(920, 60);
            this.HP = 100;

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
                    this.typeOfObj = 0;
                    // в 1 случае из 5 - ставим стену
                    if (r.Next(5) == 0) this.typeOfObj = 1;
                    // в 1 случае из 250 - кладём денежку
                    if (r.Next(50) == 0) this.typeOfObj = 2;
                    // в 1 случае из 250 - размещаем врага
                    if (r.Next(50) == 0) this.typeOfObj = 3;
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
            for (int i = 0; i < this.sizeY; i++)
            {
                for (int j = 0; j < this.sizeX; j++)
                {
                    if (this.mazeObj[i,j].GetImageIndex()==2)
                    {
                        this.countOfMedals++;
                    }
                }
            }
            player = new SoundPlayer(@"C:\1\round.wav");
            player.Play();
        }

        public void Options()
        {
            this.Text = "Maze";
            this.BackColor = Color.FromArgb(255, 92, 118, 137);
            this.Width = sizeX * 16 + 160;
            this.Height = sizeY * 16 + 40;
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            this.numberOfMedal.Text = " = " + this.countOfMedals;
            this.HpLevel.Text = " = " + this.HP;
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

            if (this.mazeObj[smileY+yMove,smileX+xMove].GetImageIndex()==0)
            {
                this.mazeObj[smileY, smileX].ChangeImage(0);
                smileX += xMove;
                smileY += yMove;
                this.mazeObj[smileY, smileX].ChangeImage(4);
                if ((smileY  == sizeY - 3) && (smileX== sizeX - 1))
                {
                    player = new SoundPlayer(@"C:\1\newArea.wav");
                    player.Play();
                    MessageBox.Show("You win!");
                    Environment.Exit(0);
                }
            }
            if (this.mazeObj[smileY + yMove, smileX + xMove].GetImageIndex() == 2)
            {            
                this.mazeObj[smileY, smileX].ChangeImage(0);
                smileX += xMove;
                smileY += yMove;
                this.mazeObj[smileY, smileX].ChangeImage(4);
                this.mazeObj[smileY, smileX].SetImageIndex(0);
                this.countOfMedals--;
                this.numberOfMedal.Text = " = " + this.countOfMedals;
                player = new SoundPlayer(@"C:\1\darkSoulsCursor.wav");
                player.Play();
                if (this.countOfMedals==0)
                {
                    player = new SoundPlayer(@"C:\1\newArea.wav");
                    player.Play();
                    MessageBox.Show("You have found all of medals! You Win!");
                    Environment.Exit(0);
                }
            }
            if (this.mazeObj[smileY + yMove, smileX + xMove].GetImageIndex() == 3)
            {            
                this.mazeObj[smileY, smileX].ChangeImage(0);
                smileX += xMove;
                smileY += yMove;
                this.mazeObj[smileY, smileX].ChangeImage(4);
                this.mazeObj[smileY, smileX].SetImageIndex(0);
                this.HP-=25;
                this.HpLevel.Text = " = " + this.HP;
                player = new SoundPlayer(@"C:\1\andre.wav");
                player.Play();
                if (this.HP ==0)
                {
                    player = new SoundPlayer(@"C:\1\DarkSouls.wav");
                    player.Play();
                    MessageBox.Show("You DIE!");
                    Environment.Exit(0);
                }
            }
        }

        public void MakeMove(int moveX, int moveY)
        {
            this.mazeObj[this.smileY, this.smileX] = new MazeObjects(sizeOfLabel,this.smileX*sizeOfLabel, this.smileY*sizeOfLabel, this, 0 );
            this.smileX += moveX;
            this.smileY += moveY;
            this.mazeObj[this.smileY, this.smileX] = new MazeObjects(sizeOfLabel, this.smileX * sizeOfLabel, this.smileY * sizeOfLabel, this, 4);           
        }
    }
}
