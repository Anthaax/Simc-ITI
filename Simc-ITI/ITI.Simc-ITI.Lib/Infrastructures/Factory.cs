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
        int _burningChance = 75;
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
            _bmp = null;
        }
        public override void OnCreatedAround( Box b )
        {
            IBurnImpact fire = b.Infrasructure as IBurnImpact;
            if( fire != null )
            {
                BurningChance = BurningChance - fire.FireChanceImpact( Box );
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IBurnImpact fire = b.Infrasructure as IBurnImpact;
            if( fire != null )
            {
                BurningChance = BurningChance + fire.FireChanceImpact( Box );
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
        public int Salary { get { return _salary; } set { _salary = value; } }
        public int BurningChance { get { return _burningChance; } set { _burningChance = value; } }
        [field: NonSerialized]
        public event EventHandler IsOnFire;
        public bool IsBurning
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
            else if( _taxation == 20 ) _bmp = Box.Map.BitmapCache.Get( "UsinesH.bmp" );
            else _bmp = Box.Map.BitmapCache.Get( "Usines.bmp" );
        }
    }
}
