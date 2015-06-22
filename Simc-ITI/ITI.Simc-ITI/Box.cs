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
        Pen _p = new Pen( Color.DimGray );
        readonly Map _map;
        readonly int _line;
        readonly int _column;
        IInfrastructureForBox Infrastructure;
        public Box( Map map, int line, int column )
        {
            _map = map;
            _line = line;
            _column = column;
        }

        public int Line
        {
            get { return _line; }
        }

        public int Column
        {
            get { return _column; }
        } 

        public Rectangle Area
        {
            get
            {
                int sz = _map.BoxWidth;
                return new Rectangle( _column*sz, _line*sz, sz, sz );
            }
        }
        public Pen PenColor
        {
            get { return _p; }
            set { _p = value; }
        }
        public virtual void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            if( Infrastructure != null ) Infrasructure.Draw( g, rectSource, scaleFactor, _p );
            else
            {
                g.DrawImage( Map.BitmapCache.Get("Terre.bmp"), new Rectangle(0, 0, _map.BoxWidth, _map.BoxWidth) );
                g.DrawRectangle( _p, new Rectangle(0, 0, _map.BoxWidth, _map.BoxWidth) );
            }
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
        public IEnumerable<Box> NearBoxes( int areaEffect )
        {
            List<Box> _nearBoxes = new List<Box>();
            for( int c = Math.Max( 0, Column - areaEffect ); c <= Math.Min( Map.BoxCount - 1, Column + areaEffect ); c++ ) 
            {
                for( int l = Math.Max( 0, Line - areaEffect ); l <= Math.Min( Map.BoxCount - 1, Line + areaEffect ); l++ )
                {
                    if( c != Column || l != Line )
                    {
                        Box aroundBox = Map.Boxes[c, l];
                        _nearBoxes.Add( aroundBox );
                    } 
                }
            }
            return _nearBoxes;
        }
    }
}