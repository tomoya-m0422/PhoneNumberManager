using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXO.Management
{
    /// <summary>
    /// ManagementEntityとManagementDtoの入れ替え処理を行うためのクラス
    /// </summary>
    public class ManagementEntityAndDtoDxo : IManagementEntityAndDtoDxo
    {

        static MapperConfiguration entityToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementEntity, ManagementDto>();
        });

        static MapperConfiguration dtoToEntityOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementDto, ManagementEntity>();
        });

        #region List,IEnumerable型以外のEntityとDTOの入れ替え処理
        /// <summary>
        /// EntityデータをDTOに詰め替える(List)
        /// </summary>
        /// <param name="managementEntities">DAOでもらったEntityのことを指している</param>
        /// <returns>DTO型のデータを返す</returns>
        public ManagementDto ExchangeEntityToDto(ManagementEntity managementEntities)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<ManagementEntity, ManagementDto>(managementEntities);
        }

        /// <summary>
        /// DTOデータをEntityに詰め替える(List)
        /// </summary>
        /// <param name="managementDtos">LogicからもらったDtoのことを指している</param>
        /// <param name="overrideNull">true を指定すると NULL 値を上書きします。デフォルトでは false となります。</param>
        /// <returns>Entity型のデータを返す</returns>
        public ManagementEntity ExchangeDtoToEntity(ManagementDto managementDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<ManagementDto, ManagementEntity>(managementDtos);
        }
        #endregion

        #region List型のEntityとDTOの入れ替え処理
        /// <summary>
        /// EntityデータをDTOに詰め替える(List)
        /// </summary>
        /// <param name="managementEntities">DAOでもらったEntityのことを指している</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<ManagementDto> ListExchangeEntityToDto(List<ManagementEntity> managementEntities)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<List<ManagementEntity>, List<ManagementDto>>(managementEntities);
        }

        /// <summary>
        /// DTOデータをEntityに詰め替える(List)
        /// </summary>
        /// <param name="managementDtos">LogicからもらったDtoのことを指している</param>
        /// <param name="overrideNull">true を指定すると NULL 値を上書きします。デフォルトでは false となります。</param>
        /// <returns>Entity型のデータを返す</returns>
        public List<ManagementEntity> ListExchangeDtoToEntity(List<ManagementDto> managementDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<List<ManagementDto>, List<ManagementEntity>>(managementDtos);
        }
        #endregion

        #region IEnumerable型のEntityとDTOの詰め替え処理
        /// <summary>
        /// EntityデータをDTOに詰め替え
        /// </summary>
        /// <param name="managementEntities">DAOでもらったEntityのことを指している</param>
        /// <returns></returns>
        public IEnumerable<ManagementDto> IEnumerableExchangeEntityToDto(IEnumerable<ManagementEntity> managementEntities)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<ManagementEntity>, IEnumerable<ManagementDto>>(managementEntities);
        }

        /// <summary>
        /// DTOデータをEntityに詰め替える
        /// </summary>
        /// <param name="managementDtos">LogicからもらったDtoのことを指している</param>
        /// <returns></returns>
        public IEnumerable<ManagementEntity> IEnumerableExchangeDtoToEntity(IEnumerable<ManagementDto> managementDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<IEnumerable<ManagementDto>, IEnumerable<ManagementEntity>>(managementDtos);
        }

        #endregion
    }
}
