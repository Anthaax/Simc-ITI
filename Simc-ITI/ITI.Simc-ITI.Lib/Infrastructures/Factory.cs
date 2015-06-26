using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class FactoryType : InfrastructureType
    {
        int _happyness;
        public FactoryType( GameContext ctx )
            : base( ctx, "Usine", 0, 5)
        {
            _happyness = 50;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
                return new Factory( location, this );
        }
        public int Happyness { get { return _happyness; } }
    }
    [Serializable]
    public class Factory : Infrastructure, ITaxation, IHappynessImpact, IBurn
    {
        int _hapyness;
        int _salary = 7000;
        int _taxation = 10;
        int _fireChance = 5;
        bool _isBurning = false;
        [field: NonSerialized]
        Bitmap _bmp;


        public Factory( Box b, FactoryType info )
            : base( b, info )
        {
            _bmp = b.Map.BitmapCache.Get( "Usines.bmp" );
            _hapyness = info.Happyness;
            IsOnFire += ( s, e ) => ChargeBitMap();
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor, Pen penColor )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( penColor, r );
        }
        public override void OnDestroy()
        {
            _bmp.Dispose();
        }
        public override void OnCreatedAround( Box b )
        {
            IFire fire = b.Infrasructure as IFire;
            if( fire != null )
            {
                FireChance = FireChance - fire.FireChanceImpact( Box );
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IFire fire = b.Infrasructure as IFire;
            if( fire != null )
            {
                FireChance = FireChance + fire.FireChanceImpact( Box );
            }
        }
        public int HappynessImpact( Box b )
        {
            int happyness;
            int cDistance = Math.Abs( Box.Column - b.Column );
            int lDistance = Math.Abs( Box.Line - b.Line );

            if( cDistance <= 2 && lDistance <= 2 ) happyness = -10;
            else happyness = -5;
            return happyness;
        }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        public int Salary { get { return _salary; } }
        public int FireChance { get { return _fireChance; } set { _fireChance = value; } }
        [field: NonSerialized]
        public event EventHandler IsOnFire;
        public bool IsBurnig
        {
            get { return _isBurning; }
            set
            {
                if( _isBurning != value )
                {
                    _isBurning = value;
                    var h = IsOnFire;
                    if( h != null ) h( this, EventArgs.Empty );
                }
            }
        }
        public override void ChargeBitMap()
        {
            if( _isBurning == true ) _bmp = Box.Map.BitmapCache.Get( "UsinesB.bmp" );
            else _bmp = Box.Map.BitmapCache.Get( "Usines.bmp" );
        }
    }
}
