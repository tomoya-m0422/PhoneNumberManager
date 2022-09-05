using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Logics;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class SearchPersonService
    {
        #region メンバー変数
        private SearchPersonLogic searchPersonLogic;
        #endregion

        #region コンストラクタ
        public SearchPersonService()
        {
            searchPersonLogic = new SearchPersonLogic();
        }
        #endregion

        public IEnumerable<ManagementDto> searchService(SearchDto search)
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
                    dto = searchPersonLogic.searchLogic(connection,search);
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
