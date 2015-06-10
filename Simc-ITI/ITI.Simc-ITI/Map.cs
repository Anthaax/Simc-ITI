using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ITI.Simc_ITI
{
    public class Map
    {
        readonly Box[,] _boxes;
        readonly int _boxCount;
        readonly int _boxWidth;
        readonly int _mapWidth;
        readonly BitmapCache _bmpCache;

        public Map(int boxWidthInMeter, int boxCount)
        {
            _bmpCache = new BitmapCache();
            _boxes = new Box[boxCount, boxCount];
            for (int j = 0; j < boxCount; ++j)
            {
                for (int i = 0; i < boxCount; ++i)
                {
                    _boxes[i, j] = new Box(this, j, i);
                }
            }
            _boxCount = boxCount;
            _boxWidth = boxWidthInMeter * 100;
            _mapWidth = _boxCount * _boxWidth;
        }

        /// <summary>
        /// Gets the number of boxes horizontally or vertically.
        /// This is the square root of the total number of boxes.
        /// </summary>
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

        public Box this[int line, int column]
        {
            get
            {
                if (line < 0 || line >= _boxCount || column < 0 || column >= _boxCount)
                {
                    return null;
                }
                return _boxes[line, column];
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
            for (int j = top; j <= bottom; ++j)
            {
                for (int i = left; i <= right; ++i)
                {
                    Box b = _boxes[i, j];
                    Debug.Assert(b.Area.IntersectsWith(r));
                    Rectangle rIntersect = r;
                    rIntersect.Intersect(b.Area);
                    rIntersect.Offset(-b.Area.Left, -b.Area.Top);
                    if (i == left)
                    {
                        if (j == top)
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

        public void Draw(Graphics g)
        {
            foreach (Box b in _boxes)
            {
                b.Draw(g, this.Area, 0);
            }
        }

        public Box [,] Boxes
        {
            get { return _boxes; }
        }

        public IEnumerable<T> GetAllInfrastucture<T>()
        {
            return _boxes.Cast<Box>().Select( b => b.Infrasructure ).OfType<T>();
        }

        public BitmapCache BitmapCache
        { get { return _bmpCache; } }
    }
}
