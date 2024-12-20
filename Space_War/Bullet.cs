using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    public class Bullet
    {
        public PictureBox BulletPictureBox { get; set; }
        public int Speed { get; set; }
        public int Direction { get; set; } // 1: Sağ, -1: Sol
        public int Damage { get; set; } // Mermi hasarı


        // Düşman türlerine göre mermi hasarları
        public const int BasicEnemyBulletDamage = 3;
        public const int FastEnemyBulletDamage = 5;
        public const int StrongEnemyBulletDamage = 10;
        public const int BossEnemyBulletDamage = 20;
        // Bullet sınıfına hareket fonksiyonu ekliyoruz
        public void Move()
        {
            // Merminin sağa veya sola doğru hareket etmesini sağla
            BulletPictureBox.Left += Speed * Direction;
        }
        public Bullet(PictureBox bulletPictureBox, int speed, int direction)
        {
            BulletPictureBox = bulletPictureBox;
            Speed = speed;
            Direction = direction;
        }
         // Mermi tipine göre hasar ataması yapma
    public void OnHit(string enemyType)
    {
        switch (enemyType)
        {
            case "Basic":
                Damage = BasicEnemyBulletDamage;
                break;
            case "Fast":
                Damage = FastEnemyBulletDamage;
                break;
            case "Strong":
                Damage = StrongEnemyBulletDamage;
                break;
            case "Boss":
                Damage = BossEnemyBulletDamage;
                break;
            default:
                Damage = 0;
                break;
        }
    }
    }
}
