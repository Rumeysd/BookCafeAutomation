using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DENEME.Authors
{
    public class Author : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string ShortBio { get; set; }
        protected Author()
        {
        }

    
        public Author(Guid id, string name, string shortBio)
            : base(id)
        {
            Name = name;
            ShortBio = shortBio;
        }
    }
}