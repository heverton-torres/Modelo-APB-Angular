using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Hvt.Demo.Accountables
{
    public class Accountable : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public AccountablePosition Position { get; set; }


        private Accountable()
        {

        }

        internal Accountable(Guid id, [NotNull] string name,DateTime birthDate, AccountablePosition position = AccountablePosition.Undefined)
        {
            SetName(name);
            BirthDate = birthDate;
            Position = position;
        }

        internal Accountable ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull]string name)
        {
            Name = Check.NotNullOrWhiteSpace(name, nameof(name), maxLength: AccountablesConsts.MaxNameLength);
        }
    }
}
