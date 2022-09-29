using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;
using System.Data.SqlClient;
using PhoneNumberManagement.DXO.Management;

namespace PhoneNumberManagement.Logics

{
    public class ManagementLogic : IManagementLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        private ManagementEntityAndDto managementEntityAndDto;
        #endregion 

        #region コンストラクタ
        public ManagementLogic()
        {
            this.managementDao = new ManagementDao();
            this.managementEntityAndDto = new ManagementEntityAndDto();
        }
        #endregion 


        public IEnumerable<ManagementDto> FirstLogic(SqlConnection connection)
        {
            //DaoにSQLServerからデータを取ってくるように指示したあとenetityにデータを入れる
            var entity = managementDao.FirstConnect(connection);
            //var result = setPhoneNumberManagementDto(entity);
            var result = managementEntityAndDto.IEnumerableExchangeEntityToDto(entity);
            return result;
        }
    }
}