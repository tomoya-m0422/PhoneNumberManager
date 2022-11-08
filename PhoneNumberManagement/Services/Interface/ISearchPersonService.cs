using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;

namespace PhoneNumberManagement.Services.Interface
{
    public interface ISearchPersonService
    {
        IEnumerable<ManagementDto> searchService(SearchDto search);
    }
}
