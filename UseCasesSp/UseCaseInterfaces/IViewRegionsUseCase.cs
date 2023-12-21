using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewRegionsUseCase
    {
        IEnumerable<Region> Execute();
    }
}