using System;
using System.Configuration;
using System.Data.SqlClient;


namespace PhoneNumberManagement.DAO
{


    public class ManagementDao
    {
        public void Connect1()
        {
            // 接続文字列の取得
            var connectionString = "Data Source = NCP - TM04945 - 1; Initial Catalog = ManagementDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

            // データベース接続の準備
            var connection = new SqlConnection(connectionString);

            // データベースの接続開始
            connection.Open();

            /*// 実行するSQLの準備
            var command = new SqlCommand();
            command.Connection = connection;

            */

            SqlCommand command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Person";

            // SQLの実行
            command.ExecuteNonQuery();

            // データベースの接続終了
            connection.Close();
        }
    }
}
