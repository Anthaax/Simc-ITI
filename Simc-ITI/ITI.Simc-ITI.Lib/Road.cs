using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class Road
    {
        VRoad _vroad;
        Infrastructure _infrastructure;

        internal Road( Infrastructure infrastructure)
        {
            // TODO: Complete member initialization
            _infrastructure = infrastructure;
            CreateVRoad( this );
        }

        private void CreateVRoad( Road road )
        {
            VRoad vr = new VRoad(this);
            _vroad = vr;
        }
    }
}
