using System.ComponentModel;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        private PictureBox[,] gameGrid = new PictureBox[10, 20];
        private Block currentBlock;
        private int currentBlockX = 3; 
        private int currentBlockY = 0;
        public TetrisForm()
        {
            InitializeComponent();

            InitializeGameGrid();

            this.KeyPreview = true;
            this.KeyDown += TetrisForm_KeyDown;

            currentBlock = new Block();
            DisplayCurrentBlock();

            this.DoubleBuffered = true;
        }



        private void InitializeGameGrid()
        {
            int tileWidth = 30;
            int tileHeight = 30;




            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.Width = tileWidth;
                    pictureBox.Height = tileHeight;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.BackColor = Color.Black;
                    pictureBox.Location = new Point(x * tileWidth, y * tileHeight);

                    gamePanel.Controls.Add(pictureBox);

                    gameGrid[x, y] = pictureBox;

                }
            }
        }

        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && CanMove(-1, 0))
            {
                currentBlockX--;  
                RefreshGameGrid();
            }
            else if (e.KeyCode == Keys.Right && CanMove(1, 0))
            {
                currentBlockX++; 
                RefreshGameGrid();
            }
      
        }

        private bool CanMove(int dx, int dy)
        {
            for (int y = 0; y < currentBlock.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < currentBlock.CurrentMatrix.GetLength(1); x++)
                {
                    if (currentBlock.CurrentMatrix[y, x] == 1)
                    {
                        int newX = currentBlockX + x + dx;
                        int newY = currentBlockY + y + dy;
                        if (newX < 0 || newX >= 10 || newY < 0 || newY >= 20)
                        {
                            return false;
                        }

                        // TODO: Check for collisions with other blocks
                    }
                }
            }
            return true;
        }


        private void RefreshGameGrid()
        {
            foreach (PictureBox pictureBox in gameGrid)
            {
                pictureBox.Image = null;
            }

            DisplayCurrentBlock();
        }

        private void DisplayCurrentBlock()
        {
            currentBlock.DisplayBlock(gameGrid, currentBlockX, currentBlockY);
        }



        private void TetrisForm_Load(object sender, EventArgs e)
        {

        }
    }
}