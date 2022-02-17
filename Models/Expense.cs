using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdaApp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense Name")]
        [Required]
        public string ExpenseName { get; set; }


        [Required]
        [Range(1, int.MaxValue, ErrorMessage ="Amount must be greater than zero!")]
        [DisplayName("Amount")]
        public int ExpenseAmount { get; set; }
    }
}
