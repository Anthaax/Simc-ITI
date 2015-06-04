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
            : base( "Ecole", 500, 10,"C:/dev/Textures/Ecole.bmp")
        {
            _costPerMonth = 100;
            _maxCapacity = 200;
            _happynessImpactMax = 5;
        }

        protected override Infrastructure DoCreateInfrastructure( Box location )
        {
            return new Ecole( location, this );
        }
        public int CostPerMonth { get { return _costPerMonth; } }
        public int MaxCapacity { get { return _maxCapacity; } }
        public int HappynessImpact { get { return _happynessImpactMax; } }
    }


    public class Ecole : Infrastructure, IHappynessImpact
    {
        int _costPerMonth;
        int _maxCapacity;
        int _actualCapacity;
        int _happynessImpact;
        Bitmap _bmp;
        EcoleType _info;
        Box _box;

        public Ecole(Box b, EcoleType info)
            : base(b, info)
        {
            _info = info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap( info.TexturePath );
            _costPerMonth = info.CostPerMonth;
            _happynessImpact = info.HappynessImpact;
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override void OnCreatedAround( Box b )
        {
            
        }
        public override void OnDestroyingAround( Box b )
        {

        }
        public int HappynessImpact { get { return _happynessImpact; } }
        public int PricePerMounth
        {
            get { return _costPerMonth; }
            set { _costPerMonth = value; }
        }
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
