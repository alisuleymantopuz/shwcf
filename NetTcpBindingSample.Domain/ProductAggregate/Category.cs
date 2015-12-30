using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTcpBindingSample.Domain.ProductAggregate
{
    public class Category
    {
        public virtual int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
