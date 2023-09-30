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
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.Location = new Point(235, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(300, 600);
            gamePanel.TabIndex = 0;
            // 
            // scoreLabel
            // 
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(638, 55);
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Size = new Size(0, 15);
            scoreLabel.TabIndex = 1;
            // 
            // nextBlockPanel
            // 
            nextBlockPanel.Location = new Point(22, 100);
            nextBlockPanel.Name = "nextBlockPanel";
            nextBlockPanel.Size = new Size(176, 220);
            nextBlockPanel.TabIndex = 2;
            // 
            // TetrisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 600);
            Controls.Add(nextBlockPanel);
            Controls.Add(scoreLabel);
            Controls.Add(gamePanel);
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
    }
}