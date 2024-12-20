namespace Space_War
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Spaceshipplayer = new System.Windows.Forms.PictureBox();
            this.FastEnemy = new System.Windows.Forms.PictureBox();
            this.BasicEnemy = new System.Windows.Forms.PictureBox();
            this.StrongEnemy = new System.Windows.Forms.PictureBox();
            this.BossEnemy = new System.Windows.Forms.PictureBox();
            this.FastEnemybullet = new System.Windows.Forms.PictureBox();
            this.BasicEnemybullet = new System.Windows.Forms.PictureBox();
            this.StrongEnemybullet = new System.Windows.Forms.PictureBox();
            this.BossEnemybullet = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Spaceshipplayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasicEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrongEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BossEnemy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastEnemybullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasicEnemybullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrongEnemybullet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BossEnemybullet)).BeginInit();
            this.SuspendLayout();
            // 
            // Spaceshipplayer
            // 
            this.Spaceshipplayer.Image = ((System.Drawing.Image)(resources.GetObject("Spaceshipplayer.Image")));
            this.Spaceshipplayer.Location = new System.Drawing.Point(47, 186);
            this.Spaceshipplayer.Name = "Spaceshipplayer";
            this.Spaceshipplayer.Size = new System.Drawing.Size(100, 100);
            this.Spaceshipplayer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Spaceshipplayer.TabIndex = 0;
            this.Spaceshipplayer.TabStop = false;
            // 
            // FastEnemy
            // 
            this.FastEnemy.Image = ((System.Drawing.Image)(resources.GetObject("FastEnemy.Image")));
            this.FastEnemy.Location = new System.Drawing.Point(1234, 24);
            this.FastEnemy.Name = "FastEnemy";
            this.FastEnemy.Size = new System.Drawing.Size(60, 70);
            this.FastEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.FastEnemy.TabIndex = 2;
            this.FastEnemy.TabStop = false;
            // 
            // BasicEnemy
            // 
            this.BasicEnemy.Image = ((System.Drawing.Image)(resources.GetObject("BasicEnemy.Image")));
            this.BasicEnemy.Location = new System.Drawing.Point(1234, 217);
            this.BasicEnemy.Name = "BasicEnemy";
            this.BasicEnemy.Size = new System.Drawing.Size(50, 60);
            this.BasicEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BasicEnemy.TabIndex = 3;
            this.BasicEnemy.TabStop = false;
            // 
            // StrongEnemy
            // 
            this.StrongEnemy.Image = ((System.Drawing.Image)(resources.GetObject("StrongEnemy.Image")));
            this.StrongEnemy.Location = new System.Drawing.Point(1234, 442);
            this.StrongEnemy.Name = "StrongEnemy";
            this.StrongEnemy.Size = new System.Drawing.Size(70, 80);
            this.StrongEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StrongEnemy.TabIndex = 4;
            this.StrongEnemy.TabStop = false;
            // 
            // BossEnemy
            // 
            this.BossEnemy.Image = ((System.Drawing.Image)(resources.GetObject("BossEnemy.Image")));
            this.BossEnemy.Location = new System.Drawing.Point(1220, 597);
            this.BossEnemy.Name = "BossEnemy";
            this.BossEnemy.Size = new System.Drawing.Size(135, 144);
            this.BossEnemy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BossEnemy.TabIndex = 5;
            this.BossEnemy.TabStop = false;
            // 
            // FastEnemybullet
            // 
            this.FastEnemybullet.Image = ((System.Drawing.Image)(resources.GetObject("FastEnemybullet.Image")));
            this.FastEnemybullet.Location = new System.Drawing.Point(1220, 55);
            this.FastEnemybullet.Name = "FastEnemybullet";
            this.FastEnemybullet.Size = new System.Drawing.Size(20, 10);
            this.FastEnemybullet.TabIndex = 6;
            this.FastEnemybullet.TabStop = false;
            // 
            // BasicEnemybullet
            // 
            this.BasicEnemybullet.Image = ((System.Drawing.Image)(resources.GetObject("BasicEnemybullet.Image")));
            this.BasicEnemybullet.Location = new System.Drawing.Point(1220, 241);
            this.BasicEnemybullet.Name = "BasicEnemybullet";
            this.BasicEnemybullet.Size = new System.Drawing.Size(20, 10);
            this.BasicEnemybullet.TabIndex = 7;
            this.BasicEnemybullet.TabStop = false;
            this.BasicEnemybullet.Click += new System.EventHandler(this.BasicEnemybullet_Click);
            // 
            // StrongEnemybullet
            // 
            this.StrongEnemybullet.Image = ((System.Drawing.Image)(resources.GetObject("StrongEnemybullet.Image")));
            this.StrongEnemybullet.Location = new System.Drawing.Point(1220, 479);
            this.StrongEnemybullet.Name = "StrongEnemybullet";
            this.StrongEnemybullet.Size = new System.Drawing.Size(20, 10);
            this.StrongEnemybullet.TabIndex = 8;
            this.StrongEnemybullet.TabStop = false;
            this.StrongEnemybullet.Click += new System.EventHandler(this.StrongEnemybullet_Click);
            // 
            // BossEnemybullet
            // 
            this.BossEnemybullet.Image = ((System.Drawing.Image)(resources.GetObject("BossEnemybullet.Image")));
            this.BossEnemybullet.Location = new System.Drawing.Point(1206, 666);
            this.BossEnemybullet.Name = "BossEnemybullet";
            this.BossEnemybullet.Size = new System.Drawing.Size(20, 10);
            this.BossEnemybullet.TabIndex = 9;
            this.BossEnemybullet.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.scoreLabel.Location = new System.Drawing.Point(13, 48);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 16);
            this.scoreLabel.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1497, 753);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.StrongEnemybullet);
            this.Controls.Add(this.BasicEnemybullet);
            this.Controls.Add(this.FastEnemybullet);
            this.Controls.Add(this.BossEnemy);
            this.Controls.Add(this.StrongEnemy);
            this.Controls.Add(this.BasicEnemy);
            this.Controls.Add(this.FastEnemy);
            this.Controls.Add(this.Spaceshipplayer);
            this.Controls.Add(this.BossEnemybullet);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Spaceshipplayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasicEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrongEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BossEnemy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FastEnemybullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BasicEnemybullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StrongEnemybullet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BossEnemybullet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Spaceshipplayer;
        private System.Windows.Forms.PictureBox FastEnemy;
        private System.Windows.Forms.PictureBox BasicEnemy;
        private System.Windows.Forms.PictureBox StrongEnemy;
        private System.Windows.Forms.PictureBox BossEnemy;
        private System.Windows.Forms.PictureBox FastEnemybullet;
        private System.Windows.Forms.PictureBox BasicEnemybullet;
        private System.Windows.Forms.PictureBox StrongEnemybullet;
        private System.Windows.Forms.PictureBox BossEnemybullet;
        private System.Windows.Forms.Label scoreLabel;
    }

}

