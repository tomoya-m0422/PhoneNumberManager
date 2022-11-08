using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Company;
using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class GetCompanyService : IGetCompanyService
    {

        #region メンバー変数
        private IGetCompanyLogic getCompanyLogic;
        #endregion

        #region コンストラクタ
        public GetCompanyService( IGetCompanyLogic getCompanyLogic)
        {
            this.getCompanyLogic = new GetCompanyLogic(new CompanyDao(),new CompanyEntityAndDtoDxo());
        }
        #endregion


        public IEnumerable<CompanyDto> Service()
        {
            var dto = new List<CompanyDto>();
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    //SQLの実行
                    dto = (List<CompanyDto>)getCompanyLogic.Logic(connection);
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
