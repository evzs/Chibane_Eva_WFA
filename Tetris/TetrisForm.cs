using System;
using System.ComponentModel;

namespace Tetris
{
    public partial class TetrisForm : Form
    {

        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer rowClearingTimer = new System.Windows.Forms.Timer();

        private bool blockSettled = false;

        // Define the game grid and the current block
        private PictureBox[,] gameGrid = new PictureBox[10, 20];
        private Block currentBlock;

        // TMP: Define the starting position of the block for current tests
        private int currentBlockX = 3;
        private int currentBlockY = 0;

        private bool[,] cellLocked = new bool[10, 20];

        public TetrisForm()
        {

            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            rowClearingTimer.Interval = 100; 
            rowClearingTimer.Tick += RowClearingTimer_Tick;
            rowClearingTimer.Start();

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

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (MoveDown())
            {
                currentBlockY++;
                RefreshGameGrid();
            }
            else
            {
                // Lock current block in its place
                LockCurrentBlock();

                // Reset the flag for the next block
                blockSettled = false;

                // Create a new block
                currentBlock = new Block();
                currentBlockX = 3;
                currentBlockY = 0;
                DisplayCurrentBlock();
            }
        }
        private void RowClearingTimer_Tick(object sender, EventArgs e)
        {
            RowCheck();  // Check and clear completed rows at each tick
        }


        // Handle key events to move the block
        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)


        {
            int[,] previousMatrix = (int[,])currentBlock.CurrentMatrix.Clone();
            if (blockSettled) return;
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (MoveX(-1, 0))
                    {
                        currentBlockX--;
                        RefreshGameGrid();
                    }
                    break;

                case Keys.Right:
                    if (MoveX(1, 0))
                    {
                        currentBlockX++;
                        RefreshGameGrid();
                    }
                    break;

                case Keys.Down:
                    if (MoveDown())
                    {
                        currentBlockY++;
                        RefreshGameGrid();
                    }
                    break;

                case Keys.Up:
                    ClearCurrentBlock();
                    currentBlock.Rotate();

                    if (!positionCheck(currentBlock, currentBlockX, currentBlockY))
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid position after rotation!");
                        currentBlock.SetMatrix(previousMatrix);
                    }

                    RefreshGameGrid();
                    break;
                case Keys.Space:
                    HardDrop();
                    break;
            }
        }

        private void HardDrop()
        {
            while (MoveDown())
            {
                currentBlockY++;
            }

            // Lock the block in place after it has been hard-dropped
            LockCurrentBlock();

            // Reset the flag for the next block
            blockSettled = false;

            // Refresh the game grid to display the locked block
            RefreshGameGrid();

            // Generate a new block and display it
            currentBlock = new Block();
            currentBlockX = 3;  // Ensure that the new block starts from a centralized position
            currentBlockY = 0;
            DisplayCurrentBlock();
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

                        // Check for collisions with settled blocks
                        if (cellLocked[newX, newY])
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

                        // Check for collisions with settled blocks
                        if (cellLocked[newX, newY])
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
            System.Diagnostics.Debug.WriteLine("Refreshing game grid!");

            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (!cellLocked[x, y])
                    {
                        gameGrid[x, y].Image = null;
                    }
                }
            }

            DisplayCurrentBlock();
        }


        private void ClearCurrentBlock()
        {
            // Loop through each row of the block's matrix
            for (int y = 0; y < currentBlock.CurrentMatrix.GetLength(0); y++)
            {
                // Loop through each column of the block's matrix
                for (int x = 0; x < currentBlock.CurrentMatrix.GetLength(1); x++)
                {
                    // Calculate the actual X position on the game grid by adding the block's starting X position
                    int gridX = currentBlockX + x;

                    // Calculate the actual Y position on the game grid by adding the block's starting Y position
                    int gridY = currentBlockY + y;

                    // Check if the current cell of the block is active (has a value of 1)
                    // and if its calculated position is within the boundaries of the game grid
                    // and if the cell is not locked
                    if (currentBlock.CurrentMatrix[y, x] == 1 && gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 20 && !cellLocked[gridX, gridY])
                    {
                        gameGrid[gridX, gridY].Image = null;
                    }
                }
            }
        }



        // Display the current block on the game grid
        private void DisplayCurrentBlock()
        {
            // Loop through each row of the block's matrix
            for (int y = 0; y < currentBlock.CurrentMatrix.GetLength(0); y++)
            {
                // Loop through each column of the block's matrix
                for (int x = 0; x < currentBlock.CurrentMatrix.GetLength(1); x++)
                {
                    // Calculate the actual X position on the game grid by adding the block's starting X position
                    int gridX = currentBlockX + x;

                    // Calculate the actual Y position on the game grid by adding the block's starting Y position
                    int gridY = currentBlockY + y;

                    // Check if the current cell of the block is active (has a value of 1)
                    // and if its calculated position is within the boundaries of the game grid
                    // and if the cell is not locked
                    if (currentBlock.CurrentMatrix[y, x] == 1 && gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 20 && !cellLocked[gridX, gridY])
                    {
                        PictureBox pictureBox = gameGrid[gridX, gridY];
                        pictureBox.Image = currentBlock.Texture;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void LockCurrentBlock()
        {
            blockSettled = true;

            for (int y = 0; y < currentBlock.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < currentBlock.CurrentMatrix.GetLength(1); x++)
                {
                    if (currentBlock.CurrentMatrix[y, x] == 1)
                    {
                        int gridX = currentBlockX + x;
                        int gridY = currentBlockY + y;

                        if (gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 20)
                        {
                            cellLocked[gridX, gridY] = true; // Locking the cell
                            gameGrid[gridX, gridY].Image = currentBlock.Texture;
                            gameGrid[gridX, gridY].SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                }
            }
        }



        private bool positionCheck(Block block, int posX, int posY)
        {
            for (int y = 0; y < block.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < block.CurrentMatrix.GetLength(1); x++)
                {
                    if (block.CurrentMatrix[y, x] == 1)
                    {
                        int newX = posX + x;
                        int newY = posY + y;

                        // Check boundaries
                        if (newX < 0 || newX >= 10 || newY < 0 || newY >= 20)
                        {
                            System.Diagnostics.Debug.WriteLine($"Boundary hit: ({newX}, {newY})");
                            return false;
                        }

                        // Check collisions with other blocks
                        if (gameGrid[newX, newY].Image != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"Collision at: ({newX}, {newY})");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void RowCheck()
        {
            for (int y = 19; y >= 0; y--)
            {
                if (IsRowCompleted(y))
                {
                    ClearRow(y);
                    ShiftRowsDown(y - 1);
                    y++;
                }
            }
        }

        private bool IsRowCompleted(int row)
        {
            for (int x = 0; x < 10; x++)
            {
                if (!cellLocked[x, row]) // If any cell in the row is not locked, the row isn't complete
                    return false;
            }
            return true;
        }

        private void ClearRow(int row)
        {
            for (int x = 0; x < 10; x++)
            {
                gameGrid[x, row].Image = null;
                cellLocked[x, row] = false;
            }
        }

        private void ShiftRowsDown(int startY)
        {
            for (int y = startY; y >= 0; y--)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (y == 0)
                    {
                        gameGrid[x, y].Image = null;
                        cellLocked[x, y] = false;
                    }
                    else
                    {
                        gameGrid[x, y + 1].Image = gameGrid[x, y].Image;
                        cellLocked[x, y + 1] = cellLocked[x, y];
                    }
                }
            }
        }



        private void TetrisForm_Load(object sender, EventArgs e)
        {

        }
    }
}