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
        
        public EcoleType()
            : base( "Ecole", 500, "C:/dev/Textures/College.bmp" )
        {
        }

        public override Infrastructure CreateInfrastructure( Box location )
        {
            if( location.Infrasructure == null )
            {
                location.Map.Money.ActualMoney -= this.BuildingCost;
                return new Ecole( location, this );
            }
            return null;
        }
    }


    public class Ecole : Infrastructure
    {
        int _areaEffect;
        int _pricePerMounth;
        int _maxCapacity;
        int _actualCapacity;
        Bitmap _bmp;
        EcoleType _info;
        Box _box;

        public Ecole(Box b, EcoleType Info)
            : base(b)
        {
            _info = Info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap(Info.TexturePath);
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, _box.Area );
            g.DrawRectangle( Pens.DarkGreen, _box.Area );
            r.Inflate( -_box.Map.BoxWidth / 12, -_box.Map.BoxWidth / 12 );
        }
        public int PricePerMounth
        {
            get { return _pricePerMounth; }
        }
        public int AreaEffect
        {
            get { return _areaEffect; }
        }
        public int MaxCapacity
        {
            get { return _maxCapacity; }
        }
        public int ActualCapacity
        {
            get { return _actualCapacity; }
        }
    }
}
