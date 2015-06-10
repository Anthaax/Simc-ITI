using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public abstract class InfrastructureType : IInfrastructureType
    {
        readonly string _name;
        readonly int _areaEffect;
        readonly int _buildingCost;

        protected InfrastructureType( string name, int buildingCost, int areaEffect)
        {
            _name = name;
            _buildingCost = buildingCost;
            _areaEffect = areaEffect;
        }

        public string Name { get { return _name; } }
        public int AreaEffect { get { return _areaEffect; } }
        public int BuildingCost { get { return _buildingCost; } }

        public bool CanCreatedNearRoad( Box b )
        {
            bool check = false;
            IEnumerable<Box> nearBoxes = b.NearBoxes( 1 );
            foreach( var box in nearBoxes )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Infrasructure.Type.Name == "Route" ) check = true;
                }
            }
            return check;
        }
        public bool CanCreated( Box b )
        {
            bool check = false;
            IEnumerable<Box> nearCentral = b.NearBoxes( 13 );
            foreach( var box in nearCentral )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Infrasructure.Type.Name == "CentraleElectrique" ) check = true;
                }
            }
            return check;
        }
        public bool CanDestroy(Box b)
        {
            bool check = false;
            IEnumerable<Box> nearBoxes = b.NearBoxes( 1 );
            foreach( var box in nearBoxes )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Infrasructure.Type.Name != "Route" ) check = true;
                }
            }
            return check;
        }
        public event EventHandler BuildingHasBeenCreated;
        public Infrastructure CreateInfrastructure( Box b, object creationConfig )
        {
            if( b.Infrasructure != null ) throw new InvalidOperationException( "The box alreay has an Infrastructure." );
            Infrastructure infra = DoCreateInfrastructure( b, creationConfig);
            IEnumerable<Box> nearBoxes = b.NearBoxes( infra.Type.AreaEffect );
            foreach( var box in nearBoxes )
            {
                if( box.Infrasructure != null )
                {
                    box.Infrasructure.OnCreatedAround( b );
                }
            }
            var h = BuildingHasBeenCreated;
            if( h != null ) h( this, EventArgs.Empty );
            return infra;
        }

        protected abstract Infrastructure DoCreateInfrastructure( Box location, object creatoionConfig );
    }
}
