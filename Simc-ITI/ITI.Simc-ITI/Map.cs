using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Simc_ITI;
using System.Diagnostics;
using ITI.Simc_ITI.Lib;

namespace ITI.Simc_ITI
{
    public class Map
    {
        readonly Box[,] _boxes;
        readonly int _boxCount;
        readonly int _boxWidth;
        readonly int _mapWidth;

        public Map(int boxCount, int boxWidth)
        {
            _boxes = new Box[boxCount, boxCount];

            for (int i = 0; i < boxCount; i++)
            {
                for (int j = 0; j < boxCount; j++)
                {
                    _boxes[i, j] = new Box(i * boxWidth, j * boxWidth, boxWidth, boxWidth, this, i, j);
                }

                _boxCount = boxCount;
                _boxWidth = boxWidth;
                _mapWidth = _boxCount * _boxWidth;
            }

        }

        public int BoxCount
        {
            get { return _boxCount; }
        }

        /// <summary>
        /// Gets the box width in centimeters.
        /// </summary>
        public int BoxWidth
        {
            get { return _boxWidth; }
        }

        /// <summary>
        /// Gets the map width in centimeters.
        /// </summary>
        public int MapWidth
        {
            get { return _mapWidth; }
        }

        /// <summary>
        /// Gets the total area of the map in centimeters.
        /// </summary>
        public Rectangle Area
        {
            get { return new Rectangle(0, 0, _boxWidth * _boxCount, _boxWidth * _boxCount); }
        }

        public void Draw(Graphics g)
        {
            foreach (Box b in _boxes)
            {
                b.Draw(g);
            }
        }

        public IEnumerable<BoxRenderInfo> GetOverlappedBoxes(Rectangle r)
        {
            if (!Area.Contains(r)) throw new ArgumentException("Map area must contain the rectangle.");
            int top = r.Top / _boxWidth;
            int left = r.Left / _boxWidth;
            int bottom = (r.Bottom - 1) / _boxWidth;
            int right = (r.Right - 1) / _boxWidth;
            int offsetX = 0, offsetY = 0;
            for (int i = top; i <= bottom; ++i)
            {
                for (int j = left; j <= right; ++j)
                {
                    Box b = _boxes[i, j];
                    Debug.Assert(b.Area.IntersectsWith(r));
                    Rectangle rIntersect = r;
                    rIntersect.Intersect(b.Area);
                    rIntersect.Offset(-b.Area.Left, -b.Area.Top);
                    if (j == left)
                    {
                        if (i == top)
                        {
                            offsetY = -rIntersect.Y;
                        }
                        offsetX = -rIntersect.X;
                    }
                    yield return new BoxRenderInfo(b, rIntersect, offsetX, offsetY);
                    offsetX += _boxWidth;
                }
                offsetY += _boxWidth;
            }
        }

        public void Update()
        {

        }

        public Box [,] Boxes
        {
            get { return _boxes; }
        }
    }
}
