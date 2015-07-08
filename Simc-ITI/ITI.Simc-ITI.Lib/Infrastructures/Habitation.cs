using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class HabitationType : InfrastructureType
    {
        int _happyness;
        public HabitationType( GameContext ctx )
            : base( ctx, "Habitation", 0, 0)
        {
            _happyness = 50;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
                return new Habitation( location, this );
        }
        public int Happyness { get { return _happyness; } }
    }
    [Serializable]
    public class Habitation : Infrastructure, IHappyness, ITaxation, IBurn, Isteal
    {
        int _hapyness;
        int _salary = 4000;
        int _taxation = 10;
        int _burningChance = 75;
        bool _isBurning = false;
        int _stealChance = 75;
        bool _isSteal = false;
        int _indicatorSteal = 5;
        [field: NonSerialized]
        Bitmap _bmp;


        public Habitation(Box b, HabitationType info)
            : base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get("Habitation.bmp");
            _hapyness = info.Happyness;
            CheckAllNearBoxes();
            IsOnFire += ( s, e ) => ChargeBitMap();
            IsStolen += ( s, e ) => ChargeBitMap();

        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth );
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
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness = Happyness + impact.HappynessImpact( Box );
            }
            IBurnImpact fire = b.Infrasructure as IBurnImpact;
            if( fire != null )
            {
                BurningChance = BurningChance - fire.FireChanceImpact( Box );
            }
            IStealImpact steal = b.Infrasructure as IStealImpact;
            if(steal != null)
            {
                StealChance = StealChance - steal.StealChanceImpact( Box );
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness = Happyness - impact.HappynessImpact( Box );
            }
            IBurnImpact fire = b.Infrasructure as IBurnImpact;
            if( fire != null ) 
            {
                BurningChance = BurningChance + fire.FireChanceImpact( Box );
            }
            IStealImpact steal = b.Infrasructure as IStealImpact;
            if (steal != null)
            {
                StealChance = StealChance + steal.StealChanceImpact(Box);
            }
        }
        public int StealChance { get { return _stealChance; } set { _stealChance = value; } }
        public int IndicatorSteal { get { return _indicatorSteal; } set { _indicatorSteal = value; } }
        public int BurningChance { get { return _burningChance; } set { _burningChance = value; } }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        public int Salary { get { return _salary; } set { _salary = value; } }
        [field: NonSerialized]
        public event EventHandler IsOnFire;
        [field: NonSerialized]
        public event EventHandler IsStolen;

        public bool IsSteal { get { return _isSteal; }
            set
            {
                if (_isSteal != value)
                {
                    _salary = 0;
                    _isSteal = value;
                    var h = IsStolen;
                    if (h != null) h(this, EventArgs.Empty);
                }
            } 
        }
        public bool IsBurning { get { return _isBurning; } 
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
        
        public void CheckAllNearBoxes()
        {
            IEnumerable<Box> nearBox = Box.NearBoxes( Box.Map.BoxCount );
            foreach( var box in nearBox)
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
            if( _isBurning == true ) _bmp = Box.Map.BitmapCache.Get( "HabitationB.bmp" );
            else if( _hapyness <= 20 ) _bmp = Box.Map.BitmapCache.Get( "HabitationH.bmp" );
            else if (_isSteal == true) _bmp = Box.Map.BitmapCache.Get("HabitationH.bmp");
            else _bmp = Box.Map.BitmapCache.Get( "Habitation.bmp" );
        }
    }
}
