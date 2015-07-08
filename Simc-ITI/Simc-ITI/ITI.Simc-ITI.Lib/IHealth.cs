using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface IHealth
    {
        /// <summary>
        /// Get or Set if near an infrastructure have an negative impact 
        /// </summary>
        bool Health { get; set; } 
    }
}
