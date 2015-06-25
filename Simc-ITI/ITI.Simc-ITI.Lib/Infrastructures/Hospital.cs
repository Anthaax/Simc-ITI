using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class HospitalType : InfrastructureType
    {
        int _costPerMonth;
        int _happynessImpactMax; 
        public HospitalType(GameContext ctx)
            :base(ctx,"Hopital", 500, 10)
        {
            _costPerMonth = 600;
            _happynessImpactMax = 5;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            return new Hospital( location, this );
        }
        public int CostPerMonth { get { return _costPerMonth; } }
        public int HappynessImpact { get { return _happynessImpactMax; } }
    }
    [Serializable]
    public class Hospital : Infrastructure, IHappynessImpact, IHealth, IBurn
    {
        int _costPerMonth;
        int _happynessImpact;
        bool _health = true;
        int _fireChance = 5;
        bool _isBurning = false;
        Bitmap _bmp;
        public Hospital(Box b, HospitalType info)
            :base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get( "Hospital.bmp" );
            _costPerMonth = info.CostPerMonth;
            _happynessImpact = info.HappynessImpact;
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
                if( impact.HappynessImpact( Box ) < 0 ) _health = false;
                else _health = true;
            }
            IFire fire = b.Infrasructure as IFire;
            if( fire != null )
            {
                FireChance = FireChance - fire.FireChanceImpact( Box );
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                _health = true;
            }
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
            if( _health == true )
            {
                if( cDistance < 5 && lDistance < 5 ) happyness = 10;
                else if( cDistance < 10 && lDistance < 10 ) happyness = 5;
                else happyness = 1;
            }
            else
            {
                happyness = 0;
            }
            return happyness;
        }
        public int CostPerMount { get { return _costPerMonth; } set { _costPerMonth = value; } }
        public bool Health { get { return _health; } set { _health = value; } }
        public int FireChance { get { return _fireChance; } set { _fireChance = value; } }
        [NonSerialized]
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
        public void ChangeBitMap( object sender, EventArgs e )
        {
            Bitmap _bmpT = Box.Map.BitmapCache.Get( "HopitalB.bmp" );
            if( _bmp != _bmpT ) _bmp = Box.Map.BitmapCache.Get( "HopitalB.bmp" );
            else _bmp = Box.Map.BitmapCache.Get( "Hopital.bmp" );
        }
    }
}
