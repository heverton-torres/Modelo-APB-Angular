using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Hvt.Demo.Accountables
{
    public interface IAccountableAppService:IApplicationService
    {
        Task<AccountableDto> GetAsync(Guid id);

        Task<PagedResultDto<AccountableDto>> GetListAsync(GetAccountableListDto input);

        Task<AccountableDto> CreateAsync(CreateAccountableDto input);

        Task UpdateAsync(Guid id, UpdateAccountableDto input);

        Task DeleteAsync(Guid id);
    }
}
