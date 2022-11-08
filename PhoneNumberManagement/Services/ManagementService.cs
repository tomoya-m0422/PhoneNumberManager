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

        #region テスト用
        /*
        #region メンバー変数
        private ManagementLogic managementLogic;
        #endregion

        #region コンストラクタ
        public ManagementService()
        {
            this.managementLogic =new  ManagementLogic();
        }
        #endregion


        public string FirstService()
        {
            string testService = "Serviceには通ったよ";
            /*
            //DB接続
            var connectionString = "Data Source = NCP - TM04945 - 1; Initial Catalog = ManagementDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            // データベース接続の準備
            var connection = new SqlConnection(connectionString);
            // データベースの接続開始
            connection.Open();
            
            //return testService;
        }
        */


        #endregion
        #region 本番用

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

            //DB接続
            //var connectionString = "Data Source = NCP - TM04945 - 1; Initial Catalog = ManagementDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            // データベース接続の準備
            //var connection = new SqlConnection(connectionString);
            // データベースの接続開始
            //connection.Open();
            

        }
    
        #endregion


    }
}

/* Service
public PhoneNumberManagementDto StoreService()
{
    //DB接続ぞく
    var phoneNumberManagementDto = MainLogic.Store();

    return phoneNumberManagementDto;
}
*/