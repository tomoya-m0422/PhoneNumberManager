using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Department;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class GetDepartmentLogic
    {
        private DepartmentDao DepartmentDao;
        private DepartmentEntityAndDto departmentEntityAndDto;

        public GetDepartmentLogic()
        {
            this.DepartmentDao = new DepartmentDao();
            this.departmentEntityAndDto = new DepartmentEntityAndDto();
        }

        public IEnumerable<DepartmentDto> Logic (SqlConnection connection)
        {
            var dao = DepartmentDao.Dao(connection);
            var result = departmentEntityAndDto.IEnumerableExchangeEntityToDto(dao);
            return result;
        }
    }
}
