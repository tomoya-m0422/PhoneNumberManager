using PhoneNumberManagement.Logics;
using PhoneNumberManagement.DTO;
using System.Runtime.CompilerServices;
using PhoneNumberManagement.Models;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using static Dapper.SqlMapper;
using PhoneNumberManagement.DAO;
using System;

namespace PhoneNumberManagement.Services

{
    public class ManagementService : IManagementService
    {
                
        #region メンバー変数
        private ManagementLogic managementLogic;
        #endregion

        #region コンストラクタ
        public ManagementService(ManagementLogic phoneNumberManagementLogic)
        {
            this.managementLogic = phoneNumberManagementLogic;
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
               

            /*
            //DB接続
            var connectionString = "Data Source = NCP - TM04945 - 1; Initial Catalog = ManagementDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
            // データベース接続の準備
            var connection = new SqlConnection(connectionString);
            // データベースの接続開始
            connection.Open();
            */
            return dto;
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