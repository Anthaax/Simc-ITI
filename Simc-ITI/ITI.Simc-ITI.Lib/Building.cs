using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Lib
{
    public class Building
    {
        Public _public;
        Private _private;
        Infrastructure _infrastructure;

        public Building( Infrastructure infrastructure, int AreaEffect, int PricePerMounth, string name )
        {
            _infrastructure = infrastructure;
            if( PricePerMounth != 0)
            {
                CreatePublic( this, AreaEffect, PricePerMounth, name );
            }
            else
            {
                CreatePrivate( this, name );
            }
        }

        private void CreatePrivate( Building building, string name )
        {
            Private p = new Private( this, name);
            _private = p;
        }

        private void CreatePublic( Building building, int AreaEffect, int PricePerMounth, string name  )
        {
            Public p = new Public( this, AreaEffect, PricePerMounth, name );
            _public = p;
        }

        public Public IsPublic
        {
            get { return _public;  }
        }

        public Private IsPrivate
        {
            get { return _private; }
        }
    }
}
