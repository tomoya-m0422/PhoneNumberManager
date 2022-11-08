using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class EditPersonService : IEditPersonService
    {
        #region メンバー変数
        private IEditPersonLogic editPersonLogic;
        #endregion

        #region コンストラクタ
        public EditPersonService(IEditPersonLogic editPersonLogic)
        {
            editPersonLogic =  this.editPersonLogic;
        }
        #endregion

        public void editService(PersonDto dto)
        {
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    
                    editPersonLogic.editLogic(connection,dto);
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
