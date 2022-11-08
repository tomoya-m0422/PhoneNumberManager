using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IGetDepartmentLogic
    {
        IEnumerable<DepartmentDto> Logic(SqlConnection connection);
    }
}
