using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTcpBindingSample.Data;
using NetTcpBindingSample.Domain.ProductAggregate;

namespace NetTcpBindingSample.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> List(CategorySearchCriteria criteria)
        {
            if (criteria != null && !string.IsNullOrEmpty(criteria.Name))
            {
                return CategoryInitializerDataHelper.ListOfSampleCategoriesData().Where(x => x.Name.ToLower().Contains(criteria.Name.ToLower())).ToList();
            }
            else
            {
                return CategoryInitializerDataHelper.ListOfSampleCategoriesData();
            }
        }
    }
}
