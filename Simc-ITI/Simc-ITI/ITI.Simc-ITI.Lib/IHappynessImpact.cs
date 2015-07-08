using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface IHappynessImpact
    {
        /// <summary>
        /// Impact the happiness of the box
        /// </summary>
        /// <param name="b">A box with an infrastructure IHappyness is required</param>
        /// <returns></returns>
        int HappynessImpact(Box b);
    }
}
