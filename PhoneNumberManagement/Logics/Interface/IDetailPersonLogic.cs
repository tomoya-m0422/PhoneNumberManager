using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IDetailPersonLogic
    {
        ManagementDto detailLogic(SqlConnection connection, StaffNumberDto staffNumber);
    }
}
