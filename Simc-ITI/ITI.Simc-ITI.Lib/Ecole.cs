using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Ecole
    {
        Public _public;
        int _areaEffect;

        public Ecole( Public p )
        {
            _public = p;
            _areaEffect = 3;
        }

        public int AreaEffect
        {
            get { return _areaEffect; }
            internal set { _areaEffect = value; }
        }
        
    }
}
