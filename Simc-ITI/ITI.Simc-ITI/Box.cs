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
                return new Rectangle( _column*sz, _line*sz, sz, sz );
            }
        }

        static Pen p = new Pen( Color.DarkGreen, 1.0f );

        public virtual void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            if( Infrastructure != null ) Infrasructure.Draw( g, rectSource, scaleFactor );
            else
            {
                g.DrawImage( bmpPicture, new Rectangle(0, 0, _map.BoxWidth, _map.BoxWidth) );
                g.DrawRectangle( Pens.DarkGreen, new Rectangle(0, 0, _map.BoxWidth, _map.BoxWidth) );
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
  
        public bool CheckTheNearBoxesRoad()
        {
            bool _check = false;
            for(int i = -1; i <= 1; i+=2)
            {
                if( _column + i < 0 || _column + i > 99 || _map.Boxes[_column + i, _line].Infrasructure == null ) ;
                else if( _map.Boxes[_column + i, _line].Infrasructure.Name() == "Route" )  _check = true;
            }
            for( int j = -1; j <= 1; j += 2 )
            {
                if( _line + j < 0 || _line + j > 99 || _map.Boxes[_column, _line + j].Infrasructure == null ) ;
                else if( _map.Boxes[_column, _line + j].Infrasructure.Name() == "Route" )  _check = true;
            }
            return _check;
        }

        public bool CheckTheNearBoxesBuilding()
        {
            bool _check = false;
            for( int i = -1; i <= 1; i += 2 )
            {
                if( _column + i < 0 || _column + i > 99 || _map.Boxes[_column + i, _line].Infrasructure == null ) ;
                else if( _map.Boxes[_column + i, _line].Infrasructure.Name() != "Route" ) _check = true;
            }
            for( int j = -1; j <= 1; j += 2 )
            {
                if( _line + j < 0 || _line + j > 99 || _map.Boxes[_column, _line + j].Infrasructure == null ) ;
                else if( _map.Boxes[_column, _line + j].Infrasructure.Name() != "Route" ) _check = true;
            }
            return _check;
        }

        public void AppliedEffect( int _areaEffect, int _effect )
        {
            for(int i = -_areaEffect; i <= _areaEffect; i++)
            {
                if( _column + i < 0 || i == 0 || _map.Boxes[_column + i, _line].Infrasructure == null ) ;
                else
                {
                }
            }
        }
    }
}