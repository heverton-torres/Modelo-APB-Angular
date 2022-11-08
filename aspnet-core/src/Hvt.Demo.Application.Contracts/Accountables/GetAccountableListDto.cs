using Volo.Abp.Application.Dtos;

namespace Hvt.Demo.Accountables
{
    public class GetAccountableListDto:PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}