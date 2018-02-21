using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketAction.Server.Model
{
    public class Person : BaseEntity
    {
        public Person()
        {}

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Guid UserId { get; set; }

        [NotMapped]
        public User User { get; set; }
    }
}
