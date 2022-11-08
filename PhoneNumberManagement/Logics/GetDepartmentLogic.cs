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
        private IDepartmentDao DepartmentDao;
        private IDepartmentEntityAndDtoDxo departmentEntityAndDto;
        #endregion

        #region コンストラクター
        public GetDepartmentLogic(IDepartmentDao DepartmentDao, IDepartmentEntityAndDtoDxo departmentEntityAndDto)
        {
            DepartmentDao = this.DepartmentDao;
            departmentEntityAndDto = this.departmentEntityAndDto;
        }
        #endregion

        public IEnumerable<DepartmentDto> Logic (SqlConnection connection)
        {
            var dao = DepartmentDao.Dao(connection);
            var result = departmentEntityAndDto.IEnumerableExchangeEntityToDto(dao);
            return result;
        }
    }
}
