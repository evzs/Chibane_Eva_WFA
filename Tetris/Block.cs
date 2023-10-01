using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum BlockType
    {
        I,
        L,
        J,
        S,
        Z,
        O,
        T
    }

    public class Block
    {
        public BlockType BlockShape { get; set; }
        public Image Texture { get; protected set; }
        public int[,] CurrentMatrix { get; private set; }

        private int rotationIndex = 0;
        public List<int[,]> Rotations { get; private set; }

        private static Random random = new Random();
        private static List<BlockType> bag = new List<BlockType>();

        // Constructor to initialize a block with a random shape (using the 7 bag system)
        public Block()
        {
            if (bag.Count == 0)
                RefillBag();

            BlockShape = bag[0];
            bag.RemoveAt(0);

            CreateBlock();
        }

        private static void RefillBag()
        {
            bag.AddRange(Enum.GetValues(typeof(BlockType)).Cast<BlockType>());

            // Shuffle the bag
            int n = bag.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                BlockType value = bag[k];
                bag[k] = bag[n];
                bag[n] = value;
            }
        }

        public void DisplayBlock(PictureBox[,] gameGrid, int startX, int startY)
        {
            // Loop through each row of the block's matrix
            for (int y = 0; y < CurrentMatrix.GetLength(0); y++)
            {
                // Loop through each column of the block's matrix
                for (int x = 0; x < CurrentMatrix.GetLength(1); x++)
                {
                    // Calculate the actual X position on the game grid by adding the block's starting X position
                    int gridX = startX + x;

                    // Calculate the actual Y position on the game grid by adding the block's starting Y position
                    int gridY = startY + y;

                    // Check if the current cell of the block is active (has a value of 1)
                    // and if its calculated position is within the boundaries of the game grid
                    if (CurrentMatrix[y, x] == 1 && gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 20)
                    {
                        PictureBox pictureBox = gameGrid[gridX, gridY];
                        pictureBox.Image = Texture;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        public void SetMatrix(int[,] matrix)
        {
            CurrentMatrix = matrix;
        }

        protected void SetTexture(Image texture)
        {
            this.Texture = texture;
        }

        public void Rotate()
        {
            System.Diagnostics.Debug.WriteLine("rotating");
            rotationIndex = (rotationIndex + 1) % Rotations.Count;
            CurrentMatrix = Rotations[rotationIndex];
        }

        // Method to create the block by assigning the texture and matrix for the block based on its shape
        public virtual void CreateBlock()
        {
            switch (BlockShape)
            {
                case BlockType.I:
                    Texture = Properties.Resources.TileCyan;
                    Rotations = new List<int[,]>
            {
                new int[,] { 
                { 0, 0, 0, 0 }, 
                { 1, 1, 1, 1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
                },
                new int[,] {
                    { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 1, 0 } },
                new int[,] { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 } },
                new int[,] { { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 }, { 0, 1, 0, 0 } }
            };
                    break;
                case BlockType.J:
                    Texture = Properties.Resources.TileBlue;
                    Rotations = new List<int[,]>
            {
                new int[,] { { 1, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } },
                new int[,] { { 0, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } },
                new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 1 } },
                new int[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 1, 1, 0 } }
            };
                    break;
                case BlockType.L:
                    Texture = Properties.Resources.TileOrange;
                    Rotations = new List<int[,]>
            {
                new int[,] { { 0, 0, 1 }, { 1, 1, 1 }, { 0, 0, 0 } },
                new int[,] { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } },
                new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 1, 0, 0 } },
                new int[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } }
            };
                    break;
                case BlockType.O:
                    Texture = Properties.Resources.TileYellow;
                    Rotations = new List<int[,]>
            {
                new int[,] { { 1, 1 }, { 1, 1 } }
            };
                    break;
                case BlockType.S:
                    Texture = Properties.Resources.TileGreen;
                    Rotations = new List<int[,]>
            {
                new int[,] {
                { 0, 1, 1 },
                { 1, 1, 0 },
                { 0, 0, 0 }
                },
                new int[,] {
                { 0, 1, 0 },
                { 0, 1, 1 },
                { 0, 0, 1 } 
                },
                new int[,] {
                { 0, 0, 0 },
                { 0, 1, 1 },
                { 1, 1, 0 }
                },
                new int[,] {
                { 1, 0, 0 },
                { 1, 1, 0 },
                { 0, 1, 0 }
                }
            };
                    break;
                case BlockType.T:
                    Texture = Properties.Resources.TilePurple;
                    Rotations = new List<int[,]>
            {
                new int[,] { { 0, 1, 0 }, { 1, 1, 1 }, { 0, 0, 0 } },
                new int[,] { { 0, 1, 0 }, { 0, 1, 1 }, { 0, 1, 0 } },
                new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 1, 0 } },
                new int[,] { { 0, 1, 0 }, { 1, 1, 0 }, { 0, 1, 0 } }
            };
                    break;
                case BlockType.Z:
                    Texture = Properties.Resources.TileRed;
                    Rotations = new List<int[,]>
            {
                new int[,] { 
                { 1, 1, 0 }, 
                { 0, 1, 1 }, 
                { 0, 0, 0 }
                },
                new int[,] {
                    { 0, 0, 1 },
                    { 0, 1, 1 },
                    { 0, 1, 0 }
                },
                new int[,] {
                    { 0, 0, 0 },
                    { 1, 1, 0 },
                    { 0, 1, 1 } },
                new int[,] {
                    { 0, 1, 0 },
                    { 1, 1, 0 },
                    { 1, 0, 0 } }
            };
                    break;
                default:
                    break;
            }
            CurrentMatrix = Rotations[0];
        }

    }
}