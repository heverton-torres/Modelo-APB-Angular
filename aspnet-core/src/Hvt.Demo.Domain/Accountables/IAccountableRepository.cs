using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Hvt.Demo.Accountables
{
    public interface IAccountableRepository:IRepository<Accountable,Guid>
    {
        Task<Accountable> FindByNameAsync(string name);

        Task<List<Accountable>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}