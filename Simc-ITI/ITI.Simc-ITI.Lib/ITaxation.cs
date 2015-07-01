using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITI.Simc_ITI.Build
{
    public interface ITaxation
    {
        /// <summary>
        /// Get or Set the taxation for an Infrastructure
        /// </summary>
        int Taxation { get; set; }
        /// <summary>
        /// Get or Set the Salary of an Infrastructure
        /// </summary>
        int Salary { get; }
    }
}
