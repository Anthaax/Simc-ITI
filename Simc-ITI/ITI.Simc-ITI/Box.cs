using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Simc_ITI.Lib;

namespace ITI.Simc_ITI
{
    public class Box
    {
        private Map map;
        private int x, y, width, height, line, column;
        Bitmap bmpPicture = new Bitmap("C:/dev/Textures/RV2.bmp");
        Infrastructure _infrastructure;
        Box [,] near;
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

        public void CreateInfrastructure( int Price, int areaEffect, int pricePermounth, bool IsWater, bool IsElectric, bool RoadNear, bool road, string name )
        {
            if( CanBuildInfrastructure( Price ) == true )
            {
                Infrastructure inf = new Infrastructure( Price, areaEffect, pricePermounth, IsWater, IsWater, RoadNear, road, name );
                _infrastructure = inf;
            }
            else throw new InvalidOperationException( "You can't build your infrastructure you haven't enouth money" );
        }

        private bool CanBuildInfrastructure( int Price )
        {
            return map.CanBuild( Price );
        }

        public Infrastructure MyInfrasructure
        {
            get { return _infrastructure; }
        }

        public bool RoadNear(Box Box)
        {
            if( Box.MyInfrasructure.MyRoad == null ) return false;
            return true;
        }

        public void NearBoxes()
        {
            map.
        }

        


    }
}