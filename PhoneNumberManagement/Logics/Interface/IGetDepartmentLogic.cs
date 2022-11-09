using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IGetDepartmentLogic
    {
        List<DepartmentDto> Logic(SqlConnection connection);
    }
}
