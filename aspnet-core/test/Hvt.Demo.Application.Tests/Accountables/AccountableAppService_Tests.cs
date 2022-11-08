using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Hvt.Demo.Permissions.DemoPermissions;

namespace Hvt.Demo.Accountables
{
    public class AccountableAppService_Tests: DemoApplicationTestBase
    {
        private readonly IAccountableAppService _accountableAppService;
        public AccountableAppService_Tests()
        {
            _accountableAppService = GetRequiredService<IAccountableAppService>();

        }
        [Fact]
        public async Task Should_Get_All_Accountables_Without_Any_Filter()
        {
            var result = await _accountableAppService.GetListAsync(new GetAccountableListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(3);
            result.Items.ShouldContain(a => a.Name == "Heverton Torres");
            result.Items.ShouldContain(a => a.Name == "Keiti Queiroz");
        }

        [Fact]
        public async Task Should_Get_Filtered_Accountables()
        {
            var result = await _accountableAppService.GetListAsync(
                new GetAccountableListDto { Filter = "Heverton" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(accountable => accountable.Name == "Heverton Torres");
            result.Items.ShouldNotContain(accountable => accountable.Name == "Keiti Queiroz");
        }

        [Fact]
        public async Task Should_Create_A_New_Accountable()
        {
            var accountableDto = await _accountableAppService.CreateAsync(
                new CreateAccountableDto
                {
                    Name = "Viviane Siqueira",
                    BirthDate = new DateTime(1990, 05, 22),
                    Position = AccountablePosition.Undefined
                }
            );

            accountableDto.Id.ShouldNotBe(Guid.Empty);
            accountableDto.Name.ShouldBe("Viviane Siqueira");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Author()
        {
            await Assert.ThrowsAsync<AccountableAlreadyExistsException>(async () =>
            {
                await _accountableAppService.CreateAsync(
                    new CreateAccountableDto
                    {
                        Name = "Leonardo Torres",
                        BirthDate = DateTime.Now,
                        Position = AccountablePosition.TeamMember
                    }
                );
            });
        }
    }
}
