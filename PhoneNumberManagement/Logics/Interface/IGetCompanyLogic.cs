using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IGetCompanyLogic
    {
        IEnumerable<CompanyDto> Logic(SqlConnection connection);
    }
}
