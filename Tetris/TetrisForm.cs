using System.ComponentModel;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        // Define the game grid and the current block
        private PictureBox[,] gameGrid = new PictureBox[10, 20];
        private Block currentBlock;

        // TMP: Define the starting position of the block for current tests
        private int currentBlockX = 0;
        private int currentBlockY = 0;
        public TetrisForm()
        {
            InitializeComponent();

            // Initialize the game grid
            InitializeGameGrid();

            // Enable key events for the form
            this.KeyPreview = true;
            this.KeyDown += TetrisForm_KeyDown;

            // Create a new block and display it
            currentBlock = new Block();
            DisplayCurrentBlock();

            this.DoubleBuffered = true;
        }

        private void InitializeGameGrid()
        {
            int tileWidth = 30;
            int tileHeight = 30;

            // Create the grid of picture boxes

            // Loop through each row (y-axis) of the game grid
            for (int y = 0; y < 20; y++)
            {
                // Loop through each column (x-axis) of the game grid
                for (int x = 0; x < 10; x++)
                {
                    // Create a new PictureBox instance to represent a cell on the game grid
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.Width = tileWidth;
                    pictureBox.Height = tileHeight;
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;
                    pictureBox.BackColor = Color.Black;

                    // Calculate and set the position of the PictureBox on the game panel based on its x and y indices
                    pictureBox.Location = new Point(x * tileWidth, y * tileHeight);

                    gamePanel.Controls.Add(pictureBox);

                    // Store the PictureBox in the game grid array at the corresponding x and y indices
                    gameGrid[x, y] = pictureBox;

                }
            }
        }

        // Handle key events to move the block
        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && MoveX(-1, 0))
            {
                currentBlockX--;
                RefreshGameGrid();
            }
            else if (e.KeyCode == Keys.Right && MoveX(1, 0))
            {
                currentBlockX++;
                RefreshGameGrid();
            }
            else if (e.KeyCode == Keys.Down && MoveDown())
            {
                currentBlockY++;
                RefreshGameGrid();
            }
        }

        // Check if the block can move horizontally
        private bool MoveX(int dx, int dy)
        {
            for (int y = 0; y < currentBlock.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < currentBlock.CurrentMatrix.GetLength(1); x++)
                {
                    if (currentBlock.CurrentMatrix[y, x] == 1)
                    {
                        int newX = currentBlockX + x + dx;
                        int newY = currentBlockY + y + dy;

                        // Check boundaries
                        if (newX < 0 || newX >= 10 || newY < 0 || newY >= 20)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        // Check if the block can move down
        private bool MoveDown()
        {
            for (int y = 0; y < currentBlock.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < currentBlock.CurrentMatrix.GetLength(1); x++)
                {
                    if (currentBlock.CurrentMatrix[y, x] == 1)
                    {
                        int newX = currentBlockX + x;
                        int newY = currentBlockY + y + 1;

                        // Check boundaries
                        if (newX < 0 || newX >= 10 || newY < 0 || newY >= 20)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        // Refresh the game grid by clearing and redrawing the block
        private void RefreshGameGrid()
        {
            foreach (PictureBox pictureBox in gameGrid)
            {
                pictureBox.Image = null;
            }

            DisplayCurrentBlock();
        }

        // Display the current block on the game grid
        private void DisplayCurrentBlock()
        {
            currentBlock.DisplayBlock(gameGrid, currentBlockX, currentBlockY);
        }

        private void TetrisForm_Load(object sender, EventArgs e)
        {

        }
    }
}