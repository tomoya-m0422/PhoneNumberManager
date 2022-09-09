using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class DetailPersonLogic
    {
        #region メンバー変数
        private ManagementDao managementDao;
        #endregion

        #region コンストラクタ
        public DetailPersonLogic()
        {
            this.managementDao = new ManagementDao();
        }
        #endregion

        public ManagementDto detailLogic(SqlConnection connection,DetailDto staffNumber)
        {
            var upEntity = setEntityDetailLogic(staffNumber);
            var downEntity = managementDao.detailDao(connection,upEntity);
            var result = setDtoDetailLogic(downEntity);
            return result;
        }

        public DetailPersonEntity setEntityDetailLogic(DetailDto number)
        {
            var entity = new DetailPersonEntity();
            entity.StaffNumber = number.StaffNumber;
            return entity;
        }

        public ManagementDto setDtoDetailLogic(ManagementEntity entity)
        {
            var result = new ManagementDto();
            result.StaffNumber = entity.StaffNumber;
            result.StaffName = entity.StaffName;
            result.CompanyID = entity.CompanyID;
            result.CompanyName = entity.CompanyName;
            result.DepartmentID = entity.DepartmentID;
            result.DepartmentName = entity.DepartmentName;
            result.Memo = entity.Memo;
            result.ExtensionNumber = entity.ExtensionNumber;

            return result;
        }
    }
}
