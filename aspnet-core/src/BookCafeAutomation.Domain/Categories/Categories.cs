using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace DENEME.Categories;

    public class Category : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

      
        protected Category()
        {
        }

        public Category(Guid id, string name)
            : base(id)
        {
            Name = name;
        }
    }
