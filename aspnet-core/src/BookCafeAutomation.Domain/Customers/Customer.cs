using System;
using Volo.Abp.Domain.Entities.Auditing;
namespace BookCafeAutomation.Customers
{
    public class Customer : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public int Score { get; set; }

        protected Customer()
        {
        }

        public Customer(Guid id, string name, string surname, string phoneNumber)
            : base(id)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Score = 0; 
        }
    }
}