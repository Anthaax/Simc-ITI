using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class Public
    {
        Ecole _ecole;
        private Building building;

        public Public( Building building )
        {
            // TODO: Complete member initialization
            this.building = building;
            CreateEcole(this);
        }

        private void CreateEcole( Public p )
        {
            Ecole e = new Ecole( this );
            _ecole = e;
        }
    }
}
