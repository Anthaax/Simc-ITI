using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Road
    {
        VRoad _vroad;
        Infrastructure _infrastructure;
        int _pricePerMounth;

        public Road( Infrastructure infrastructure, bool IsWater, bool IsElectric, int PricePerMounth, string name )
        {
            _infrastructure = infrastructure;
            _pricePerMounth = PricePerMounth;
            if (name == "VR")CreateVRoad( this, IsWater, IsElectric, name );
        }

        private void CreateVRoad( Road road, bool IsWater, bool IsElectric, string name )
        {
            VRoad vr = new VRoad(this, IsWater, IsElectric, name);
            _vroad = vr;
        }

        public VRoad MyVRoad
        {
             get { return _vroad; }
        }
    }
}
