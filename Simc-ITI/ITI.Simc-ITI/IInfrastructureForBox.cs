using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    public interface IInfrastructureForBox
    {
        IInfrastructureType Type { get; }
        void Draw( Graphics g, Rectangle rectSource, float scaleFactor );
        void Destroy();
        void OnCreatedAround( Box b );
        void OnDestroyingAround( Box b );
        void Update();
        
    }
}
