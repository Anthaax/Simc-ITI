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
        private Graphics g, screeng;
        readonly Map _map;
        Bitmap bmpPicture = new Bitmap("C:/dev/Textures/college.bmp");
        readonly int _line;
        readonly int _column;
        Infrastructure _infrastructure;
        public Box(Map map, int line, int column)
        {
            _map = map;
            _line = line;
            _column = column;
        }

        public Rectangle Area
        {
            get
            {
                int sz = _map.BoxWidth;
                return new Rectangle(_column, _line, sz, sz);
            }
        }

        static Pen p = new Pen(Color.DarkGreen, 1.0f);

        public virtual void Draw(Graphics g, Rectangle rectSource, float scaleFactor)
        {
            Rectangle r = new Rectangle(0, 0, _map.BoxWidth, _map.BoxWidth);
            g.DrawImage(bmpPicture, this.Area);
            g.DrawRectangle(Pens.DarkGreen, this.Area);
            r.Inflate(-_map.BoxWidth / 12, -_map.BoxWidth / 12);
        }

        private void T_loop(object sender, EventArgs e)
        {
            g.DrawImage(bmpPicture, new Point(0, 0));
            screeng.Clear(Color.White);

            //_map.Draw(screeng);
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
            return _map.CanBuild( Price );
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
    }
}