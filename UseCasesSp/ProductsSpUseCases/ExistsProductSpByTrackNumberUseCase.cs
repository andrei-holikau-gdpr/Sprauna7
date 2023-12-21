using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCasesSp.UseCaseInterfaces;

namespace UseCasesSp.ProductsSpUseCases
{
    public class ExistsProductSpByTrackNumberUseCase : IExistsProductSpByTrackNumberUseCase
    {
        private readonly IProductSpRepository productSpRepository;

        public ExistsProductSpByTrackNumberUseCase(IProductSpRepository productSpRepository)
        {
            this.productSpRepository = productSpRepository;
        }

        public bool Execute(string TrackNumber)
        {
            return productSpRepository
                .ExistsProductSpByTrackNumber(TrackNumber);
        }
    }
}
