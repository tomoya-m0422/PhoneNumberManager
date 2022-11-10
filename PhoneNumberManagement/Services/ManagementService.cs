using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services

{
    public class ManagementService : IManagementService
    {

        #region メンバー変数
        private IManagementLogic managementLogic;
        #endregion

        #region コンストラクタ
        public ManagementService(IManagementLogic managementLogic)
        {
            //this.managementLogic = new ManagementLogic(new ManagementDao(),new ManagementEntityAndDtoDxo());
            this.managementLogic = managementLogic;
        }
        #endregion


        public IEnumerable<ManagementDto> FirstService()
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
                    //SQLの実行(接続するための情報をLogicに渡す)
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