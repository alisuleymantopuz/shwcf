using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using NetTcpBindingSample.Contracts.DataTransferObjects;

namespace NetTcpBindingSample.Contracts.Services
{
    [ServiceContract]
    public interface ICategoryService
    {
        [OperationContract]
        SearchCategoryResponse SearchCategory(SearchCategoryRequest searchCategoryRequest);
    }
}
