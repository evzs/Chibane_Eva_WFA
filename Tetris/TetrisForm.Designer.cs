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
            SuspendLayout();
            // 
            // gamePanel
            // 
            gamePanel.Location = new Point(235, 0);
            gamePanel.Name = "gamePanel";
            gamePanel.Size = new Size(300, 600);
            gamePanel.TabIndex = 0;
            // 
            // TetrisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(765, 600);
            Controls.Add(gamePanel);
            Name = "TetrisForm";
            Text = "Tetris";
            Load += TetrisForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel gamePanel;
    }
}