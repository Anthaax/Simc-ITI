using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    class Box
    {
        private int x, y, width, height;
        Bitmap bmpPicture = new Bitmap("C:/Users/Kappa/Desktop/Sim/textures/RV2.bmp");
        public Box(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
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