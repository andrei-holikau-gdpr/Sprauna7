using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.DepartmentDeliveryParcels
{
    public class AddPvzUseCase : IAddPvzUseCase
    {
        private readonly IDepartmentDpRepository departmentDpRepository;

        public AddPvzUseCase(IDepartmentDpRepository departmentDpRepository)
        {
            this.departmentDpRepository = departmentDpRepository;
        }
        public void Execute(DepartmentDeliveryParcel pvz)
        {
            departmentDpRepository.AddDepartment(pvz);
        }
    }
}
