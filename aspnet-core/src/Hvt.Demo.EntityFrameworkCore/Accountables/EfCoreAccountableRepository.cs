using Hvt.Demo.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Hvt.Demo.Accountables
{
    public class EfCoreAccountableRepository : EfCoreRepository<DemoDbContext, Accountable, Guid>, IAccountableRepository
    {
        public EfCoreAccountableRepository(IDbContextProvider<DemoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Accountable> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(a => a.Name == name);
        }

        public async Task<List<Accountable>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    a => a.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
