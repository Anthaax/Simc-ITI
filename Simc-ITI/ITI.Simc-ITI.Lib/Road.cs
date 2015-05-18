using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class RoadType : InfrastructureType
    {
        public RoadType()
            : base( "Road", 5, "C:/dev/Textures/RV.bmp" )
        {
        }

        public override Infrastructure CreateInfrastructure( Box location )
        {
            if( location.Infrasructure == null )
            {
                location.Map.Money.ActualMoney -= this.BuildingCost;
                return new Road( location, this );
            }
            return null;
        }
    }

    public class Road : Infrastructure
    {
        bool _water;
        bool _electricity;
        Bitmap _bmp;
        RoadType _info;
        Box _box;

        public Road( Box b, RoadType Info )
            : base( b )
        {
            _info = Info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap( Info.TexturePath );
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
            r.Inflate( -_box.Map.BoxWidth / 12, -_box.Map.BoxWidth / 12 );
        }
        public bool Water
        {
            get { return _water; }
            set { _water = value; }
        }
        public bool Electricity
        {
            get { return _electricity; }
            set { _electricity = value; }
        }
    }
}
