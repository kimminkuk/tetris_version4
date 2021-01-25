using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace tetris.Models
{
    public class Constants
    {
        public enum TETRIS { MOVE_RIGHT = 1, MOVE_LEFT, MOVE_DOWN }
        public enum BLOCK { Block_1 = 1, Block_2, Block_3, Block_4, Block_5, Block_6, Block_7 }

        public const int Block_wall = -1;
        public const int Block_background = 0;

    }
}
