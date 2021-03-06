﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class PowerStationType : InfrastructureType
    {
        int _costPerMonth;
        public PowerStationType( GameContext ctx )
            : base( ctx, "CentraleElectrique", 900, 13 )
        {
            _costPerMonth = 1000;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            return new PowerStation( location, this );
        }
        public int CostPerMonth { get { return _costPerMonth; } }
    }
    [Serializable]
    public class PowerStation : Infrastructure, IHappynessImpact, IPulicBuilding
    {
        [field: NonSerialized]
        Bitmap _bmp;
        int _costPerMonth;
        public PowerStation( Box b, PowerStationType info )
            :base(b,info)
        {
            _bmp = b.Map.BitmapCache.Get( "Elec.bmp" );
            _costPerMonth = info.CostPerMonth;

        }
        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle(0, 0, Box.Map.BoxWidth + 400, Box.Map.BoxWidth + 400);
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
            _bmp = Box.Map.BitmapCache.Get( "Elec.bmp" );
        }
        public int HappynessImpact( Box b )
        {
            int happyness;
            int cDistance = Math.Abs( Box.Column - b.Column );
            int lDistance = Math.Abs( Box.Line - b.Line );

            if( cDistance <= 2 && lDistance <= 2 ) happyness = -10;
            else happyness = 0;
            return happyness;
        }
        public int CostPerMounth { get { return _costPerMonth; } set { _costPerMonth = value; } }
    }
}
