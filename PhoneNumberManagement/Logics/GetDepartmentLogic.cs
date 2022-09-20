using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class GetDepartmentLogic
    {
        private DepartmentDao DepartmentDao;

        public GetDepartmentLogic()
        {
            this.DepartmentDao = new DepartmentDao();
        }

        public List<DepartmentDto> Logic (SqlConnection connection)
        {
            var dao = DepartmentDao.Dao(connection);
            var result = setDepartmentDto(dao);
            return result;
        }

        public List<DepartmentDto> setDepartmentDto(IEnumerable<DepartmentEntity> entities)
        {
            var dtos = new List<DepartmentDto>();

            foreach(var item in entities)
            {
                var baka = new DepartmentDto();

                baka.DepartmentID = item.DepartmentID;
                baka.DepartmentName = item.DepartmentName;

                dtos.Add(baka);
            }

            return dtos;
        }
    }
}
