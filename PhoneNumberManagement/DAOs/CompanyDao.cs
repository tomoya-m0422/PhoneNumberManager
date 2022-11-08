using Dapper;
using Microsoft.AspNetCore.Identity;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAO
{
    public class CompanyDao : ICompanyDao
    {
        public IEnumerable<CompanyEntity> Dao(SqlConnection connection)
        {
            var query = "SELECT * FROM Company";

            var result = connection.Query<CompanyEntity>(query);

            return  result;
        }
    }
}
