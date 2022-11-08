using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;
using System.Data.SqlClient;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DXOs.Management.Interface;

namespace PhoneNumberManagement.Logics

{
    public class ManagementLogic : IManagementLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        private IManagementEntityAndDtoDxo managementEntityAndDto;
        #endregion 

        #region コンストラクタ
        public ManagementLogic(IManagementDao managementDao, IManagementEntityAndDtoDxo managementEntityAndDto)
        {
            this.managementDao = new ManagementDao();
            this.managementEntityAndDto = new ManagementEntityAndDtoDxo();
        }
        #endregion 


        public List<ManagementDto> FirstLogic(SqlConnection connection)
        {
            //DaoにSQLServerからデータを取ってくるように指示したあとenetityにデータを入れる
            var entity = managementDao.FirstConnect(connection);
            //var result = setPhoneNumberManagementDto(entity);
            var result = managementEntityAndDto.IEnumerableExchangeEntityToDto(entity);
            return (List<ManagementDto>)result;
        }
    }
}