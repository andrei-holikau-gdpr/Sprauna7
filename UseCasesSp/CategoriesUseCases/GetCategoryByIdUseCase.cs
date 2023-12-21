using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
    {

        #region const 

        #endregion
        #region private fields

        private readonly ICategoryRepository categoryRepository;

        #endregion

        #region override methods

        public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        #endregion
        #region private methods

        public Category Execute(int categoryId)
        {
            return categoryRepository.GetCategoryById(categoryId);
        }

        #endregion
    }
}
