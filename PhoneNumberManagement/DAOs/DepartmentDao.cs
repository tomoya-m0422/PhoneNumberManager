using Dapper;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAO
{
    public class DepartmentDao : IDepartmentDao
    {
        public IEnumerable<DepartmentEntity> Dao (SqlConnection connection)
        {
            var query = "SELECT * FROM Department";
            var result = connection.Query<DepartmentEntity>(query);

            return result;
        }

    }
}
