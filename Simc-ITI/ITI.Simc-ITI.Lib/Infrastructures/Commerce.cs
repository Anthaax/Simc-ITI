using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class RetailType : InfrastructureType
    {
        int _happyness;
        int _turnover;
        public RetailType( GameContext ctx )
            : base( ctx, "Commerce", 0, 5 )
        {
            _happyness = 50;
            _turnover = 5000;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            if( location.Infrasructure == null )
            {
                return new Retail( location, this );
            }
            return null;
        }
        public int Happyness { get { return _happyness; } }
        public int Turnover { get { return _turnover; } }
    }
    [Serializable]
    public class Retail : Infrastructure, IHappyness, ITaxation, IHappynessImpact, IBurn
    {
        int _hapyness;
        [field: NonSerialized]
        Bitmap _bmp;
        int _taxation = 10;
        int _salary = 30000;
        int _fireChance = 5;
        bool _isBurning = false;


        public Retail( Box b, RetailType info )
            : base( b, info)
        {
            _bmp = b.Map.BitmapCache.Get("Commerces.bmp");
            _hapyness = info.Happyness;
            CheckAllNearBoxes();
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
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness = Happyness + impact.HappynessImpact( Box );
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness = Happyness - impact.HappynessImpact( Box );
            }
        }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        public int Salary { get { return _salary; } }
        public int FireChance { get { return _fireChance; } set { _fireChance = value; } }
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
        public int HappynessImpact(Box b)
        {
            int happyness;
            int cDistance = Math.Abs( Box.Column - b.Column );
            int lDistance = Math.Abs( Box.Line - b.Line );

            if( cDistance == 1 && lDistance == 1 ) happyness = -1;
            else happyness = 2;
            return happyness;
        }
        public void CheckAllNearBoxes()
        {
            IEnumerable<Box> nearBox = Box.NearBoxes( Box.Map.BoxCount );
            foreach( var box in nearBox )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Line - box.Infrasructure.Type.AreaEffect <= Box.Line || box.Line + box.Infrasructure.Type.AreaEffect >= Box.Line || box.Column - box.Infrasructure.Type.AreaEffect <= Box.Column || box.Column + box.Infrasructure.Type.AreaEffect >= Box.Column )
                    {
                        OnCreatedAround( box );
                    }
                }
            }
        }
        public override void ChargeBitMap()
        {
            if( _isBurning == true ) _bmp = Box.Map.BitmapCache.Get( "CommercesB.bmp" );
            else _bmp = Box.Map.BitmapCache.Get( "Commerces.bmp" );
        }
    }
}
