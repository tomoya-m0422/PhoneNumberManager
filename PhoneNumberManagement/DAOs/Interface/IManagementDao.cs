using System.Data.SqlClient;
using Dapper;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DAOs.Interface
{


    public interface IManagementDao
    {
        IEnumerable<ManagementEntity> FirstConnect(SqlConnection connection);
        IEnumerable<ManagementEntity> searchDao(SqlConnection connection, SearchEntity search);
        ManagementEntity detailDao(SqlConnection connection, StaffNumberEntity upEntity);

    }
}
