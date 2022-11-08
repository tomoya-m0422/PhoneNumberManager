using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IDeletePersonLogic
    {
        void deleteLogic(SqlConnection connection, StaffNumberDto staffNumber);
    }
}
