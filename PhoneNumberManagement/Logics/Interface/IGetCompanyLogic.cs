using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IGetCompanyLogic
    {
        List<CompanyDto> Logic(SqlConnection connection);
    }
}
