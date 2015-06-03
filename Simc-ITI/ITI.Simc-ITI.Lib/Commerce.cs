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
            : base( "Commerce", 0, 5, "C:/dev/Textures/Commerce.bmp" )
        {
            _happyness = 50;
            _turnover = 5000;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location )
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
    public class Commerce : Infrastructure, IHappyness
    {
        int _hapyness;
        int _maxCapacity;
        int _actualCapacity;
        Bitmap _bmp;
        CommerceType _info;
        Box _box;

        public Commerce( Box b, CommerceType info )
            : base( b, info)
        {
            _info = info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap( info.TexturePath );
            _hapyness = info.Happyness;
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override void Destroy()
        {
            _box.Infrasructure = null;
            _box = null;
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
            throw new NotImplementedException();
        }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
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
