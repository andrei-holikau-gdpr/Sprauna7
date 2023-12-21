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
    public class GetDepartmentDpByIdUseCase : IGetDepartmentDpByIdUseCase
    {
        #region private fields

        private readonly IDepartmentDpRepository departmentRepository;

        #endregion

        #region override methods

        public GetDepartmentDpByIdUseCase(IDepartmentDpRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        #endregion

        #region private methods

        public DepartmentDeliveryParcel Execute(int departmentId)
        {
            return departmentRepository.GetDepartmentById(departmentId);
        }

        #endregion
    }
}
