using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class GetDepartmentService
    {
        private GetDepartmentLogic getDepartmentLogic;

        public GetDepartmentService()
        {
            this.getDepartmentLogic = new GetDepartmentLogic();
        }

        public List<DepartmentDto> Service()
        {
            var dto = new List<DepartmentDto>();
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    //SQLの実行
                    dto = (List<DepartmentDto>)getDepartmentLogic.Logic(connection);
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
