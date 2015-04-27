using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class Private
    {
        Habitation _habitation;
        Building _building;

        public Private( Building building, int ID)
        {
            // TODO: Complete member initialization
            _building = building;
            CreateHouse( this );
        }

        private void CreateHouse( Private p )
        {
            Habitation h = new Habitation(this);
            _habitation = h;
        }
    }
}
