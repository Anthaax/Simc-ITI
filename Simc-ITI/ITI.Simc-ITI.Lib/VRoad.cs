using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class VRoad
    {
        Road _road;
        int _price;
        bool _IsElectric;
        bool _IsWater;
        int _pricePerMonth;

        public VRoad( Road road )
        {
            // TODO: Complete member initialization
            _road = road;
            _IsElectric = true;
            _IsWater = true;
            _price = 25;
            _pricePerMonth = 5;
        }

        public bool Electricity
        {
            get { return _IsElectric; }
            set { _IsElectric = value; }
        }

         
    }
}
