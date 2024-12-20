using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    
    public class Game
    {
        private Form1 form1;
        Spaceship spaceship = new Spaceship(100,5);

        // Oyunla ilgili tüm gerekli nesneler
        private List<Bullet> bullets;
        private List<Enemy> enemies;
        private PictureBox BasicEnemy, FastEnemy, StrongEnemy, BossEnemy;
        public PictureBox Spaceshipplayer;
        private PictureBox BasicEnemybullet, FastEnemybullet, StrongEnemybullet, BossEnemybullet;
        private int enemiesDestroyed=0;
        private int score = 0;

        public const int BasicEnemyBulletDamage = 3;
        public const int FastEnemyBulletDamage = 5;
        public const int StrongEnemyBulletDamage = 10;
        public const int BossEnemyBulletDamage = 20;


        public Game(List<Bullet> bullets, Spaceship spaceship, PictureBox spaceshipplayer, PictureBox basicEnemy, PictureBox fastEnemy,
            PictureBox strongEnemy, PictureBox bossEnemy, PictureBox basicEnemybullet, PictureBox fastEnemybullet,
            PictureBox strongEnemybullet, PictureBox bossEnemybullet,  Form1 form1)
        {
            this.bullets = bullets;
            this.Spaceshipplayer = spaceshipplayer;
            this.BasicEnemy = basicEnemy;
            this.FastEnemy = fastEnemy;
            this.StrongEnemy = strongEnemy;
            this.BossEnemy = bossEnemy;
            this.BasicEnemybullet = basicEnemybullet;
            this.FastEnemybullet = fastEnemybullet;
            this.StrongEnemybullet = strongEnemybullet;
            this.BossEnemybullet = bossEnemybullet;
            this.spaceship = spaceship; 
            this.form1 = form1;
            // Düşmanları initialize ediyoruz
            enemies = new List<Enemy>
            {
               new Enemy { EnemyPictureBox = BasicEnemy, Speed = Enemy.BasicEnemySpeed, Health = Enemy.BasicEnemyHealth },
               new Enemy { EnemyPictureBox = FastEnemy, Speed = Enemy.FastEnemySpeed, Health = Enemy.FastEnemyHealth },
               new Enemy { EnemyPictureBox = StrongEnemy, Speed = Enemy.StrongEnemySpeed, Health = Enemy.StrongEnemyHealth },
               new Enemy { EnemyPictureBox = BossEnemy, Speed = Enemy.BossEnemySpeed, Health = Enemy.BossEnemyHealth }
            };
        }
        private void UpdateScore(int points)
        {
            score += points;
            form1.UpdateScoreLabel(score); // Form1'de bir etiket (Label) ile skoru göster
        }

        public void UpdateHealth()
        {
            // Form1'deki UpdateHealthLabel metodunu çağırıyoruz
            form1.UpdateHealthLabel(spaceship.Health);
        }
        public void UpdateEndGame()
        {
            form1.EndGame(false);
        }
       
        public void MoveEnemy(PictureBox enemy,int speed)
        {
            if (enemy != null)
            {
                form1.ResetEnemy(enemy,speed); // Form1'deki ResetEnemy metodunu çağırıyoruz
            }
        }
        private void TakeDamage(int damage)
        {
            spaceship.Health -= damage;
            UpdateScore(-damage * 2); // Hasar başına 2 puan azaltma (isteğe bağlı)
            UpdateHealth();
            if (spaceship.Health <= 0)
            {
                UpdateEndGame();
            }
        }

        public void CheckCollisions()
        {
            foreach (Bullet bullet in bullets.ToList())
            {
                foreach (var enemy in enemies)
                {
                    if (enemy.EnemyPictureBox != null && bullet.BulletPictureBox.Bounds.IntersectsWith(enemy.EnemyPictureBox.Bounds))
                    {
                        bullet.BulletPictureBox.Visible = false;
                        bullets.Remove(bullet);
                        HandleEnemyCollision(enemy);
                        break;
                    }
                }
            }
        
            if (BasicEnemy != null && BasicEnemy.Visible && BasicEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                if (BasicEnemy != null && BasicEnemy.Visible && BasicEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
                {
                    BasicEnemy.Visible = false;
                    TakeDamage(Enemy.BasicEnemyDamage); // Sabitlerden gelen değer
                }

            }
            if (FastEnemy != null && FastEnemy.Visible && FastEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                if (FastEnemy != null && FastEnemy.Visible && FastEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
                {
                    FastEnemy.Visible = false;
                    TakeDamage(Enemy.FastEnemyDamage); // Sabitlerden gelen değer
                }

            }
            if (StrongEnemy != null && StrongEnemy.Visible && StrongEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                if (StrongEnemy != null && StrongEnemy.Visible && StrongEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
                {
                    StrongEnemy.Visible = false;
                    TakeDamage(Enemy.StrongEnemyDamage); // Sabitlerden gelen değer
                }

            }
            if (BossEnemy != null && BossEnemy.Visible && BossEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                
                BossEnemy.Visible = false;
                if (BossEnemy != null && BossEnemy.Visible && BossEnemy.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
                {
                    BossEnemy.Visible = false;
                    TakeDamage(Enemy.BossEnemyDamage); // Sabitlerden gelen değer
                }

            }

            // Düşman mermileri ve oyuncu gemisi arasındaki çarpışma kontrolü
            if (BasicEnemybullet != null && BasicEnemybullet.Visible && BasicEnemybullet.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                BasicEnemybullet.Visible = false;
                TakeDamage(BasicEnemyBulletDamage); // Sabitlerden gelen değer
            }
            if (FastEnemybullet != null && FastEnemybullet.Visible && FastEnemybullet.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                FastEnemybullet.Visible = false;
                TakeDamage(FastEnemyBulletDamage);
            }
            if (StrongEnemybullet != null && StrongEnemybullet.Visible && StrongEnemybullet.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                StrongEnemybullet.Visible = false;
                TakeDamage(StrongEnemyBulletDamage);
            }
            if (BossEnemybullet != null && BossEnemybullet.Visible && BossEnemybullet.Bounds.IntersectsWith(Spaceshipplayer.Bounds))
            {
                BossEnemybullet.Visible = false;
                TakeDamage(BossEnemyBulletDamage);
            }
        }
        private void HandleEnemyCollision(Enemy enemy)
        {
            enemy.Health--;
            if (enemy.Health <= 0)
            {
                // Düşman yok edildiğinde skor ekleme
                if (enemy.EnemyPictureBox == BasicEnemy) UpdateScore(10);
                else if (enemy.EnemyPictureBox == FastEnemy) UpdateScore(20);
                else if (enemy.EnemyPictureBox == StrongEnemy) UpdateScore(30);
                else if (enemy.EnemyPictureBox == BossEnemy) UpdateScore(60);

                MoveEnemy(enemy.EnemyPictureBox, enemy.Speed);
                enemy.Health = GetDefaultHealth(enemy.EnemyPictureBox);
                enemiesDestroyed++;
                CheckWinCondition();
            }
        }
        private int GetDefaultHealth(PictureBox enemy)
        {
            if (enemy == BasicEnemy) return 1;
            if (enemy == FastEnemy) return 2;
            if (enemy == StrongEnemy) return 3;
            if (enemy == BossEnemy) return 4;
            return 1;
        }
        private void CheckWinCondition()
        {
            if (enemiesDestroyed >= 10) // Eğer 10 düşman yok edildiyse
            {
                form1.EndGame(true); // Kazanma mesajı göster
            }
        }


    }
}