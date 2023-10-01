using System;
using System.ComponentModel;
using System.Media;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        // Game state and progression
        private int score = 0;                      // Player's current score
        private int scoreMilestone = 0;             // Tracks score intervals for potential game adjustments
        private int totalRowsCleared = 0;           // Total number of cleared rows
        private bool gameOver = false;              // Indicates if the game has ended

        // Game timing and audio
        private System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer(); // Main game timer
        private System.Windows.Forms.Timer rowClearingTimer = new System.Windows.Forms.Timer(); // Timer for row clearing logic
        private SoundPlayer backgroundMusic;        // Audio background track for the game

        // Tetris blocks and movement
        private Block currentBlock;                 // The tetris block that's currently active and movable
        private int currentBlockX = 3;              // X-coordinate for the current block's position
        private int currentBlockY = 0;              // Y-coordinate for the current block's position
        private Block nextBlock;                    // The upcoming tetris block
        private Block heldBlock = null;             // Tetris block that's been held/swapped by the player
        private GhostBlock ghostBlock;              // A silhouette or preview of where the current block will land
        private bool blockSettled = false;          // Indicates if the current block has settled/locked in place
        private bool canSwap = true;                // Whether the player can swap the current block with the held block

        // Game grid and layout
        private PictureBox[,] gameGrid = new PictureBox[10, 20]; // Main game grid
        private bool[,] cellLocked = new bool[10, 20];           // Indicates which cells/blocks are locked in place
        private PictureBox[,] nextBlockPreview = new PictureBox[6, 6]; // UI element showing the upcoming block
        private PictureBox[,] heldBlockPreview = new PictureBox[6, 6]; // UI element showing the held/swapped block

        /* 
         * 
         *          Game 
         *      Initialization
         * 
         */
        public TetrisForm()
        {
            // Component and Form Initialization
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.KeyDown += TetrisForm_KeyDown;

            // Timers Initialization
            gameTimer.Interval = 1000;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();

            rowClearingTimer.Interval = 100;
            rowClearingTimer.Tick += RowClearingTimer_Tick;
            rowClearingTimer.Start();

            // Audio Setup
            PlayBackgroundMusic();

            // Game Grid and UI Setup
            InitializeGameGrid();
            InitializeHeldBlockPreview();
            InitializeNextBlockPreview();

            // Blocks Initialization
            currentBlock = new Block();
            DisplayNextBlock();
            DisplayCurrentBlock();
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

        // Initializes the panel and preview grid for the held block
        // This method sets the size of the panel, creates PictureBox controls for the preview grid,
        // and assigns them to the 'heldBlockPreview' array for future use
        private void InitializeHeldBlockPreview()
        {
            int tileWidth = 30;
            int tileHeight = 30;

            heldBlockPanel.Width = 6 * tileWidth;
            heldBlockPanel.Height = 6 * tileHeight;

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.Width = tileWidth;
                    pictureBox.Height = tileHeight;
                    pictureBox.BackColor = Color.Transparent;

                    pictureBox.Location = new Point(x * tileWidth, y * tileHeight);

                    heldBlockPanel.Controls.Add(pictureBox);

                    heldBlockPreview[x, y] = pictureBox;
                }
            }
        }

        // Initializes the panel and preview grid for the next block
        // Similar to 'InitializeHeldBlockPreview', this method sets the size of the panel,
        // creates PictureBox controls for the preview grid, and assigns them to the 'nextBlockPreview' array
        private void InitializeNextBlockPreview()
        {
            int tileWidth = 30;
            int tileHeight = 30;

            nextBlockPanel.Width = 6 * tileWidth;
            nextBlockPanel.Height = 6 * tileHeight;

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    PictureBox pictureBox = new PictureBox();

                    pictureBox.Width = tileWidth;
                    pictureBox.Height = tileHeight;
                    pictureBox.BackColor = Color.Transparent;

                    pictureBox.Location = new Point(x * tileWidth, y * tileHeight);

                    nextBlockPanel.Controls.Add(pictureBox);

                    nextBlockPreview[x, y] = pictureBox;
                }
            }
        }

        /* 
         * 
         *          Game 
         *          State
         * 
         */

        // Event handler for the game timer tick event, responsible for advancing the game state
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            // Check if the game is over; if so, do nothing and return
            if (gameOver) return;

            // Attempt to move the current block down by one grid cell
            if (MoveDown())
            {
                // If the move is successful, increment the current block's Y position
                currentBlockY++;
                // Refresh the game grid to reflect the updated block position
                RefreshGameGrid();
            }
            else
            {
                // If the block cannot move down further, it has reached its lowest position

                // Lock current block in its place
                LockCurrentBlock();

                // Swap current block with the next block to prepare for the next move
                currentBlock = nextBlock;

                // Reset the flag indicating that the block has settled in its final position
                blockSettled = false;

                // Set the initial position of the new current block
                currentBlockX = 3;
                currentBlockY = 0;

                DisplayCurrentBlock();

                // Generate a new next block and display it
                DisplayNextBlock();
            }
        }

        // Event handler for the row clearing timer tick event, responsible for checking and clearing completed rows
        private void RowClearingTimer_Tick(object sender, EventArgs e)
        {
            if (gameOver) return;
            RowCheck();
        }

        // Check for completed rows and clear them
        private void RowCheck()
        {
            int clearedRows = 0; // Counter for the number of cleared rows

            // Loop through the rows from the bottom to the top of the game grid
            for (int y = 19; y >= 0; y--)
            {
                if (IsRowCompleted(y))
                {
                    clearedRows++; // Increment the count of cleared rows
                    ClearRow(y); // Clear the completed row

                    // Shift all rows above the cleared row down by one position
                    ShiftRowsDown(y - 1);

                    // Restart the loop at the same position to re-check the newly shifted row
                    y++;
                }
            }

            totalRowsCleared += clearedRows; // Update the total number of cleared rows

            UpdateScore(clearedRows);
            AdjustGameSpeed(clearedRows);
            UpdateRowsCleared();
        }

        // Adjust the game speed based on the number of cleared rows
        private void AdjustGameSpeed(int clearedRows)
        {
            // Decrease the interval of the game timer to make the game faster
            // The interval reduction is proportional to the number of cleared rows, with a minimum interval of 100 milliseconds
            if (clearedRows > 0)
            {
                gameTimer.Interval = Math.Max(gameTimer.Interval - (50 * clearedRows), 100);
            }

            // Check if the player's score has reached a milestone
            if (score - scoreMilestone >= 1000)
            {
                // Increase the score milestone by 1000 to track the next milestone
                scoreMilestone += 1000;
            }
        }

        // Check if the game is over by examining the top row of the game grid
        // Returns true if any cell in the top row is locked (indicating a blocked top row)
        // otherwise returns false, indicating that the game can continue
        private bool IsGameOver()
        {
            for (int x = 0; x < 10; x++)
            {
                if (cellLocked[x, 0]) // 0 is the top row
                {
                    return true;
                }
            }
            return false;
        }

        /*                             
         *                  
         *              Display
         *                and
         *              Rendering
         * 
         */

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

        // Clear the current block on the game grid
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

        // Display the next block on the next block preview grid
        private void DisplayNextBlock()
        {
            nextBlock = new Block();
            DisplayNextBlockPreview();
        }

        private void DisplayNextBlockPreview()
        {
            ClearNextBlockPreview();

            // Calculate the center position of the preview grid
            int centerX = (nextBlockPreview.GetLength(0) - 1) / 2;
            int centerY = (nextBlockPreview.GetLength(1) - 1) / 2;

            // Calculate the center position of the current block's matrix
            int blockCenterX = (nextBlock.CurrentMatrix.GetLength(0) - 1) / 2;
            int blockCenterY = (nextBlock.CurrentMatrix.GetLength(1) - 1) / 2;

            // Calculate the starting position for rendering the block preview
            int startX = centerX - blockCenterX;
            int startY = centerY - blockCenterY;

            for (int y = 0; y < nextBlock.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < nextBlock.CurrentMatrix.GetLength(1); x++)
                {
                    if (nextBlock.CurrentMatrix[y, x] == 1)
                    {
                        PictureBox pictureBox = nextBlockPreview[startX + x, startY + y];
                        pictureBox.Image = nextBlock.Texture;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void ClearNextBlockPreview()
        {
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    nextBlockPreview[x, y].Image = null;
                }
            }
        }

        // Display the held block on the held block preview grid
        private void DisplayHeldBlock()
        {
            if (heldBlock == null)
                return;

            DisplayHeldBlockPreview();
        }

        private void DisplayHeldBlockPreview()
        {
            ClearHeldBlockPreview();

            int centerX = (heldBlockPreview.GetLength(0) - 1) / 2;
            int centerY = (heldBlockPreview.GetLength(1) - 1) / 2;
            int blockCenterX = (heldBlock.CurrentMatrix.GetLength(0) - 1) / 2;
            int blockCenterY = (heldBlock.CurrentMatrix.GetLength(1) - 1) / 2;

            int startX = centerX - blockCenterX;
            int startY = centerY - blockCenterY;

            for (int y = 0; y < heldBlock.CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < heldBlock.CurrentMatrix.GetLength(1); x++)
                {
                    if (heldBlock.CurrentMatrix[y, x] == 1)
                    {
                        PictureBox pictureBox = heldBlockPreview[startX + x, startY + y];
                        pictureBox.Image = heldBlock.Texture;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void ClearHeldBlockPreview()
        {
            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    heldBlockPreview[x, y].Image = null;
                }
            }
        }

        /*
         * 
         *      Block Movements
         *        and Actions
         * 
         */

        // Event handler for key events to control the movement and actions of the Tetris block
        private void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            // Create a copy of the current block's matrix before any potential changes
            int[,] previousMatrix = (int[,])currentBlock.CurrentMatrix.Clone();

            // Check if the block has settled or if the game is over - if so, do nothing and return
            if (blockSettled || gameOver) return;

            // Handle key events to move the block
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
                    // Clear the current block from the grid, rotate it, and check if the new position is valid
                    ClearCurrentBlock();
                    currentBlock.Rotate();

                    if (!PositionCheck(currentBlock, currentBlockX, currentBlockY))
                    {
                        System.Diagnostics.Debug.WriteLine("Invalid position after rotation!");
                        currentBlock.SetMatrix(previousMatrix);
                    }

                    RefreshGameGrid();
                    break;
                case Keys.Space:
                    // Perform a hard drop to instantly move the block to the lowest possible position
                    HardDrop();
                    break;
                case Keys.ShiftKey:
                    // Hold first block - Swap the current block with the held block (if any)
                    BlockSwap();
                    break;
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

        private void HardDrop()
        {
            // Keep moving the block down as long as it can move
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
            currentBlock = nextBlock;
            currentBlockX = 3;
            currentBlockY = 0;
            DisplayCurrentBlock();
            DisplayNextBlock();
        }

        // Swap the current Tetris block with the held block (if available)
        private void BlockSwap()
        {
            // If no block is currently held, swap the current block to held block
            if (heldBlock == null)
            {
                heldBlock = currentBlock;
                DisplayHeldBlock();
                currentBlock = nextBlock;
                currentBlockX = 3;
                currentBlockY = 0;
                DisplayCurrentBlock();
                DisplayNextBlock();
                canSwap = false;
            }
            else if (canSwap)
            {
                // If a block is already held and a swap is allowed, perform the swap
                Block temp = currentBlock;
                currentBlock = heldBlock;
                heldBlock = temp;
                DisplayHeldBlock();
                currentBlockX = 3;
                currentBlockY = 0;
                DisplayCurrentBlock();
                canSwap = false; // Prevent further swaps during this turn
            }
        }

        // Lock the current Tetris block in its current position on the game grid
        private void LockCurrentBlock()
        {
            blockSettled = true; // Set the flag to indicate that the block has settled in its final position

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
            // Check if the game is over (top row is blocked)
            if (IsGameOver())
            {
                gameTimer.Stop(); // Stop the game timer
                rowClearingTimer.Stop(); ; // Stop the row clearing timer
                gameOver = true; // Set the game over flag
                MessageBox.Show("Game Over!");
            }
            canSwap = true; // Allow block swapping again after locking
        }

        /*
         * 
         * Game Logic
         * 
         */

        // Check if a specific row is completely filled with locked cells (blocks)
        private bool IsRowCompleted(int row)
        {
            for (int x = 0; x < 10; x++)
            {
                // If any cell in the row is not locked, the row isn't complete
                if (!cellLocked[x, row]) 
                    return false;
            }
            return true;
        }

        // Clear all cells in a specific row by removing their images and unlocking them
        private void ClearRow(int row)
        {
            for (int x = 0; x < 10; x++)
            {
                gameGrid[x, row].Image = null;
                cellLocked[x, row] = false;
            }
        }

        // Shift all rows starting from startY downwards to fill any cleared rows
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

        private void UpdateRowsCleared()
        {
            rowsClearedLabel.Text = $"Rows Cleared: {totalRowsCleared}";
            rowsClearedLabel.BackColor = Color.Transparent;
        }

        // Update the player's score based on the number of rows cleared
        private void UpdateScore(int clearedRows)
        {
            switch (clearedRows)
            {
                // Calculate and update the score based on the number of rows cleared
                case 1: score += 100; break;
                case 2: score += 300; break;
                case 3: score += 500; break;
                case 4: score += 800; break;
            }
            scoreLabel.Text = $"Score: {score}";
            scoreLabel.BackColor = Color.Transparent;
        }

        // Check if a given position for a Tetris block is valid (no collisions or boundary hits)
        private bool PositionCheck(Block block, int posX, int posY)
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

        /*
         * Audio
         */

        private void PlayBackgroundMusic()
        {
            backgroundMusic = new SoundPlayer(Properties.Resources.Music);
            backgroundMusic.PlayLooping();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            backgroundMusic?.Stop();
        }

        private void TetrisForm_Load(object sender, EventArgs e)
        {

        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextBlockPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void nextBlockLabel_Click(object sender, EventArgs e)
        {

        }

        private void rowsClearedLabel_Click(object sender, EventArgs e)
        {

        }

        private void heldBlockLabel_Click(object sender, EventArgs e)
        {

        }

        private void heldBlockPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void controlsLabel_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}