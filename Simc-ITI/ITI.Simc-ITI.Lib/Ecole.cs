﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class Ecole
    {
        Public _public;
        int _price;
        int _pricePerMonth;
        int _areaEffect;

        public Ecole( Public p )
        {
            // TODO: Complete member initialization
            _public = p;
            _price = 500;
            _pricePerMonth = 20;
            _areaEffect = 3;
        }
    }
}
