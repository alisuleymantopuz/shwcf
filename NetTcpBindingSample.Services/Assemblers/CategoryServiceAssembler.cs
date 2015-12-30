using NetTcpBindingSample.Contracts.DataTransferObjects;
using NetTcpBindingSample.Domain.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTcpBindingSample.Services.Assemblers
{
    public class CategoryServiceAssembler : ICategoryServiceAssembler
    {
        public SearchCategoryResponse CreateSearchCategoryResponse(List<Category> categories)
        {
            SearchCategoryResponse searchCategoryResponse = new SearchCategoryResponse();

            if (categories != null)
            {
                searchCategoryResponse.SearchResult = new List<CategoryInfo>();
            }

            if (categories != null && categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    searchCategoryResponse.SearchResult.Add(new CategoryInfo()
                    {
                        Id = category.Id,
                        Name = category.Name
                    });
                }
            }
            return searchCategoryResponse;
        }


        public CategorySearchCriteria CreateCategorySearchCriteria(SearchCategoryRequest searchCategoryRequest)
        {
            CategorySearchCriteria criteria = new CategorySearchCriteria();

            if (searchCategoryRequest != null)
                criteria.Name = searchCategoryRequest.Name;

            return criteria;
        }
    }
}
