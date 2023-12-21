using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoryInMemoryRepository : ICategoryRepository
    {
        private List<Category> categories;
        public CategoryInMemoryRepository()
        {
            categories = new List<Category>()
            {
                new Category{ CategoryId = 1, Name = "Одежда", Description = "Описание 1" },
                new Category{ CategoryId = 2, Name = "Обувь", Description = "Описание 2" },
                new Category{ CategoryId = 3, Name = "Куртка", Description = "Описание 3" }
            };
        }

        public void AddCategory(Category category)
        {
            if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;

            if (categories != null && categories.Count > 0)
            {
                var maxId = categories.Max(x => x.CategoryId);
                category.CategoryId = maxId + 1;
            } else
            {
                category.CategoryId = 1;
            }

            categories?.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }
        }


        public IEnumerable<Category> GetCategories()
        {
            return categories;
        }

#pragma warning disable CS8766 // ToDo: warning CS8766
        public Category? GetCategoryById(int categoryId)
        {
            return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }
#pragma warning restore CS8766

        public void DeleteCategory(int categoryId)
        {
            var item = GetCategoryById(categoryId);
            if (item != null)
            {
                categories?.Remove(item);
            }
        }
    }
}
