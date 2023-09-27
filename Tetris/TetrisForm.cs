using System.ComponentModel;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        private PictureBox[,] gameGrid = new PictureBox[10, 20];
        public TetrisForm()
        {
            InitializeComponent();

            InitializeGameGrid();
        }

       private void DisplayBlock(int[,] blockMatrix, int startX, int startY, Image blockImage)
{
    for (int x = 0; x < blockMatrix.GetLength(0); x++)
    {
        for (int y = 0; y < blockMatrix.GetLength(1); y++)
        {
            int gridX = startX + x;
            int gridY = startY + y;

            if (blockMatrix[x, y] == 1 && gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 20)
            {
                        PictureBox pictureBox = gameGrid[gridY, gridX];

                        pictureBox.Image = blockImage;
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}




        private void InitializeGameGrid()
        {
            int tileWidth = 30;
            int tileHeight = 30;
            int[,] BlockMatrix = {
    { 1, 1, 1 },
    { 0, 1, 0 }
};



            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 20; y++)
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
            DisplayBlock(BlockMatrix, 0, 3, Properties.Resources.TileBlue);
        }



        private void TetrisForm_Load(object sender, EventArgs e)
        {

        }
    }
}