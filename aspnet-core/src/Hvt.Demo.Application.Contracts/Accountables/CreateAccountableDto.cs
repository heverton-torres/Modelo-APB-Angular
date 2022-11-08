using System;
using System.ComponentModel.DataAnnotations;

namespace Hvt.Demo.Accountables
{
    public class CreateAccountableDto
    {
        [Required]
        [StringLength(AccountablesConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public AccountablePosition Position { get; set; }
    }
}