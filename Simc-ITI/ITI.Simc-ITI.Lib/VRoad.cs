using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class VRoad
    {
        Road _road;
        bool _IsElectric;
        bool _IsWater;

        public VRoad( Road road, bool IsWater, bool IsElectric, string name )
        {
            _road = road;
            _IsElectric = IsElectric;
            _IsWater = IsWater;
        }

        public bool Electricity
        {
            get { return _IsElectric; }
            set { _IsElectric = value; }
        }

        public bool Water
        {
            get { return _IsWater; }
            set { _IsWater = value; }
        }
         
    }
}
