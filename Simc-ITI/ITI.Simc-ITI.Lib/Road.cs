using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class RoadCreationConfig
    {
        public RoadOrientation Orientation { get; set; }
    }
    public class RoadType : InfrastructureType
    {
        public RoadType()
            : base( "Route", 5, 0 )
        {
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            RoadCreationConfig cfg = creationConfig as RoadCreationConfig;
            if( cfg == null ) throw new ArgumentException( "Must be a RoadCreationConfig object.", "creationConfig" );


            return new Road( location, this, cfg.Orientation );
        }
    }

    public class Road : Infrastructure
    {
        string _name;
        Bitmap _bmp;

        public Road( Box b, RoadType info, RoadOrientation o )
            : base( b, info )
        {
            _bmp = new Bitmap( "C:/dev/textures/" + o + ".bmp" );
            _name = info.Name;
        }
        public new RoadType Type { get { return (RoadType)base.Type; } }
        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override void OnDestroy()
        {
            _bmp.Dispose();
        }
        public override void OnCreatedAround( Box b )
        {

        }
        public override void OnDestroyingAround( Box b )
        {
        }
    }
}
