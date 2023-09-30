using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class GhostBlock : Block
    {
        public GhostBlock(BlockType type) : base()
        {
            BlockShape = type;
            CreateBlock();
        }
    }

}
