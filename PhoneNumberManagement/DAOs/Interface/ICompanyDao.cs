using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAOs.Interface
{
    public interface ICompanyDao
    {
        List<CompanyEntity> Dao(SqlConnection connection);
    }
}
