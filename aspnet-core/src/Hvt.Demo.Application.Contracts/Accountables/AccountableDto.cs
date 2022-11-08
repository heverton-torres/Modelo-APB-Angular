using System;
using Volo.Abp.Application.Dtos;

namespace Hvt.Demo.Accountables
{
    public class AccountableDto:EntityDto<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AccountablePosition Position { get; set; }
    }
}