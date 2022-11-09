using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Logics;
using System.Data.SqlClient;
using PhoneNumberManagement.Services.Interface;
using PhoneNumberManagement.Logics.Interface;

namespace PhoneNumberManagement.Services
{
    public class SearchPersonService :ISearchPersonService
    {
        #region メンバー変数
        private ISearchPersonLogic searchPersonLogic;
        #endregion

        #region コンストラクタ
        public SearchPersonService(ISearchPersonLogic searchPersonLogic)
        {
            this.searchPersonLogic = searchPersonLogic;
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
                    dto = (List<ManagementDto>)searchPersonLogic.searchLogic(connection,search);
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
