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
            : base( "Route", 5, 0, "C:/dev/Textures/RV.bmp" )
        {
        }
        protected override Infrastructure DoCreateInfrastructure( Box location )
        {
                return new Road( location, this );
        }
    }

    public class Road : Infrastructure
    {
        string _name;
        bool _water;
        bool _electricity;
        Bitmap _bmp;
        RoadType _info;
        Box _box;

        public Road( Box b, RoadType info )
            : base( b , info)
        {
            _info = info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap( info.TexturePath );
            _name = info.Name;
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override void Destroy()
        {
            _box.Infrasructure = null;
            _box = null;
        }
        public override void OnCreatedAround( Box b )
        {
            throw new NotImplementedException();
        }
        public override void OnDestroyingAround( Box b )
        {
            throw new NotImplementedException();
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
