using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTcpBindingSample.Domain.ProductAggregate
{
    public class CategoryManager : ICategoryManager
    {
        public ICategoryRepository CategoryRepository { get; private set; }
       
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public List<Category> List(CategorySearchCriteria criteria)
        {
            return this.CategoryRepository.List(criteria);
        }
    }
}
