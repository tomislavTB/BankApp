using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class City
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please provide a value for Name field")]
        public string Name { get; set; }

        [Required, MaxLength(5, ErrorMessage = "Please provide a value Zip code")]
        public string Zip { get; set; }


        public int CountryId { get; set; }
        public Country Country { get; set; }

    }
}
