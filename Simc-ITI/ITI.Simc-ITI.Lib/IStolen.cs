using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public interface IStolen
    {
        int StealChance { get; set; }
        bool IsSteal { get; set; }
        int IndicatorSteal { get; set; }
    }
}
