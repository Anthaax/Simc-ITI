using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface IBurn
    {
        /// <summary>
        /// Get or Set the BurnigChance of an IBurn infrastructure
        /// </summary>
        int BurningChance { get; set; }
        /// <summary>
        /// Get or Set state of an IBurn infrastructure
        /// </summary>
        bool IsBurning { get; set; } 
    }
}
