using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    [Serializable]
    public struct BoxRenderInfo
    {
        public readonly Box Box;
        public readonly Rectangle RectSource;
        public readonly int OffsetX;
        public readonly int OffsetY;

        public BoxRenderInfo(Box b, Rectangle r, int offsetX, int offsetY)
        {
            Box = b;
            RectSource = r;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }
    }

}
