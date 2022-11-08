using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Hvt.Demo.Accountables
{
    public class AccountableManager:DomainService
    {
        private readonly IAccountableRepository _accountableRepository;

        public AccountableManager(IAccountableRepository accountableRepository)
        {
            _accountableRepository = accountableRepository;
        }

        public async Task<Accountable> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            AccountablePosition position = AccountablePosition.Undefined)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingAccountable = await _accountableRepository.FindByNameAsync(name);
            if (existingAccountable != null)
            {
                throw new AccountableAlreadyExistsException(name);
            }

            return new Accountable(
                GuidGenerator.Create(),
                name,
                birthDate,
                position
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Accountable accountable,
            [NotNull] string newName)
        {
            Check.NotNull(accountable, nameof(accountable));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingAccountable = await _accountableRepository.FindByNameAsync(newName);
            if (existingAccountable != null && existingAccountable.Id != accountable.Id)
            {
                throw new AccountableAlreadyExistsException(newName);
            }

            accountable.ChangeName(newName);
        }
    }
}
