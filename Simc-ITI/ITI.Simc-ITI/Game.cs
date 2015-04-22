using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Simc_ITI;

namespace ITI.Simc_ITI
{
    class Game
    {
        private Box[,] _boxes;
        public Game(int boxPerLine, int boxWidth)
        {
            _boxes = new Box[boxPerLine, boxPerLine];

            for (int i = 0; i < boxPerLine; i++)
            {
                for (int j = 0; j < boxPerLine; j++)
                {
                    _boxes[i, j] = new Box(i * boxWidth, j * boxWidth, boxWidth, boxWidth);
                }
            }

        }

        public void Draw(Graphics g)
        {
            foreach (Box b in _boxes)
            {
                b.Draw(g);
            }
        }

        public void Update()
        {

        }
    }
}
