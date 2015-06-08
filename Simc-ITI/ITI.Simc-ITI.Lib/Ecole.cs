using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class EcoleType : InfrastructureType
    {
        int _costPerMonth;
        int _maxCapacity;
        int _happynessImpactMax;
        public EcoleType()
            : base( "Ecole", 500, 10)
        {
            _costPerMonth = 300;
            _maxCapacity = 200;
            _happynessImpactMax = 5;
        }

        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            return new Ecole( location, this );
        }
        public int CostPerMonth { get { return _costPerMonth; } }
        public int MaxCapacity { get { return _maxCapacity; } }
        public int HappynessImpact { get { return _happynessImpactMax; } }
    }


    public class Ecole : Infrastructure, IHappynessImpact, IPublic
    {
        int _costPerMonth;
        int _maxCapacity;
        int _actualCapacity;
        int _happynessImpact;
        Bitmap _bmp;

        public Ecole(Box b, EcoleType info)
            : base(b, info)
        {
            _bmp = new Bitmap( "C:/dev/Textures/Ecole.bmp" );
            _costPerMonth = info.CostPerMonth;
            _happynessImpact = info.HappynessImpact;
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
        public int HappynessImpact { get { return _happynessImpact; } }
        public int CostPerMount { get { return _costPerMonth; } set { _costPerMonth = value; } }
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
    }
}
