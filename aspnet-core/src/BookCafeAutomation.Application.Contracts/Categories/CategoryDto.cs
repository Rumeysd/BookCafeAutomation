using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.Categories
{
    public class CategoryDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}