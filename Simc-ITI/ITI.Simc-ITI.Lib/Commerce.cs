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
            : base( "Commerce", true, 0, "C:/dev/Textures/Commerce.bmp" )
        {
            _happyness = 50;
            _turnover = 5000;
        }
        public override Infrastructure CreateInfrastructure( Box location )
        {
            if( location.Infrasructure == null )
            {
                location.Map.Money.ActualMoney -= this.BuildingCost;
                return new Commerce( location, this );
            }
            return null;
        }
        public int Happyness { get { return _happyness; } }
    }
    public class Commerce : Infrastructure
    {
        int _hapyness;
        int _maxCapacity;
        int _actualCapacity;
        Bitmap _bmp;
        CommerceType _info;
        Box _box;

        public Commerce( Box b, CommerceType Info )
            : base( b )
        {
            _info = Info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap( Info.TexturePath );
            _hapyness = Info.Happyness;
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override string Name()
        {
            return _info.Name;
        }
        public override void Destroy()
        {
            _box.Infrasructure = null;
            _box = null;
        }
        public override void HappynessEffect( int effect )
        {
            _hapyness = _hapyness + effect;
        }
        public override bool Private()
        {
            return _info.IsPrivate;
        }
        public override int Happyness()
        {
            return _hapyness;
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
