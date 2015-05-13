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
        Graphics g, screeng;
        readonly Map _map;
        Bitmap bmpPicture = new Bitmap( "C:/dev/Textures/Terre.bmp" );
        readonly int _line;
        readonly int _column;
        IInfrastructureForBox Infrastructure;
        public Box( Map map, int line, int column )
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
                return new Rectangle( _column, _line, sz, sz );
            }
        }

        static Pen p = new Pen( Color.DarkGreen, 1.0f );

        public virtual void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            if( Infrastructure != null ) Infrasructure.Draw( g, rectSource, scaleFactor );
            else
            {
                Rectangle r = new Rectangle( 0, 0, _map.BoxWidth, _map.BoxWidth );
                g.DrawImage( bmpPicture, this.Area );
                g.DrawRectangle( Pens.DarkGreen, this.Area );
            }
        }

        private void T_loop( object sender, EventArgs e )
        {
            g.DrawImage( bmpPicture, new Point( 0, 0 ) );
            screeng.Clear( Color.White );

            _map.Draw( screeng );
        }

        private bool CanBuildInfrastructure( int Price )
        {
            return _map.Money.CanBuid( Price );
        }

        public IInfrastructureForBox Infrasructure
        {
            get { return Infrastructure; }
            set { Infrastructure = value; }
        }

        public Map Map
        {
            get { return _map; }
        }
    }
}