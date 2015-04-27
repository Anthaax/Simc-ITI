using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    class Building
    {
        Public _public;
        Private _private;
        Infrastructure _infrastructure;
        

        internal Building( Infrastructure infrastructure, int ID )
        {
            _infrastructure = infrastructure;
            if(ID == 1)
            {
                CreatePublic( this, ID );
            }
            else
            {
                CreatePrivate( this, ID );
            }
        }

        private void CreatePrivate( Building building, int ID )
        {
            Private p = new Private( this);
            _private = p;
        }

        private void CreatePublic( Building building, int ID )
        {
            Public p = new Public( this );
            _public = p;
        }
    }
}
