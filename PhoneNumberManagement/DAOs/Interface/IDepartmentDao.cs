using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAOs.Interface
{
    public interface IDepartmentDao
    {
        IEnumerable<DepartmentEntity> Dao(SqlConnection connection);
    }
}
