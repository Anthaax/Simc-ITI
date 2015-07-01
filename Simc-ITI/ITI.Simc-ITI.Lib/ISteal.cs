using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface ISteal
    {
        /// <summary>
        /// Impact the StealChance of the box
        /// </summary>
        /// <param name="b"> A box with an infrastructure IStolen is required </param>
        /// <returns></returns>
        int StealChanceImpact(Box b);
    }
}
