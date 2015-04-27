using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class VRoad
    {
        Road _road;
        int _price;
        bool _IsElectric;
        bool _IsWater;
        int _pricePerMonth;

        internal VRoad( Road road )
        {
            // TODO: Complete member initialization
            _road = road;
            _IsElectric = true;
            _IsWater = true;
            _price = 25;
            _pricePerMonth = 5;
        }

        bool Electricity
        {
            get { return _IsElectric; }
            internal set { _IsElectric = value; }
        }
    }
}
