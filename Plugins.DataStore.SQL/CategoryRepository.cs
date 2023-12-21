using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SpraunaContext db;
        public CategoryRepository(SpraunaContext db)
        {
            this.db = db;
        }

        public void AddCategory(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = db.Categories.Find(categoryId);
            if(category == null) { return; }

            db.Categories.Remove(category);
            db.SaveChanges();
        }

        public IEnumerable<Category> GetCategories()
        {
            return db.Categories.ToList();
        }

#pragma warning disable CS8766
        // ToDo: CS8766
        public Category? GetCategoryById(int categoryId)
        {
            return db.Categories?.Find(categoryId);
        }
#pragma warning restore CS8766

        public void UpdateCategory(Category category)
        {
            var cat = db.Categories.Find(category.CategoryId);
            if (cat != null)
            {
                cat.Name = category.Name;
                cat.Description = category.Description;
                db.SaveChanges();
            }
        }
    }
}
