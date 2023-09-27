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
        public Image Texture { get; private set; }
        public int[,] CurrentMatrix { get; private set; }
        public int[,][] Rotations { get; private set; }

        public Block() {
            Random random = new Random();
            BlockShape = (BlockType)random.Next(0, Enum.GetValues(typeof(BlockType)).Length);

        } 
    }
}

      