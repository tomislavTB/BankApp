using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a value for FirstName field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please provide a value for LastName field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please provide a value for Address field")]
        public string Address { get; set; }


        [Required(ErrorMessage = "Please provide a value for Birthdate field")]
        public DateTime Birthdate { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Please provide value IBAN number")]
        public string IBAN { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public ICollection<Saving> Savings { get; set; }
    }
}
