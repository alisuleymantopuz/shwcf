using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTcpBindingSample.Domain.ProductAggregate
{
    public interface ICategoryManager
    {
        List<Category> List(CategorySearchCriteria criteria);
    }
}
