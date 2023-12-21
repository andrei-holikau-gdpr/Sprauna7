using CoreBusiness;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCasesSp.UseCaseInterfaces;

namespace UseCasesSp.FileSpUseCases
{
    public class AddFileSpUseCase : IAddFileSpUseCase
    {
        private readonly IFileSpRepository fileSpRepository;

        public AddFileSpUseCase(IFileSpRepository fileSpRepository)
        {
            this.fileSpRepository = fileSpRepository;
        }
        public int? Execute(FileSp fileSp)
        {
            return fileSpRepository.AddFileSp(fileSp);
        }
    }
}
