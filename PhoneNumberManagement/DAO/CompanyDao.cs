using Dapper;
using Microsoft.AspNetCore.Identity;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAO
{
    public class CompanyDao
    {
        public IEnumerable<CompanyEntity> Dao(SqlConnection connection)
        {
            var query = "SELECT * FROM Company";

            var result = connection.Query<CompanyEntity>(query);

            return  result;
        }
    }
}
