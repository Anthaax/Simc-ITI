using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public abstract class InfrastructureType
    {
        readonly string _name;
        readonly bool _isPrivate;
        readonly int _buildingCost;
        readonly string _texturePath;

        protected InfrastructureType( string name, bool isPrivate, int buildingCost, string path)
        {
            _name = name;
            _isPrivate = isPrivate;
            _buildingCost = buildingCost;
            _texturePath = path;
        }

        public string Name { get { return _name; } }
        public bool IsPrivate { get { return _isPrivate; } }
        public int BuildingCost { get { return _buildingCost; } }
        public string TexturePath { get { return _texturePath; } }

        public abstract Infrastructure CreateInfrastructure( Box location );
        
    }
}
