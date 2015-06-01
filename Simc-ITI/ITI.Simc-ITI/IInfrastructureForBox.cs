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
        void Draw( Graphics g, Rectangle rectSource, float scaleFactor );
        string Name();
        void Destroy();
        void HappynessEffect(int effect);
        int Happyness();
        bool Private();
    }
}
