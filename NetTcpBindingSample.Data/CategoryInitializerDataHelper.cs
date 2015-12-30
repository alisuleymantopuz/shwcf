using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTcpBindingSample.Domain.ProductAggregate;

namespace NetTcpBindingSample.Data
{
    public static class CategoryInitializerDataHelper
    {
        public static List<Category> ListOfSampleCategoriesData()
        {
            return new List<Category>()
            {
                new Category()
                {
                    Id = 1, Name = "Beverages", Description = ""
                },
                new Category()
                {
                    Id = 2, Name = "Condiments", Description = ""
                },
                new Category()
                {
                    Id = 3, Name = "Daily Products", Description = ""                                
                }
            };
        }
    }
}
