using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NetTcpBindingSample.Contracts.DataTransferObjects
{
    [DataContract]
    public class SearchCategoryResponse
    {
        [DataMember]
        public List<CategoryInfo> SearchResult { get; set; }
    }
}
