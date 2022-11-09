using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Department;
using PhoneNumberManagement.DXOs.Department.Interface;
using PhoneNumberManagement.Logics.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class GetDepartmentLogic : IGetDepartmentLogic
    {
        #region メンバー変数
        private IDepartmentDao departmentDao;
        private IDepartmentEntityAndDtoDxo departmentEntityAndDto;
        #endregion

        #region コンストラクター
        public GetDepartmentLogic(IDepartmentDao departmentDao, IDepartmentEntityAndDtoDxo departmentEntityAndDto)
        {
            this.departmentDao = departmentDao;
            this.departmentEntityAndDto = departmentEntityAndDto;
        }
        #endregion

        public List<DepartmentDto> Logic (SqlConnection connection)
        {
            var dao = departmentDao.Dao(connection);
            var result = departmentEntityAndDto.ListExchangeDtoToEntity(dao);
            return result;
        }
    }
}
