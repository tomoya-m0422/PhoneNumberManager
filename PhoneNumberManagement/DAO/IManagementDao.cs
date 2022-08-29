using System.Data.SqlClient;
using Dapper;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DAO
{


    public interface IManagementDao
    {
        IEnumerable<ManagementEntity> FirstConnect(SqlConnection connection);
        
    }
}
