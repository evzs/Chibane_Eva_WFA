using System.ComponentModel;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        private PictureBox[,] gameGrid = new PictureBox[10, 20];
        private Block currentBlock;
        public TetrisForm()
        {
            InitializeComponent();

            InitializeGameGrid();

            currentBlock = new Block();
            currentBlock.DisplayBlock(gameGrid, 0, 3);
        }

    

        private void InitializeGameGrid()
        {
            int tileWidth = 30;
            int tileHeight = 30;




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
        }



        private void TetrisForm_Load(object sender, EventArgs e)
        {

        }
    }
}