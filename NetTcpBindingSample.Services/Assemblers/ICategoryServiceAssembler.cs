using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTcpBindingSample.Services.Assemblers
{
    public interface ICategoryServiceAssembler
    {
        Contracts.DataTransferObjects.SearchCategoryResponse CreateSearchCategoryResponse(List<Domain.ProductAggregate.Category> categories);

        Domain.ProductAggregate.CategorySearchCriteria CreateCategorySearchCriteria(Contracts.DataTransferObjects.SearchCategoryRequest searchCategoryRequest);
    }
}
