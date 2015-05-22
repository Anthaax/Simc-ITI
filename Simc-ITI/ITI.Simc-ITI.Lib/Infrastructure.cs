using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ITI.Simc_ITI.Money.Lib;
using ITI.Simc_ITI;

namespace ITI.Simc_ITI.Build
{
    public abstract class Infrastructure : IInfrastructureForBox
    {
        Box _box;

        protected Infrastructure(Box b)
        {
            _box = b;
            b.Infrasructure = this;
        }
        public Box Box
        {
            get { return _box; }
        }
        public abstract void Draw( Graphics g, Rectangle rectSource, float scaleFactor );
        public abstract string Name();
        public abstract void Happyness();
    }
}
