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
    public class Habitation : Infrastructure, IHappyness, ITaxation, IBurn
    {
        int _hapyness;
        int _salary = 7000;
        int _taxation = 10;
        int _fireChance = 5;
        bool _isBurning = false;
        int _stealChance = 5;
        Bitmap _bmp;


        public Habitation(Box b, HabitationType info)
            : base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get("Habitation.bmp");
            _hapyness = info.Happyness;
            CheckAllNearBoxes();
            IsOnFire += ChangeBitMap;
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
            IFire fire = b.Infrasructure as IFire;
            if( fire != null )
            {
                FireChance = FireChance - fire.FireChanceImpact( Box );
            }
            ISteal steal = b.Infrasructure as ISteal;
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
            IFire fire = b.Infrasructure as IFire;
            if( fire != null ) 
            {
                FireChance = FireChance + fire.FireChanceImpact( Box );
            }
            ISteal steal = b.Infrasructure as ISteal;
            if (steal != null)
            {
                StealChance = StealChance + steal.StealChanceImpact(Box);
            }
        }
        public int StealChance { get { return _stealChance; } set { _stealChance = value; } }
        public int FireChance { get { return _fireChance; } set { _fireChance = value; } }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        public int Salary { get { return _salary; } }
        public event EventHandler IsOnFire;
        public bool IsBurnig { get { return _isBurning; } 
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
        
        public void ChangeBitMap( object sender, EventArgs e )
        {
            Bitmap _bmpT = Box.Map.BitmapCache.Get( "HabitationB.bmp" );
           if(_bmp != _bmpT )  _bmp = Box.Map.BitmapCache.Get( "HabitationB.bmp" );
           else _bmp = Box.Map.BitmapCache.Get( "Habitation.bmp" );
        }
    }
}
