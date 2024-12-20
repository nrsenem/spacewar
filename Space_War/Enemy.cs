using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    public class Enemy
    {
        // Özellikler
        public PictureBox EnemyPictureBox { get; set; } // Düşmanın görseli
        public int Health { get; set; }                 // Can sayısı
        public int Speed { get; set; }                 // Hız değeri
       
        // Sabit sağlık değerleri
        public static readonly int BasicEnemyHealth = 1;
        public static readonly int FastEnemyHealth = 2;
        public static readonly int StrongEnemyHealth = 3;
        public static readonly int BossEnemyHealth = 4;

        // Sabit hız değerleri
        public static readonly int BasicEnemySpeed = 2;
        public static readonly int FastEnemySpeed = 5;
        public static readonly int StrongEnemySpeed = 3;
        public static readonly int BossEnemySpeed = 1;

        // Sabit hasar değerleri
        public static readonly int BasicEnemyDamage = 5;
        public static readonly int FastEnemyDamage = 8;
        public static readonly int StrongEnemyDamage = 11;
        public static readonly int BossEnemyDamage = 12;
        public Enemy() { }

        // Yapıcı Metot
        public Enemy(PictureBox enemyPictureBox, int health, int speed)
        {
            EnemyPictureBox = enemyPictureBox;
            Health = health;
            Speed = speed;
           
        }
    }

 }
