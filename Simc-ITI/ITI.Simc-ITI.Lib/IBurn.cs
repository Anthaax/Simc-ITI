using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface IBurn
    {
        int FireChance { get; set; }
        bool IsBurnig { get; set; } 
    }
}
