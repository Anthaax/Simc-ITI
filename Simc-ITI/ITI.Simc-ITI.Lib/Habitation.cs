using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public class HabitationType : InfrastructureType
    {
        int _happyness;
        public HabitationType()
            : base( "Habitation", true, 0, "C:/dev/Textures/Habitation.bmp" )
        {
            _happyness = 50;
        }
        public override Infrastructure CreateInfrastructure( Box location )
        {
            if( location.Infrasructure == null )
            {
                location.Map.Money.ActualMoney -= this.BuildingCost;
                return new Habitation( location, this );
            }
            return null;
        }
    }
    public class Habitation : Infrastructure
    {

    }
}
