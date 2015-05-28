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
        int _areaEffect;
        int _maxCapacity;
        public EcoleType()
            : base( "Ecole",false, 500,"C:/dev/Textures/Ecole.bmp")
        {
            _costPerMonth = 100;
            _areaEffect = 10;
            _maxCapacity = 200;
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
        public int CostPerMonth { get { return _costPerMonth; } }
        public int AreaEffect { get { return _areaEffect; } }
        public int MaxCapacity { get { return _maxCapacity; } }
    }


    public class Ecole : Infrastructure
    {
        int _areaEffect;
        int _costPerMonth;
        int _maxCapacity;
        int _actualCapacity;
        int _effect = 5;
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
            _areaEffect = Info.AreaEffect;
            _costPerMonth = Info.CostPerMonth;
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
        public int PricePerMounth
        {
            get { return _costPerMonth; }
            set { _costPerMonth = value; }
        }
        public int AreaEffect
        {
            get { return _areaEffect; }
            set { _areaEffect = value; }
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
        public void BuildingEffect()
        {
            _box.AppliedEffect( _areaEffect, _effect );
        }

    }
}
