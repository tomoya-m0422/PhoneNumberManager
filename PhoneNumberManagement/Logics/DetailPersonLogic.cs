using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.StaffNumber;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class DetailPersonLogic
    {
        #region メンバー変数
        private ManagementDao managementDao;
        private ManagementEntityAndDto managementEntityAndDto;
        private StaffNumberEntityAndDto staffNumberEntityAndDto;
        #endregion

        #region コンストラクタ
        public DetailPersonLogic()
        {
            this.managementDao = new ManagementDao();
            this.managementEntityAndDto = new ManagementEntityAndDto();
            this.staffNumberEntityAndDto = new StaffNumberEntityAndDto();
        }

        #endregion

        public ManagementDto detailLogic(SqlConnection connection,StaffNumberDto staffNumber)
        {
            var upEntity = staffNumberEntityAndDto.ExchangeDtoToEntity(staffNumber);
            var downEntity = managementDao.detailDao(connection,upEntity);
            var result = managementEntityAndDto.ExchangeEntityToDto(downEntity);
            return result;
        }
    }
}
