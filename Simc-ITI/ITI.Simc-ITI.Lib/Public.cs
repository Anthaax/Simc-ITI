using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Public
    {
        Ecole _ecole;
        private Building _building;
        int _pricePerMounth;

        public Public( Building building, int AreaEffect, int PricePerMounth, string name)
        {
            _building = building;
            _pricePerMounth = PricePerMounth;
            if( AreaEffect != 0 )
            {
                if (name == "Ecole") CreateEcole( this );
            }
        }

        private void CreateEcole( Public p )
        {
            Ecole e = new Ecole( this );
            _ecole = e;
        }

        public Ecole MySchool
        {
            get { return _ecole;}
        }

        public int PricePerMounth
        {
            get { return _pricePerMounth; }
            set { _pricePerMounth = value; }
        }
    }
}
