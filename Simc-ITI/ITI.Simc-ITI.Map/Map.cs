using System;
using System.Drawing;

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

        public Box[,] Boxes => _boxes;

        public int BoxCount => _boxCount;

        public int BoxWidth => _boxWidth;

        public int MapWidth => _mapWidth;

        public Rectangle Area => new Rectangle(0, 0, _boxWidth * _boxCount, _boxWidth * BoxCount);

        public BitmapCache BmpCache => _bmpCache;

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
    }
}
