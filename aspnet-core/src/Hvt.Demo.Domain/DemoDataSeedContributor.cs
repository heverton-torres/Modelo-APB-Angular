using Hvt.Demo.Accountables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Hvt.Demo
{
    public class DemoDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IAccountableRepository _accountableRepository;
        private readonly AccountableManager _accountableManager;

        public DemoDataSeedContributor(IAccountableRepository accountableRepository, AccountableManager accountableManager)
        {
            _accountableRepository = accountableRepository;
            _accountableManager = accountableManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _accountableRepository.GetCountAsync() <= 0)
            {
                await _accountableManager.CreateAsync(
                    "Heverton Torres",
                    new DateTime(1991, 06, 12),
                    AccountablePosition.Techlead);

                await _accountableManager.CreateAsync(
                   "Keite Queiroz",
                   new DateTime(1992, 03, 15),
                   AccountablePosition.TeamMember);

                await _accountableManager.CreateAsync(
                   "Sabrina Silva",
                   new DateTime(1998, 03, 25),
                   AccountablePosition.Teamlead);
            }
        }
    }
}
