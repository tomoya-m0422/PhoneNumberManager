using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class DetailPersonService
    {
        #region　メンバー変数
        private DetailPersonLogic detailPersonLogic;
        #endregion

        #region コンストラクタ
        public DetailPersonService()
        {
            this.detailPersonLogic = new DetailPersonLogic();
        }
        #endregion

        public ManagementDto detailService(DetailDto staffNumber)
        {
            var dto = new ManagementDto();
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    //SQLの実行
                    dto =detailPersonLogic.detailLogic(connection, staffNumber);

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
