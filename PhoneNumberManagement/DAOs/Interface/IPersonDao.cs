using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAOs.Interface
{
    public interface IPersonDao
    {
        void registDao(SqlConnection connection, PersonEntity personEntities);
        void deleteDao(SqlConnection connection, StaffNumberEntity staffNumber);
        void editDao(SqlConnection connection, PersonEntity personEntities);

    }
}
