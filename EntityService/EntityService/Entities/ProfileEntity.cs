using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace EntityService.Entities
{
    [DataContract]
    public class ProfileEntity
    {
        [DataMember]
        string Id { get; set; }
        [DataMember]
        string OwnerId { get; set; }
        [DataMember]
        string PublisherId { get; set; }
        [DataMember]
        DateTime Insertion { get; set; }
        [DataMember]
        DateTime Change { get; set; }
        [DataMember]
        string Name { get; set; }
        [DataMember]
        string Password { get; set; }
        [DataMember]
        string[] Roles { get; set; }
        [DataMember]
        bool State { get; set; }
    }
}
