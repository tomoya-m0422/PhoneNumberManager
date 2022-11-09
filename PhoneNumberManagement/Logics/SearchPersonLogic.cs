using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.DXOs.Search;
using PhoneNumberManagement.DXOs.Search.Interface;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Models;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class SearchPersonLogic : ISearchPersonLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        private ISearchEntityAndDtoDxo searchEntityAndDto;
        private IManagementEntityAndDtoDxo managementEntityAndDto;
        #endregion

        #region コンストラクタ
        public SearchPersonLogic(IManagementDao managementDao, ISearchEntityAndDtoDxo searchEntityAndDto, IManagementEntityAndDtoDxo managementEntityAndDto)
        {
            this.managementDao = managementDao;
            this.searchEntityAndDto = searchEntityAndDto;
            this.managementEntityAndDto = managementEntityAndDto;
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
