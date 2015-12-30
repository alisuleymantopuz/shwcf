using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NetTcpBindingSample.Contracts.DataTransferObjects
{
    [DataContract]
    public class CategoryInfo
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Id { get; set; }
    }
}
