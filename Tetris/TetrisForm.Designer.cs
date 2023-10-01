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
            gamePanel = new Panel();
            scoreLabel = new Label();
            nextBlockPanel = new Panel();
            nextBlockLabel = new Label();
            rowsClearedLabel = new Label();
            heldBlockLabel = new Label();
            heldBlockPanel = new Panel();
            SuspendLayout();
            // 
            // gamePanel
            // 
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
            scoreLabel.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point);
            scoreLabel.Location = new Point(562, 22);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(0, 39);
            scoreLabel.TabIndex = 1;
            // 
            // nextBlockPanel
            // 
            nextBlockPanel.Location = new Point(562, 389);
            nextBlockPanel.Name = "nextBlockPanel";
            nextBlockPanel.Size = new Size(190, 179);
            nextBlockPanel.TabIndex = 2;
            nextBlockPanel.Paint += nextBlockPanel_Paint;
            // 
            // nextBlockLabel
            // 
            nextBlockLabel.AutoSize = true;
            nextBlockLabel.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point);
            nextBlockLabel.Location = new Point(566, 343);
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
            rowsClearedLabel.Location = new Point(566, 69);
            rowsClearedLabel.Name = "rowsClearedLabel";
            rowsClearedLabel.Size = new Size(0, 19);
            rowsClearedLabel.TabIndex = 4;
            rowsClearedLabel.Click += rowsClearedLabel_Click;
            // 
            // heldBlockLabel
            // 
            heldBlockLabel.AutoSize = true;
            heldBlockLabel.Font = new Font("Bahnschrift", 24F, FontStyle.Bold, GraphicsUnit.Point);
            heldBlockLabel.Location = new Point(31, 343);
            heldBlockLabel.Name = "heldBlockLabel";
            heldBlockLabel.Size = new Size(171, 39);
            heldBlockLabel.TabIndex = 5;
            heldBlockLabel.Text = "Held Block";
            heldBlockLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // heldBlockPanel
            // 
            heldBlockPanel.Location = new Point(22, 389);
            heldBlockPanel.Name = "heldBlockPanel";
            heldBlockPanel.Size = new Size(190, 192);
            heldBlockPanel.TabIndex = 3;
            heldBlockPanel.Paint += heldBlockPanel_Paint;
            // 
            // TetrisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(765, 600);
            Controls.Add(heldBlockPanel);
            Controls.Add(heldBlockLabel);
            Controls.Add(rowsClearedLabel);
            Controls.Add(nextBlockLabel);
            Controls.Add(nextBlockPanel);
            Controls.Add(scoreLabel);
            Controls.Add(gamePanel);
            DoubleBuffered = true;
            ForeColor = SystemColors.ControlLightLight;
            Name = "TetrisForm";
            Text = "Tetris";
            Load += TetrisForm_Load;
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
    }
}