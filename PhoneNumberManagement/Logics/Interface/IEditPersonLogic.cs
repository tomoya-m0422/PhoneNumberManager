using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IEditPersonLogic
    {
        void editLogic(SqlConnection connection, PersonDto dto);
    }
}
