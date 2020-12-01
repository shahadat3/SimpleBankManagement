using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankManagementWebApp.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Contact No")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }
        [Required(ErrorMessage = "Please enter Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please enter account no")]
        [Display(Name = "Account No")]
        public string AcNo { get; set; }
        [Required(ErrorMessage = "Please enter Date")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Please enter initial Balance")]
        [Display(Name = "Initial Balance")]
        public decimal Balance { get; set; }
    }
}