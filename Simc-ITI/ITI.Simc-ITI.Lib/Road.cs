using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Road
    {
        VRoad _vroad;
        HRoad _hroad;
        CRoad _croad;
        Infrastructure _infrastructure;
        int _pricePerMounth;

        public Road( Infrastructure infrastructure, bool IsWater, bool IsElectric, int PricePerMounth, string name )
        {
            _infrastructure = infrastructure;
            _pricePerMounth = PricePerMounth;
            if( name == "RV" ) CreateVRoad( this, IsWater, IsElectric, name );
            else if( name == "RH" ) CreateHRoad( this, IsWater, IsElectric, name );
            else if( name == "RC" ) CreateCRoad( this, IsWater, IsElectric, name );
        }

        private void CreateCRoad( Road road, bool IsWater, bool IsElectric, string name )
        {
            CRoad cr = new CRoad( this, IsWater, IsElectric, name );
            _croad = cr;
        }

        private void CreateHRoad( Road road, bool IsWater, bool IsElectric, string name )
        {
            HRoad hr = new HRoad( this, IsWater, IsElectric, name );
            _hroad = hr;
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
