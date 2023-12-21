using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewPackagesUseCase
    {
        IEnumerable<Package> Execute();
    }
}