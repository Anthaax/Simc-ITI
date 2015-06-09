using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class CommerceType : InfrastructureType
    {
        int _happyness;
        int _turnover;
        public CommerceType()
            : base( "Commerce", 0, 5 )
        {
            _happyness = 50;
            _turnover = 5000;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            if( location.Infrasructure == null )
            {
                location.Map.Money.ActualMoney -= this.BuildingCost;
                return new Commerce( location, this );
            }
            return null;
        }
        public int Happyness { get { return _happyness; } }
        public int Turnover { get { return _turnover; } }
    }
    public class Commerce : Infrastructure, IHappyness, ITaxation
    {
        int _hapyness;
        Bitmap _bmp;
        int _taxation = 10;
        int _salary = 30000;


        public Commerce( Box b, CommerceType info )
            : base( b, info)
        {
            _bmp = b.Map.Texture.Get("Commerce.bmp");
            _hapyness = info.Happyness;
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
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness += impact.HappynessImpact;
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness -= impact.HappynessImpact;
            }
        }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        public int Salary { get { return _salary; } }
    }
}
