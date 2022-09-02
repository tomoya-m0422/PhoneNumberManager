using PhoneNumberManagement.Logics;
using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services

{
    public class ManagementService : IManagementService
    {
         #region メンバー変数
        private ManagementLogic managementLogic;
        #endregion

        #region コンストラクタ
        public ManagementService()
        {
            this.managementLogic = new ManagementLogic();
        }
        #endregion


        public List<ManagementDto> FirstService()
        {
            var dto = new List<ManagementDto>();
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    //SQLの実行
                    dto = managementLogic.FirstLogic(connection);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
             return dto; 
        }
    }
}