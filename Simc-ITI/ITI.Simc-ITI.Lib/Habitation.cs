using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Habitation
    {
        Private _private;
        int _revenu;
        int _people;

        public Habitation( Private p )
        {
            _private = p;
            _people = 3;
            _revenu = _people * 1000;
        }

        public int People
        {
            get { return _people; }
            internal set
            {
                _people = value;
                int rev = value * 1000;
                Revenu = rev;
            }
        }

        public int Revenu
        {
            get { return _revenu; }
            private set { _revenu = value; }
        }

    }
}
