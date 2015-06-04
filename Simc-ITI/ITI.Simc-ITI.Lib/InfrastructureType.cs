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
        readonly string _texturePath;

        protected InfrastructureType( string name, int buildingCost, int areaEffect, string path)
        {
            _name = name;
            _buildingCost = buildingCost;
            _texturePath = path;
            _areaEffect = areaEffect;
        }

        public string Name { get { return _name; } }
        public int AreaEffect { get { return _areaEffect; } }
        public int BuildingCost { get { return _buildingCost; } }
        public string TexturePath { get { return _texturePath; } }

        public bool CanCreated( Box b )
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
        public Infrastructure CreateInfrastructure( Box b )
        {
            if( b.Infrasructure != null ) throw new InvalidOperationException( "The box alreay has an Infrastructure." );
            b.Map.Money.ActualMoney -= BuildingCost;
            Infrastructure infra = DoCreateInfrastructure( b );
            IEnumerable<Box> nearBoxes = b.NearBoxes( infra.Type.AreaEffect );
            foreach( var box in nearBoxes )
            {
                if( box.Infrasructure != null )
                {
                    box.Infrasructure.OnCreatedAround( b );
                }
            }
            return infra;
        }

        protected abstract Infrastructure DoCreateInfrastructure( Box location );
    }
}
