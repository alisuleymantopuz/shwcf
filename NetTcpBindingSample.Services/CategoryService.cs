using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NetTcpBindingSample.Contracts.Services;
using NetTcpBindingSample.Contracts.DataTransferObjects;
using NetTcpBindingSample.Domain.ProductAggregate;
using NetTcpBindingSample.Services.Assemblers;

namespace NetTcpBindingSample.Services
{
    public class CategoryService : ICategoryService
    {
        public ICategoryManager CategoryManager { get; private set; }
        public ICategoryServiceAssembler CategoryServiceAssembler { get; private set; }

        public CategoryService(ICategoryManager categoryManager, ICategoryServiceAssembler categoryServiceAssembler)
        {
            CategoryServiceAssembler = categoryServiceAssembler;
            CategoryManager = categoryManager;
        }

        public SearchCategoryResponse SearchCategory(SearchCategoryRequest searchCategoryRequest)
        {
            CategorySearchCriteria criteria = this.CategoryServiceAssembler.CreateCategorySearchCriteria(searchCategoryRequest);

            List<Category> categories = this.CategoryManager.List(criteria);

            SearchCategoryResponse searchCategoryResponse = this.CategoryServiceAssembler.CreateSearchCategoryResponse(categories);

            return searchCategoryResponse;
        }
    }
}
