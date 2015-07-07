using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{ [Serializable]
    public class Box
    {
        [field: NonSerialized]
        Graphics g, screeng;
        [field: NonSerialized]
        Pen _p = new Pen( Color.DimGray );
        readonly Map _map;
        readonly int _line;
        readonly int _column;
        private bool _selected = false;
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
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
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
            if( Infrastructure != null ) Infrasructure.Draw( g, rectSource, scaleFactor );
            else
            {
                g.DrawImage( Map.BitmapCache.Get( "Terre.bmp" ), new Rectangle( 0, 0, _map.BoxWidth + 1000, _map.BoxWidth + 1000 ) );
                if( Selected == true )
                {
                    g.DrawRectangle( Pens.Red, new Rectangle( 0, 0, _map.BoxWidth - 400, _map.BoxWidth - 400 ) );
                }
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