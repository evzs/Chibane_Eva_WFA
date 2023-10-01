namespace Tetris
{
    partial class TetrisForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TetrisForm));
            gamePanel = new Panel();
            scoreLabel = new Label();
            nextBlockPanel = new Panel();
            nextBlockLabel = new Label();
            rowsClearedLabel = new Label();
            heldBlockLabel = new Label();
            heldBlockPanel = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox6 = new PictureBox();
            pictureBox3 = new PictureBox();
            controlsLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.BackColor = Color.Transparent;
            gamePanel.Font = new Font("Verdana", 24F, FontStyle.Bold, GraphicsUnit.Point);
            gamePanel.Location = new Point(235, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(300, 600);
            gamePanel.TabIndex = 0;
            gamePanel.Paint += gamePanel_Paint;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Font = new Font("Bahnschrift", 18F, FontStyle.Bold, GraphicsUnit.Point);
            scoreLabel.Location = new Point(557, 297);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(0, 29);
            scoreLabel.TabIndex = 1;
            // 
            // nextBlockPanel
            // 
            nextBlockPanel.BackColor = Color.Transparent;
            nextBlockPanel.Location = new Point(558, 68);
            nextBlockPanel.Name = "nextBlockPanel";
            nextBlockPanel.Size = new Size(190, 179);
            nextBlockPanel.TabIndex = 2;
            nextBlockPanel.Paint += nextBlockPanel_Paint;
            // 
            // nextBlockLabel
            // 
            nextBlockLabel.AutoSize = true;
            nextBlockLabel.BackColor = Color.Transparent;
            nextBlockLabel.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point);
            nextBlockLabel.Location = new Point(562, 22);
            nextBlockLabel.Name = "nextBlockLabel";
            nextBlockLabel.Size = new Size(172, 39);
            nextBlockLabel.TabIndex = 3;
            nextBlockLabel.Text = "Next Block";
            nextBlockLabel.TextAlign = ContentAlignment.TopCenter;
            nextBlockLabel.Click += nextBlockLabel_Click;
            // 
            // rowsClearedLabel
            // 
            rowsClearedLabel.AutoSize = true;
            rowsClearedLabel.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point);
            rowsClearedLabel.Location = new Point(558, 337);
            rowsClearedLabel.Name = "rowsClearedLabel";
            rowsClearedLabel.Size = new Size(0, 19);
            rowsClearedLabel.TabIndex = 4;
            rowsClearedLabel.Click += rowsClearedLabel_Click;
            // 
            // heldBlockLabel
            // 
            heldBlockLabel.AutoSize = true;
            heldBlockLabel.BackColor = Color.Transparent;
            heldBlockLabel.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point);
            heldBlockLabel.Location = new Point(30, 24);
            heldBlockLabel.Name = "heldBlockLabel";
            heldBlockLabel.Size = new Size(171, 39);
            heldBlockLabel.TabIndex = 5;
            heldBlockLabel.Text = "Held Block";
            heldBlockLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // heldBlockPanel
            // 
            heldBlockPanel.BackColor = Color.Transparent;
            heldBlockPanel.Location = new Point(21, 70);
            heldBlockPanel.Name = "heldBlockPanel";
            heldBlockPanel.Size = new Size(190, 192);
            heldBlockPanel.TabIndex = 3;
            heldBlockPanel.Paint += heldBlockPanel_Paint;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(30, 337);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(27, 26);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.BackColor = Color.Transparent;
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(30, 443);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(60, 31);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.BackColor = Color.Transparent;
            pictureBox5.BackgroundImage = (Image)resources.GetObject("pictureBox5.BackgroundImage");
            pictureBox5.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox5.Location = new Point(30, 369);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(27, 26);
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(63, 369);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(27, 26);
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackColor = Color.Transparent;
            pictureBox6.BackgroundImage = (Image)resources.GetObject("pictureBox6.BackgroundImage");
            pictureBox6.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox6.Location = new Point(30, 401);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(27, 26);
            pictureBox6.TabIndex = 8;
            pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = Color.Transparent;
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(30, 498);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(60, 31);
            pictureBox3.TabIndex = 9;
            pictureBox3.TabStop = false;
            // 
            // controlsLabel
            // 
            controlsLabel.AutoSize = true;
            controlsLabel.BackColor = Color.Transparent;
            controlsLabel.Font = new Font("Bahnschrift", 18F, FontStyle.Bold, GraphicsUnit.Point);
            controlsLabel.Location = new Point(21, 297);
            controlsLabel.Name = "controlsLabel";
            controlsLabel.Size = new Size(104, 29);
            controlsLabel.TabIndex = 10;
            controlsLabel.Text = "Controls";
            controlsLabel.Click += controlsLabel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bahnschrift SemiLight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(60, 339);
            label1.Name = "label1";
            label1.Size = new Size(93, 18);
            label1.TabIndex = 11;
            label1.Text = "Rotate Block";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bahnschrift SemiLight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(95, 372);
            label2.Name = "label2";
            label2.Size = new Size(116, 18);
            label2.TabIndex = 12;
            label2.Text = "Move Left/Right";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Bahnschrift SemiLight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(63, 404);
            label3.Name = "label3";
            label3.Size = new Size(86, 18);
            label3.TabIndex = 13;
            label3.Text = "Move Down";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Bahnschrift SemiLight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(96, 448);
            label4.Name = "label4";
            label4.Size = new Size(76, 18);
            label4.TabIndex = 14;
            label4.Text = "Hard Drop";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Bahnschrift SemiLight", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(95, 503);
            label5.Name = "label5";
            label5.Size = new Size(123, 18);
            label5.TabIndex = 15;
            label5.Text = "Hold/Swap Block";
            label5.Click += label5_Click;
            // 
            // TetrisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(765, 600);
            Controls.Add(label5);
            Controls.Add(heldBlockPanel);
            Controls.Add(controlsLabel);
            Controls.Add(label4);
            Controls.Add(heldBlockLabel);
            Controls.Add(pictureBox4);
            Controls.Add(rowsClearedLabel);
            Controls.Add(label3);
            Controls.Add(nextBlockLabel);
            Controls.Add(pictureBox1);
            Controls.Add(nextBlockPanel);
            Controls.Add(label2);
            Controls.Add(scoreLabel);
            Controls.Add(pictureBox5);
            Controls.Add(gamePanel);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox6);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlLightLight;
            MaximumSize = new Size(781, 639);
            MinimumSize = new Size(781, 639);
            Name = "TetrisForm";
            Text = "Tetris";
            Load += TetrisForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel gamePanel;
        private Label scoreLabel;
        private Panel nextBlockPanel;
        private Label nextBlockLabel;
        private Label rowsClearedLabel;
        private Label heldBlockLabel;
        private Panel heldBlockPanel;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private PictureBox pictureBox2;
        private PictureBox pictureBox6;
        private PictureBox pictureBox3;
        private Label controlsLabel;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}