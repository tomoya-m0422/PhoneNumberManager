using Dapper;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAO
{
    public class DepartmentDao
    {
        public IEnumerable<DepartmentEntity> Dao (SqlConnection connection)
        {
            var query = "SELECT * FROM Department";
            var result = connection.Query<DepartmentEntity>(query);

            return result;
        }

    }
}
