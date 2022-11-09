using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAOs.Interface
{
    public interface IDepartmentDao
    {
        List<DepartmentEntity> Dao(SqlConnection connection);
    }
}
