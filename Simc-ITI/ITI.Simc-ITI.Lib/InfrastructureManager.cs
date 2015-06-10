using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public class InfrastructureManager
    {
        readonly Dictionary<string, InfrastructureType> _types;

        public InfrastructureManager()
        {
            _types = new Dictionary<string, InfrastructureType>();
            Initialize();
        }

        void Initialize()
        {
            RegisterType( new EcoleType() );
            RegisterType( new RoadType() );
            RegisterType( new HabitationType() );
            RegisterType( new CommerceType() );
            RegisterType( new CentraleElectriqueType() );
        }

        void RegisterType( InfrastructureType t )
        {
            _types.Add( t.Name, t );
        }
        public InfrastructureType Find( string name )
        {
            InfrastructureType t;
            _types.TryGetValue( name, out t );
            return t;
        }

        public IEnumerable<InfrastructureType> AllTypes
        {
            get { return _types.Values; }
        }
    }
}
