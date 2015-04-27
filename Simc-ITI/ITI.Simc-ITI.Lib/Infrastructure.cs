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
                CreateRoad( this ); 
            }
            else
            {
                CreateBuilding( this, ID );
            }
        }

        private void CreateRoad( Infrastructure infrastructure)
        {
            Road r = new Road(this);
            _road = r;
        }

        private void CreateBuilding( Infrastructure infrastructure, int ID )
        {
            Building b = new Building( this, ID );
            _building = b;
        }

        public Building MyBuilding
        {
            get { return _building; }
        }

        public Road MyRoad
        {
            get { return _road; }
        }
    }
}
