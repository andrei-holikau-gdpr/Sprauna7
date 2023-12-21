using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCase
{
    public class EditCategoryUseCase : IEditCategoryUseCase
    {

        #region const 

        #endregion
        #region private fields

        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region override methods

        public EditCategoryUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #endregion
        #region private methods

        public void Execute(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }
        #endregion
    }
}
