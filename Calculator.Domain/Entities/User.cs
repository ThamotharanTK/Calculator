using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.Domain.Entities
{
    public class User :BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        [NotMapped]
        public string AccessToken { get; set; }
        [NotMapped]
        public DateTime? ExpireAt { get; set; }
    }
}
