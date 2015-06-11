using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ITI.Simc_ITI;

namespace ITI.Simc_ITI.Build
{
    public abstract class Infrastructure : IInfrastructureForBox
    {
        Box _box;
        InfrastructureType _type;
        protected Infrastructure(Box b, InfrastructureType i)
        {
            _box = b;
            _type = i;
            b.Infrasructure = this;
        }
        public Box Box
        {
            get { return _box; }
        }
        public GameContext GameContext
        { 
            get { return _type.GameContext; } 
        }

        public abstract void Draw( Graphics g, Rectangle rectSource, float scaleFactor );
        IInfrastructureType IInfrastructureForBox.Type { get { return _type; } }
        public InfrastructureType Type { get { return _type; } }
        public abstract void OnCreatedAround( Box b );
        public abstract void OnDestroyingAround( Box b );
        public int AreaEffect { get; protected set; }

        public event EventHandler Destoyed;
        public void Destroy()
        {
            OnDestroy();
            IEnumerable<Box> nearBox =  _box.NearBoxes( _box.Infrasructure.Type.AreaEffect );
            foreach( var box in nearBox)
            {
                if( box.Infrasructure != null )
                {
                    box.Infrasructure.OnDestroyingAround( _box );
                }
            }
            var h = Destoyed;
            if( h != null ) h( this, EventArgs.Empty );
            _box.Infrasructure = null;
            _box = null;
        }
        public void Update()
        {
            
        }
        public abstract void OnDestroy();
    }
}
