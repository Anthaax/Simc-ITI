using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public class InfrastructureManager
    {
        readonly GameContext _ctx;
        readonly Dictionary<string, InfrastructureType> _types;

        internal InfrastructureManager( GameContext ctx )
        {
            _ctx = ctx;
            _types = new Dictionary<string, InfrastructureType>();
            Initialize();
        }

        void Initialize()
        {
            RegisterType( new EcoleType( _ctx ) );
            RegisterType( new RoadType( _ctx ) );
            RegisterType( new HabitationType( _ctx ) );
            RegisterType( new CommerceType( _ctx ) );
            RegisterType( new CentraleElectriqueType( _ctx ) );
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
