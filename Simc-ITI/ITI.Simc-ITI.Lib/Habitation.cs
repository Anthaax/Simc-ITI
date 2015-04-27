using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class Habitation
    {
        Private _private;
        int _revenu;
        int _price = 200;
        int _people;

        public Habitation( Private p )
        {
            // TODO: Complete member initialization
            _private = p;
            _people = 3;
            _revenu = _people * 1000;
        }

    }
}
