using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    public class Spaceship
    {
        public int Health { get; set; } = 100; // Varsayılan olarak 100
        public int Speed { get; set;}
        public Spaceship(int health, int speed) 
        {
            this.Speed = speed;
            this.Health = health;
        }
        public void Move(Keys key, PictureBox spaceshipControl, int formHeight)
        {
            if (key == Keys.Up && spaceshipControl.Top > 0)
            {
                spaceshipControl.Top -= Speed; // Yukarı hareket
            }
            else if (key == Keys.Down && spaceshipControl.Bottom < formHeight)
            {
                spaceshipControl.Top += Speed; // Aşağı hareket
            }
        }

    }

}
