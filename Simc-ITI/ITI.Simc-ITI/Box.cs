using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    public class Box
    {
        private Map map;
        private int x, y, width, height, line, column;
        Bitmap bmpPicture = new Bitmap("C:/dev/Textures/RV2.bmp");
        public Box(int x, int y, int width, int height, Map map, int line, int column)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.map = map;
            this.column = column;
            this.line = line;
        }

        public Rectangle Area
        {
            get
            {
                return new Rectangle(this.x, this.y, this.width, this.height);
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(bmpPicture, this.Area);
            g.DrawRectangle(Pens.White, this.Area);
        }
    }
}