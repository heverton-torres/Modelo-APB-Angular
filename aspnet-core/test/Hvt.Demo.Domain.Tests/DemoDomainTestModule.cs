using Hvt.Demo.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Hvt.Demo;

[DependsOn(
    typeof(DemoEntityFrameworkCoreTestModule)
    )]
public class DemoDomainTestModule : AbpModule
{

}
