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

        public Road( Infrastructure infrastructure)
        {
            _infrastructure = infrastructure;
            CreateVRoad( this );
        }

        private void CreateVRoad( Road road )
        {
            VRoad vr = new VRoad(this);
            _vroad = vr;
        }

        public VRoad MyVRoad
        {
             get { return _vroad; }
        }
    }
}
