using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class AccountType
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a value for Name field")]
        public string Name { get; set; }


    }
}
