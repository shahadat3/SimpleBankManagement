using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankManagementWebApp.Models
{
    public class Withdraw
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Account No")]
        public string AccountId { get; set; }
        [Required(ErrorMessage = "Please enter Withdraw Amount")]
        public int Ammount { get; set; }
        public string Date { get; set; }

        public int Balance { get; set; }
    }
    
}