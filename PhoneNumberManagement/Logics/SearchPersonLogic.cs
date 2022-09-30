using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.Search;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class SearchPersonLogic
    {
        #region メンバー変数
        private ManagementDao managementDao;
        private SearchEntityAndDto searchEntityAndDto;
        private ManagementEntityAndDto managementEntityAndDto;
        #endregion

        #region コンストラクタ
        public SearchPersonLogic()
        {
            this.managementDao = new ManagementDao();
            this.searchEntityAndDto = new SearchEntityAndDto();
            this.managementEntityAndDto = new ManagementEntityAndDto();
        }
        #endregion

        public IEnumerable<ManagementDto> searchLogic (SqlConnection connection , SearchDto search)
        {
            var entity = searchEntityAndDto.ExchangeDtoToEntity(search);
            var entities = managementDao.searchDao(connection, entity);
            var result = managementEntityAndDto.IEnumerableExchangeEntityToDto(entities);
            return result;
        }

    }
}
