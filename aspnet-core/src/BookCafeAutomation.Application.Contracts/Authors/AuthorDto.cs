using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.Authors
{
    public class AuthorDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string ShortBio { get; set; }
    }
}