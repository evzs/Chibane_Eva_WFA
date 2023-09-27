using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Tile
    {
        public Image Texture { get; set; }

        public Tile()
        {
            AssignTexture();
        }

        public void AssignTexture()
        {
            Texture = Properties.Resources.TileBlue;
        }
    }
}
