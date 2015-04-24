using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Lib
{
    public class Infrastructure
    {
        Building _building;
        Road _road;
        
        public Infrastructure(int ID)
        {
            if( ID == 0)
            {
                CreateBuilding( this, ID );
            }
            else
            {
                CreateRoad( this, ID );
            }
        }

        private void CreateRoad( Infrastructure infrastructure, int ID )
        {
            Road r = new Road( this, ID );
            _road = r;
        }

        private void CreateBuilding( Infrastructure infrastructure, int ID )
        {
            Building b = new Building( this, ID );
            _building = b;
        }
    }
}
