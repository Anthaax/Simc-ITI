using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface Isteal
    {
        /// <summary>
        /// Get or Set StealChance of a building
        /// </summary>
        int StealChance { get; set; }
        /// <summary>
        /// Get the number of turn the habitation will be stolen
        /// </summary>
        int IndicatorSteal { get; set; }
        /// <summary>
        /// Change the state of an interface
        /// </summary>
        bool IsSteal { get; set; } 
    }
}
