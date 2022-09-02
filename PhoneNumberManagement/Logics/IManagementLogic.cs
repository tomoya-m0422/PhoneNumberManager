using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public interface IManagementLogic
    {
        List<ManagementDto> FirstLogic(SqlConnection connection);
        List<ManagementDto> setPhoneNumberManagementDto(IEnumerable<ManagementEntity> entities);
    }
}
