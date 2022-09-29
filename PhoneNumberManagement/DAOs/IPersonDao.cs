using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAO
{
    public interface IPersonDao
    {
        public void registDao(SqlConnection connection, PersonEntity personEntities);

    }
}
