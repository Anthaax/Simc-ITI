using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    interface IStolen
    {
        /// <summary>
        /// Get or Set StealChance of a building
        /// </summary>
        int StealChance { get; set; }
        /// <summary>
        /// Change the state of an interface
        /// </summary>
        bool IsSteal { get; set; } 
    }
}
