using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class RedistPersonService : IRedistPersonService
    {

        #region メンバー変数
        private PersonRegistLogic personRegistLogic;
        #endregion

        #region コンストラクター
        public RedistPersonService()
        {
            this.personRegistLogic = new PersonRegistLogic();
        }
        #endregion


        public void registService(PersonDto personDtos)
        {
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    //SQLの実行
                    personRegistLogic.registLogic(connection,personDtos);
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

        }

    }
}
