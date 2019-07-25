using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BankApp.Models
{
    public class Saving
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please provide a value for Duration field")]
        public DateTime StartOfSaving { get; set; }


        [Required(ErrorMessage = "Please provide a value for Amount field")]
        public int Amount { get; set; }


        [Required(ErrorMessage = "Please provide a value for Interest_rate field")]
        public decimal Interest_rate { get; set; }



        public int AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int BankId { get; set; }
        public Bank Bank { get; set; }


    }
}
