using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface IFire
    {
        /// <summary>
        /// Impact the fire chance of the box
        /// </summary>
        /// <param name="b"> A box with an infrastructure IBurn is required </param>
        /// <returns></returns>
        int FireChanceImpact( Box b );
    }
}
