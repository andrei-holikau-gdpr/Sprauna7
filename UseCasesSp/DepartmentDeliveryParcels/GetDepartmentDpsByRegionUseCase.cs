using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;
using DepartmentDp = CoreBusiness.DepartmentDeliveryParcel;

namespace UseCases.DepartmentDeliveryParcels
{
    public class GetDepartmentDpsByRegionUseCase : IGetDepartmentDpsByRegionUseCase
    {

        private readonly IDepartmentDpRepository departmentDpRepository;

        public GetDepartmentDpsByRegionUseCase(IDepartmentDpRepository departmentDpRepository)
        {
            this.departmentDpRepository = departmentDpRepository;
        }

        public IEnumerable<DepartmentDp> Execute(int regionId)
        {
            return departmentDpRepository.GetDepartmentDpsByRegion(regionId);
        }
    }
}
