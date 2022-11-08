using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAOs.Interface
{
    public interface ICompanyDao
    {
        IEnumerable<CompanyEntity> Dao(SqlConnection connection);
    }
}
