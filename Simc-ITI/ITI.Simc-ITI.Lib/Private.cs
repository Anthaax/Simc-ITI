using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Private
    {
        Habitation _habitation;
        Building _building;

        public Private( Building building, string name)
        {
            _building = building;
            if(name == "Habitation") CreateHouse( this );
            
        }

        private void CreateHouse( Private p )
        {
            Habitation h = new Habitation(this);
            _habitation = h;
        }

        public Habitation MyHabitation
        {
            get { return _habitation; }
        }
    }
}
