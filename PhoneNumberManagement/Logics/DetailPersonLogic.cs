using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.DXOs.StaffNumber;
using PhoneNumberManagement.DXOs.StaffNumber.Interface;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Logics.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class DetailPersonLogic : IDetailPersonLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        private IManagementEntityAndDtoDxo managementEntityAndDto;
        private IStaffNumberEntityAndDtoDxo staffNumberEntityAndDto;
        #endregion

        #region コンストラクタ
        public DetailPersonLogic(IManagementDao managementDao, IManagementEntityAndDtoDxo managementEntityAndDto, IStaffNumberEntityAndDtoDxo staffNumberEntityAndDto)
        {
            managementDao = this.managementDao;
            managementEntityAndDto = this.managementEntityAndDto;
            staffNumberEntityAndDto = this.staffNumberEntityAndDto;
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
