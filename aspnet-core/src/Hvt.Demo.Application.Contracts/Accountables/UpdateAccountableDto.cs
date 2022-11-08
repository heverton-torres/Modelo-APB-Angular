using System.ComponentModel.DataAnnotations;
using System;

namespace Hvt.Demo.Accountables
{
    public class UpdateAccountableDto
    {
        [Required]
        [StringLength(AccountablesConsts.MaxNameLength)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public AccountablePosition Position { get; set; }
    }
}