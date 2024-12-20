using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_War
{
    public partial class Form1 : Form
    {
        private Game game;
        private Enemy enemy;
        Spaceship spaceship = new Spaceship(100,50);
        private List<Bullet> bullets = new List<Bullet>();

        
        private Timer bulletTimer; // Merminin hareketini kontrol eden timer
        private int bulletSpeed = 20; // Merminin hareket hızı

       
        private Timer enemyTimer; // Düşman gemilerini hareket ettiren timer
        private Timer enemyBulletTimer; // Düşman mermilerini hareket ettiren timer
        private Timer basicEnemyFireTimer; // BasicEnemy mermileri için timer
        private Timer fastEnemyFireTimer; // FastEnemy mermileri için timer
        private Timer strongEnemyFireTimer; // StrongEnemy mermileri için timer
        private Timer bossEnemyFireTimer; // BossEnemy mermileri için timer
        private Timer collisionTimer;


        private int enemyBulletSpeed = 8; // Düşman mermisi hızı
        
        public Form1()
        {
            InitializeComponent();
            // Burada gerekli nesneleri geçiyoruz.
            game = new Game(bullets, spaceship,Spaceshipplayer, BasicEnemy, FastEnemy, StrongEnemy, BossEnemy, BasicEnemybullet, FastEnemybullet, StrongEnemybullet, BossEnemybullet, this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Timer oluştur ve başlat
            enemyTimer = new Timer();
            enemyTimer.Interval = 30; // Her 30 ms'de bir çalışır
            enemyTimer.Tick += EnemyTimer_Tick;
            enemyTimer.Start();


            // Düşman mermileri için timer
            enemyBulletTimer = new Timer();
            enemyBulletTimer.Interval = 30; // Her 30 ms'de bir çalışır
            enemyBulletTimer.Tick += EnemyBulletTimer_Tick;
            enemyBulletTimer.Start();

            // BasicEnemy'nin mermilerini ateşleyen timer
            basicEnemyFireTimer = new Timer();
            basicEnemyFireTimer.Interval = 1000; // Her 1 saniyede bir mermi atar
            basicEnemyFireTimer.Tick += BasicEnemyFireTimer_Tick;
            basicEnemyFireTimer.Start();

            // FastEnemy'nin mermilerini ateşleyen timer
            fastEnemyFireTimer = new Timer();
            fastEnemyFireTimer.Interval = 1000; // Her 1 saniyede bir mermi atar
            fastEnemyFireTimer.Tick += FastEnemyFireTimer_Tick;
            fastEnemyFireTimer.Start();

            // StrongEnemy'nin mermilerini ateşleyen timer
            strongEnemyFireTimer = new Timer();
            strongEnemyFireTimer.Interval = 1000; // Her 1 saniyede bir mermi atar
            strongEnemyFireTimer.Tick += StrongEnemyFireTimer_Tick;
            strongEnemyFireTimer.Start();

            // BossEnemy'nin mermilerini ateşleyen timer
            bossEnemyFireTimer = new Timer();
            bossEnemyFireTimer.Interval = 1000; // Her 1 saniyede bir mermi atar
            bossEnemyFireTimer.Tick += BossEnemyFireTimer_Tick;
            bossEnemyFireTimer.Start();

            // Formda klavye olaylarını yakalamak için
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            // Timer oluştur ve başlat
            bulletTimer = new Timer();
            bulletTimer.Interval = 30; // Her 30 ms'de bir çalışır
            bulletTimer.Tick += BulletTimer_Tick;

            // Çarpışmaları kontrol etmek için Timer başlat
            collisionTimer = new Timer();
            collisionTimer.Interval = 30;
            collisionTimer.Tick += CollisionTimer_Tick;
            collisionTimer.Start();
            // Sağlık durumu göstermek için bir Label ekleyelim (opsiyonel)
            Label healthLabel = new Label();
            healthLabel.Name = "HealthLabel";
            healthLabel.Text = "Health: " +spaceship.Health;
            healthLabel.Location = new Point(10, 10);
            healthLabel.ForeColor = Color.White; // Label yazı rengini beyaz yap
            this.Controls.Add(healthLabel);

        }
        private void CollisionTimer_Tick(object sender, EventArgs e)
        {
            game.CheckCollisions ();
        }
       
        public void UpdateHealthLabel(int playerHealth)
        {
            // Sağlık durumunu günceller
            Label healthLabel = this.Controls["HealthLabel"] as Label;
            if (healthLabel != null)
            {
                healthLabel.Text = "Health: " + playerHealth;
            }
        }
        public void ResetEnemy(PictureBox enemy, int speed)
        {
            if (enemy != null)
            {
                Point newPosition = FindValidPosition(enemy);

                enemy.Left = this.ClientSize.Width; // Sağ kenardan başlar
                enemy.Top = newPosition.Y;         // Uygun bir yukarı pozisyon
                enemy.Visible = true;             // Tekrar görünür yap
            }
        }
        public Point FindValidPosition(PictureBox currentEnemy)
        {
            Random random = new Random();
            bool positionFound = false;
            int maxAttempts = 100; // Sonsuz döngüyü önlemek için bir sınır

            Point validPosition = new Point();

            while (!positionFound && maxAttempts > 0)
            {
                // Yeni bir rastgele pozisyon oluştur
                int newTop = random.Next(0, this.ClientSize.Height - currentEnemy.Height);

                // Çakışma kontrolü
                positionFound = true;
                foreach (Control control in this.Controls)
                {
                    if (control is PictureBox otherEnemy && otherEnemy != currentEnemy && otherEnemy.Visible)
                    {
                        Rectangle currentBounds = new Rectangle(0, newTop, currentEnemy.Width, currentEnemy.Height);
                        if (currentBounds.IntersectsWith(otherEnemy.Bounds))
                        {
                            positionFound = false;
                            break;
                        }
                    }
                }

                // Uygun pozisyon bulunduysa döngüyü sonlandır
                if (positionFound)
                {
                    validPosition = new Point(this.ClientSize.Width, newTop);
                }

                maxAttempts--;
            }

            return validPosition;
        }

        public void EndGame(bool hasWon)
        { 
            string message = hasWon
                ? $"Tebrikler! Oyunu kazandınız!  \nSkorunuz: {scoreLabel.Text}"
                : $"Üzgünüm! Oyunu kaybettiniz.   \nSkorunuz: {scoreLabel.Text}";
            // SkorboardForm'u aç
            Skor scoreboardForm = new Skor();
            scoreboardForm.DisplayResult(message);

            // SkorboardForm'u göster
            scoreboardForm.Show();

            // Oyunla ilgili diğer işlemler (örneğin, spaceshipplayer gizleme)
            Spaceshipplayer.Visible = false;

            this.Hide(); // Oyunu kapat
        }
        private void EnemyTimer_Tick(object sender, EventArgs e)
        {
            // BasicEnemy hareketi
            if (BasicEnemy != null)
            {
                BasicEnemy.Left -= Enemy.BasicEnemySpeed;
                ResetEnemyPosition(BasicEnemy);
            }

            // FastEnemy hareketi
            if (FastEnemy != null)
            {
                FastEnemy.Left -= Enemy.FastEnemySpeed;
                ResetEnemyPosition(FastEnemy);
            }

            // StrongEnemy hareketi
            if (StrongEnemy != null)
            {
                StrongEnemy.Left -= Enemy.StrongEnemySpeed;
                ResetEnemyPosition(StrongEnemy);
            }

            // BossEnemy hareketi
            if (BossEnemy != null)
            {
                BossEnemy.Left -= Enemy.BossEnemySpeed;
                ResetEnemyPosition(BossEnemy);
            }
        }
        private void ResetEnemyPosition(PictureBox enemy)
        {
            // Düşman gemisi formun solundan çıkarsa tekrar sağ tarafa gönder
            if (enemy.Right < 0)
            {
                enemy.Left = this.ClientSize.Width; // Sağ tarafa gönder
                enemy.Top = new Random().Next(0, this.ClientSize.Height - enemy.Height); // Rastgele bir yukarı konum
            }
        }
        private void EnemyBulletTimer_Tick(object sender, EventArgs e)
        {
            // BasicEnemy'nin mermisini hareket ettir
            if (BasicEnemybullet != null && BasicEnemybullet.Visible)
            {
                BasicEnemybullet.Left -= enemyBulletSpeed;
                ResetBulletPosition(BasicEnemybullet, BasicEnemy);
            }

            // FastEnemy'nin mermisini hareket ettir
            if (FastEnemybullet != null && FastEnemybullet.Visible)
            {
                FastEnemybullet.Left -= enemyBulletSpeed;
                ResetBulletPosition(FastEnemybullet, FastEnemy);
            }

            // StrongEnemy'nin mermisini hareket ettir
            if (StrongEnemybullet != null && StrongEnemybullet.Visible)
            {
                StrongEnemybullet.Left -= enemyBulletSpeed;
                ResetBulletPosition(StrongEnemybullet, StrongEnemy);
            }

            // BossEnemy'nin mermisini hareket ettir
            if (BossEnemybullet != null && BossEnemybullet.Visible)
            {
                BossEnemybullet.Left -= enemyBulletSpeed;
                ResetBulletPosition(BossEnemybullet, BossEnemy);
            }
        }
        private void ResetBulletPosition(PictureBox bullet, PictureBox enemy)
        {
            // Eğer mermi formdan dışarı çıkarsa
            if (bullet.Right < 0)
            {
                bullet.Visible = false; // Mermiyi gizle
            }

            // Düşman gemisinden mermi atma
            if (!bullet.Visible && new Random().Next(0, 100) < 5) // Yüzde 5 olasılıkla mermi at
            {
                // Mermiyi düşmanın tam önünde göster
                bullet.Left = enemy.Left - bullet.Width; // Düşman gemisinin hemen önünde
                bullet.Top = enemy.Top + enemy.Height / 2 - bullet.Height / 2; // Düşman gemisinin ortasında
                bullet.Visible = true; // Mermiyi görünür yap
            }
        }
        // BasicEnemy mermisini ateşleme fonksiyonu
        private void BasicEnemyFireTimer_Tick(object sender, EventArgs e)
        {
            if (BasicEnemy != null && BasicEnemybullet != null && !BasicEnemybullet.Visible)
            {
                BasicEnemybullet.Left = BasicEnemy.Left - BasicEnemybullet.Width;
                BasicEnemybullet.Top = BasicEnemy.Top + BasicEnemy.Height / 2 - BasicEnemybullet.Height / 2;
                BasicEnemybullet.Visible = true;
            }
        }

        // FastEnemy mermisini ateşleme fonksiyonu
        private void FastEnemyFireTimer_Tick(object sender, EventArgs e)
        {
            if (FastEnemy != null && FastEnemybullet != null && !FastEnemybullet.Visible)
            {
                FastEnemybullet.Left = FastEnemy.Left - FastEnemybullet.Width;
                FastEnemybullet.Top = FastEnemy.Top + FastEnemy.Height / 2 - FastEnemybullet.Height / 2;
                FastEnemybullet.Visible = true;
            }
        }

        // StrongEnemy mermisini ateşleme fonksiyonu
        private void StrongEnemyFireTimer_Tick(object sender, EventArgs e)
        {
            if (StrongEnemy != null && StrongEnemybullet != null && !StrongEnemybullet.Visible)
            {
                StrongEnemybullet.Left = StrongEnemy.Left - StrongEnemybullet.Width;
                StrongEnemybullet.Top = StrongEnemy.Top + StrongEnemy.Height / 2 - StrongEnemybullet.Height / 2;
                StrongEnemybullet.Visible = true;
            }
        }

        // BossEnemy mermisini ateşleme fonksiyonu
        private void BossEnemyFireTimer_Tick(object sender, EventArgs e)
        {
            if (BossEnemy != null && BossEnemybullet != null && !BossEnemybullet.Visible)
            {
                BossEnemybullet.Left = BossEnemy.Left - BossEnemybullet.Width;
                BossEnemybullet.Top = BossEnemy.Top + BossEnemy.Height / 2 - BossEnemybullet.Height / 2;
                BossEnemybullet.Visible = true;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (Spaceshipplayer != null)
            {
                spaceship.Move(e.KeyCode, Spaceshipplayer, this.ClientSize.Height);
            }

            if (e.KeyCode == Keys.Space)
            {
               Shoot();
            }
        }
        private void Shoot()
        {
            // Yeni bir PictureBox oluşturulup, mermi olarak ayarlanır
            PictureBox newBullet = new PictureBox();
            newBullet.Size = new Size(10, 5); // Merminin boyutunu ayarlayın
            newBullet.BackColor = Color.Yellow; // Merminin rengini ayarlayın
            newBullet.Top = Spaceshipplayer.Top + Spaceshipplayer.Height / 2 - 2; // Uzay gemisinin ortasında
            newBullet.Left = Spaceshipplayer.Right; // Uzay gemisinin sağ tarafından başlar

            // Yeni bir Bullet nesnesi oluşturulur ve listeye eklenir
            Bullet bullet = new Bullet(newBullet, bulletSpeed, 1); // Sağ yön (1) ile hareket edecek
            bullets.Add(bullet);

            // PictureBox'ı formda görünür yapalım
            this.Controls.Add(newBullet);

            // Timer başlatılır
            bulletTimer.Start();
        }
        private void BulletTimer_Tick(object sender, EventArgs e)
        {
            bulletMove();
        }
        private void bulletMove()
        {
            // Tüm mermiler için hareket etme
            foreach (Bullet bullet in bullets.ToList()) // bullets listesini değiştirirken hata almamak için ToList() kullanıyoruz
            {
                bullet.Move();

                // Mermi formun dışına çıkarsa, mermiyi gizle ve listeden çıkar
                if (bullet.BulletPictureBox.Right < 0 || bullet.BulletPictureBox.Left > this.ClientSize.Width)
                {
                    bullet.BulletPictureBox.Visible = false;
                    bullets.Remove(bullet); // Listeden çıkar
                }
            }
        }
        public void UpdateScoreLabel(int score)
        {
            scoreLabel.Text = $"Skor: {score}";
        }
        private void StrongEnemybullet_Click(object sender, EventArgs e)
        {

        }

        private void BasicEnemybullet_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
