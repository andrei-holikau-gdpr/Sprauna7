using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetPackagesByStatusUseCase
    {
        IEnumerable<Package> Execute(StatusesPackage statusesPackage);
    }
}