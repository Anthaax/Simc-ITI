using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class CentraleElectriqueType : InfrastructureType
    {
        int _costPerMonth;
        public CentraleElectriqueType( GameContext ctx )
            : base( ctx, "CentraleElectrique", 900, 13 )
        {
            _costPerMonth = 300;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            return new CentraleElectrique( location, this );
        }
        public int CostPerMonth { get { return _costPerMonth; } }
    }
    public class CentraleElectrique : Infrastructure, IHappynessImpact, IPublic
    {
        Bitmap _bmp;
        int _costPerMonth;
        public CentraleElectrique( Box b, CentraleElectriqueType info )
            :base(b,info)
        {
            _bmp = new Bitmap( "C:/dev/Textures/Elec.bmp" );
            _costPerMonth = info.CostPerMonth;
        }
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
        public int HappynessImpact( Box b )
        {
            int happyness;
            int cDistance = Math.Abs( Box.Column - b.Column );
            int lDistance = Math.Abs( Box.Line - b.Line );

            if( cDistance <= 2 || lDistance <= 2 ) happyness = -20;
            else happyness = 0;
            return happyness;
        }
        public int CostPerMount { get { return _costPerMonth; } set { _costPerMonth = value; } }
    }
}
