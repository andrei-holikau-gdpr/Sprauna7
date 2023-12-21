using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.PackagesUseCases
{
    public class ViewDepartmentDpsUseCase : IViewDepartmentDpsUseCase
    {
        private readonly IDepartmentDpRepository departmentDeliveryParcelRepository;

        public ViewDepartmentDpsUseCase(IDepartmentDpRepository departmentDeliveryParcelRepository)
        {
            this.departmentDeliveryParcelRepository = departmentDeliveryParcelRepository;
        }
        public IEnumerable<DepartmentDeliveryParcel> Execute()
        {
            return departmentDeliveryParcelRepository.GetDepartments();
        }
    }
}
