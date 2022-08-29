using System.Data.SqlClient;
using Dapper;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DAO
{


    public class ManagementDao : IManagementDao
    {
        public IEnumerable<ManagementEntity> FirstConnect(SqlConnection connection)
        {

            /*  実行するSQLの準備
            var command = new SqlCommand();
            command.Connection = connection;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Person,Company,Department";
            */

            var query = "SELECT StaffNumber,StaffName,CompanyName,DepartmentName,ExtensionNumber,Memo FROM Person AS p,Company AS c,Department AS d WHERE p.CompanyID = c.CompanyID AND p.DepartmentID = d.DepartmentID";
            var result = connection.Query<ManagementEntity>(query);


            //確認用
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // SQLの実行
            //command.ExecuteNonQuery();


            // データベースの接続終了


            return result;
        }
    }
}
