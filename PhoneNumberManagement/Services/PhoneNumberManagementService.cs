using PhoneNumberManagement.Logics;
using PhoneNumberManagement.DTO;
using System.Runtime.CompilerServices;
using PhoneNumberManagement.Models;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using static Dapper.SqlMapper;

namespace PhoneNumberManagement.Services

{
    public class PhoneNumberManagementService
    {
        
        
        #region メンバー変数
        private PhoneNumberManagementLogic managementLogic;
        #endregion



        #region コンストラクタ
        public PhoneNumberManagementService(PhoneNumberManagementLogic phoneNumberManagementLogic)
        {
            this.managementLogic = phoneNumberManagementLogic;
        }
         #endregion



        public IEnumerable<PhoneNumberManagementViewModel> FirstUpService()
        {
            // 接続文字列の取得
            var connectionString = "Data Source = NCP - TM04945 - 1; Initial Catalog = ManagementDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            // データベース接続の準備
            var connection = new SqlConnection(connectionString);
            // データベースの接続開始
            connection.Open();//Serviceで書く
            /*
            var PhoneNumberManagementDto = new PhoneNumberManagementLogic();
            var result = (PhoneNumberManagementDto)PhoneNumberManagementDto.FirstLogic();
            */
            var result = managementLogic.FirstUpLogic();
            return result;
        }


        public IEnumerable<PhoneNumberManagementDto> FirstDawnService()
        {
            var Dto = managementLogic.FirstDawnLogic();


            return Dto;
        }


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