using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface ISearchPersonLogic
    {
        IEnumerable<ManagementDto> searchLogic(SqlConnection connection, SearchDto search);
    }
}
