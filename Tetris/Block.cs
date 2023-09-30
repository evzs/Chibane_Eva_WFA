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
        public BlockType BlockShape
        {
            get;
            set;
        }
        public Image Texture
        {
            get;
            private set;
        }
        public int[,] CurrentMatrix
        {
            get;
            private set;
        }

        private int rotationIndex = 0;
        public List<int[,]> Rotations
        {
            get;
            private set;
        }

        // Constructor to initialize a block with a random shape (random temporary here - maybe)
        public Block()
        {
            Random random = new Random();
            BlockShape = (BlockType)random.Next(0, Enum.GetValues(typeof(BlockType)).Length);
            // BlockShape = BlockType.Z;
            CreateBlock();
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

        public void Rotate()
        {
            System.Diagnostics.Debug.WriteLine("rotating");
            rotationIndex = (rotationIndex + 1) % Rotations.Count;
            CurrentMatrix = Rotations[rotationIndex];
        }

        // Method to create the block by assigning the texture and matrix for the block based on its shape
        public void CreateBlock()
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