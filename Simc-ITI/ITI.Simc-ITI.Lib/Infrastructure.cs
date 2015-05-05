using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI.Simc_ITI.Money.Lib;

namespace ITI.Simc_ITI.Lib
{
    public class Infrastructure
    {
        Building _building;
        Road _road;
        int _price;

        public Infrastructure(int Price, int areaEffect, int pricePermounth, bool IsWater, bool IsElectric, bool RoadNear, bool road, string name)
        {
            _price = Price;
            if( RoadNear == true && road != true )
            {
                
                CreateBuilding( this, areaEffect, pricePermounth, name );
            }
            else
            {
                CreateRoad( this, IsWater, IsElectric, pricePermounth, name );
            }
        }

        private void CreateRoad( Infrastructure infrastructure, bool IsWater, bool IsElectric, int PricePerMounth, string name)
        {
            Road r = new Road(this, IsWater, IsElectric, PricePerMounth, name);
            _road = r;
        }

        private void CreateBuilding( Infrastructure infrastructure, int AreaEffect, int PricePerMounth, string name)
        {
            Building b = new Building( this, AreaEffect, PricePerMounth, name );
            _building = b;
        }

        public Building MyBuilding
        {
            get { return _building; }
        }

        public Road MyRoad
        {
            get { return _road; }
        }

        public int MyMoney
        {
            get { return _price; }
        }
    }
}
