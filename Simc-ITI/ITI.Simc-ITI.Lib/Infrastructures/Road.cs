﻿using System;
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
    [Serializable]
    public class RoadType : InfrastructureType
    {
        public RoadType( GameContext ctx )
            : base( ctx, "Route", 5, 0 )
        {
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            RoadCreationConfig cfg = creationConfig as RoadCreationConfig;
            if( cfg == null ) throw new ArgumentException( "Must be a RoadCreationConfig object.", "creationConfig" );


            return new Road( location, this, cfg.Orientation );
        }
    }
    [Serializable]
    public class Road : Infrastructure
    {
        string _name;
        [field: NonSerialized]
        Bitmap _bmp;
        RoadOrientation _orientation;

        public Road( Box b, RoadType info, RoadOrientation o )
            : base( b, info )
        {
            _orientation = o;
            _bmp = b.Map.BitmapCache.Get(o + ".bmp");
            _name = info.Name;

        }
        public new RoadType Type { get { return (RoadType)base.Type; } }
        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth + 1000, Box.Map.BoxWidth + 1000 );
            g.DrawImage( _bmp, r );
            if( Box.Selected == true )
            {
                g.DrawRectangle( Pens.Red, new Rectangle( 0, 0, Box.Map.BoxWidth - 400, Box.Map.BoxWidth - 400 ) );
            }
        }
        public override void OnDestroy()
        {
            _bmp = null;
        }
        public override void OnCreatedAround( Box b )
        {

        }
        public override void OnDestroyingAround( Box b )
        {
        }
        public override void ChargeBitMap()
        {
            _bmp = Box.Map.BitmapCache.Get( _orientation +".bmp" );
        }
    }
}
