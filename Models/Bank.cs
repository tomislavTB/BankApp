using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;





namespace BankApp.Models

{
   public class Bank
    {
        public int Id { get; set; }


        [Required]
        [StringLength(15, ErrorMessage = "Please provide value IBAN number")]
        public string IBAN { get; set; }

        [Required, MaxLength(10, ErrorMessage = "Please provide value phone number")]
        public string Phone { get; set; }


        [Display(Name = "Bank Email")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        [Required]
        public string Email { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }


        [Required(ErrorMessage = "Please provide a value for Name field")]
        public string Name { get; set; }


        public ICollection<Saving> Savings { get; set; }
    }
}