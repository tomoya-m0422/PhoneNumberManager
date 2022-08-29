using System.Data.SqlClient;
using Dapper;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DAO
{


    public class ManagementDao : IManagementDao
    {
        public IEnumerable<PhoneNumberManagementEntity> FirstConnect()
        {
            /*
            // 接続文字列の取得
            var connectionString = "Data Source = NCP - TM04945 - 1; Initial Catalog = ManagementDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            // データベース接続の準備
            var connection = new SqlConnection(connectionString);
            // データベースの接続開始
            connection.Open();//Serviceで書く
            */

            /* // 実行するSQLの準備
            var command = new SqlCommand();
            command.Connection = connection;

            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Person,Company,Department";
            */

            var query = "SELECT StaffNumber,StaffName,CompanyName,DepartmentName,ExtensionNumber,Memo FROM Person AS p,Company AS c,Department AS d WHERE p.CompanyID = c.CompanyID AND p.DepartmentID = d.DepartmentID";
            var result = connection.Query<PhoneNumberManagementEntity>(query);


            //確認用
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

            // SQLの実行
            //command.ExecuteNonQuery();


            // データベースの接続終了
            connection.Close();

            return result;
        }
    }
}
