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
    internal class MazeObjects
    {
        public String[] path = { 
            @"C:\1\hall.png", 
            @"C:\1\wall.png",
            @"C:\1\medal.png",
            @"C:\1\enemy.png",
            @"C:\1\player.png"};
        
        private Label label;
        private Image image;

        public MazeObjects(int sizeOfLabel, int locX, int locY, Form form, int typeOfImage)
        {
            this.label = new Label();
            this.label.Parent = form;
            this.label.Size = new Size(sizeOfLabel, sizeOfLabel);
            this.label.Location = new Point(locY * sizeOfLabel, locX*sizeOfLabel);
            this.image = Image.FromFile(path[typeOfImage]);
            this.label.Image = this.image;
        }
        
        public void ChangeImage(int image)
        {
            this.image = Image.FromFile(path[image]);
            this.label.Image = this.image;
        }

        
    }
}
