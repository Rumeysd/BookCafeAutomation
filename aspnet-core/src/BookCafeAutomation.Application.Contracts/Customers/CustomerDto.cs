using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.Customers
{
    public class CustomerDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}