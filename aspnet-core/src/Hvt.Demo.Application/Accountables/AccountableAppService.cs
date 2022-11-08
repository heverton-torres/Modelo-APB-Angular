using Hvt.Demo.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Hvt.Demo.Accountables
{
    [Authorize(DemoPermissions.Accountables.Default)]
    public class AccountableAppService : DemoAppService, IAccountableAppService
    {
        private readonly IAccountableRepository _accountableRepository;
        private readonly AccountableManager _accountableManager;

        public AccountableAppService(IAccountableRepository accountableRepository, AccountableManager accountableManager)
        {
            _accountableRepository = accountableRepository;
            _accountableManager = accountableManager;
        }
        [Authorize(DemoPermissions.Accountables.Create)]
        public async Task<AccountableDto> CreateAsync(CreateAccountableDto input)
        {
            var accountable = await _accountableManager.CreateAsync(
                        input.Name,
                        input.BirthDate,
                        input.Position
            );

            await _accountableRepository.InsertAsync(accountable);

            return ObjectMapper.Map<Accountable, AccountableDto>(accountable);
        }
        [Authorize(DemoPermissions.Accountables.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _accountableRepository.DeleteAsync(id);
        }

        public async Task<AccountableDto> GetAsync(Guid id)
        {
            var account = await _accountableRepository.GetAsync(id);
            return ObjectMapper.Map<Accountable, AccountableDto>(account);

        }

        public async Task<PagedResultDto<AccountableDto>> GetListAsync(GetAccountableListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Accountable.Name);
            }

            var accountables = await _accountableRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter);

            var totalCount = input.Filter == null
                ? await _accountableRepository.CountAsync()
                : await _accountableRepository.CountAsync(
                        x => x.Name.Contains(input.Filter));

            return new PagedResultDto<AccountableDto>(
                totalCount,
                ObjectMapper.Map<List<Accountable>, List<AccountableDto>>(accountables));
        }

        [Authorize(DemoPermissions.Accountables.Edit)]
        public async Task UpdateAsync(Guid id, UpdateAccountableDto input)
        {
            var accountable = await _accountableRepository.GetAsync(id);

            if (accountable.Name !=input.Name)
            {
                await _accountableManager.ChangeNameAsync(accountable, input.Name);
            }

            accountable.BirthDate = input.BirthDate;
            accountable.Position = input.Position;

            await _accountableRepository.UpdateAsync(accountable);
        }
    }
}
