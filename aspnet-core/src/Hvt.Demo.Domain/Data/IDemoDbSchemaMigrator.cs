using System.Threading.Tasks;

namespace Hvt.Demo.Data;

public interface IDemoDbSchemaMigrator
{
    Task MigrateAsync();
}
