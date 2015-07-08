using System;
namespace ITI.Simc_ITI
{
    public interface IInfrastructureType
    {
        int BuildingCost { get; }
        string Name { get; }
        int AreaEffect { get; }
    }
}
