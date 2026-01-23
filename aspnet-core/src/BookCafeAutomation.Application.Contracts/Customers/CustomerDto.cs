using System;
using Volo.Abp.Application.Dtos;

namespace BookCafeAutomation.Customers
{
    public class CustomerDto : EntityDto<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public int Score { get; set; }
    }
}