using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class SchoolType : InfrastructureType
    {
        int _costPerMonth;
        int _maxCapacity;
        int _happynessImpactMax;
        public SchoolType( GameContext ctx )
            : base( ctx, "Ecole", 500, 10)
        {
            _costPerMonth = 300;
            _maxCapacity = 200;
            _happynessImpactMax = 5;
        }

        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            return new School( location, this );
        }
        public int CostPerMonth { get { return _costPerMonth; } }
        public int MaxCapacity { get { return _maxCapacity; } }
        public int HappynessImpact { get { return _happynessImpactMax; } }
    }


    public class School : Infrastructure, IHappynessImpact, IHealth, IPublic
    {
        int _costPerMonth;
        int _maxCapacity;
        int _actualCapacity;
        int _happynessImpact;
        bool _health = true;
        Bitmap _bmp;

        public School(Box b, SchoolType info)
            : base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get("Ecole.bmp");
            _costPerMonth = info.CostPerMonth;
            _happynessImpact = info.HappynessImpact;
            CheckAllNearBoxes();
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor, Pen p )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( p, r );
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
        }
        public override void OnDestroyingAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                _health = true;
            }
            CheckAllNearBoxes();
        }
        public int HappynessImpact( Box b )
        {
            int happyness;
            int cDistance = Math.Abs( Box.Column - b.Column );
            int lDistance = Math.Abs( Box.Line - b.Line );
            if( _health == true ) 
            {
                if( cDistance < 5 && lDistance < 5 ) happyness = 5;
                else if( cDistance < 10 && lDistance < 10 ) happyness = 2;
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
        public int MaxCapacity
        {
            get { return _maxCapacity; }
            set { _maxCapacity = value; }
        }
        public int ActualCapacity
        {
            get { return _actualCapacity; }
            set { _actualCapacity = value; }
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
    }
}
