using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXO.Management
{
    /// <summary>
    /// ManagementEntityとManagementDtoの入れ替え処理を行うためのクラス
    /// </summary>
    public class ManagementEntityToDto
    {
        static MapperConfiguration entityToDtoOverrideNull = new MapperConfiguration(cfg =>
        {

        });

        static MapperConfiguration entityToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementEntity, ManagementDto>();
            //.ForMember(d => d.StaffNumber, opt => opt.MapFrom(e => e.StaffNumber))
            //.ForMember(d => d.StaffName, opt => opt.MapFrom(e => e.StaffName))
            //.ForMember(d => d.CompanyID, opt => opt.MapFrom(e => e.CompanyID))
            //.ForMember(d => d.DepartmentID, opt => opt.MapFrom(e => e.DepartmentID))
            //.ForMember(d => d.ExtensionNumber, opt => opt.MapFrom(e => e.ExtensionNumber))
            //.ForMember(d => d.Memo, opt => opt.MapFrom(e => e.Memo))
            //.ForMember(d => d.CompanyName, opt => opt.MapFrom(e => e.CompanyName))
            //.ForMember(d => d.DepartmentName, opt => opt.MapFrom(e => e.DepartmentName));
        });

        static MapperConfiguration dtoToEntityOverrideNull = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementDto, ManagementEntity>();
        });

        static MapperConfiguration dtoToEntityOverride = new MapperConfiguration(cfg =>
        {

        });

        #region List型のEntityとDTOの入れ替え処理
        /// <summary>
        /// EntityデータをDTOに詰め替える(List)
        /// </summary>
        /// <param name="managementEntities">DAOでもらったEntityのことを指している</param>
        /// <param name="overrideNull">true を指定すると NULL 値を上書きします。デフォルトでは false となります。</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<ManagementDto> ListExchangeEntityToDto(List<ManagementEntity> managementEntities, bool overrideNull = false)
        {
            var config = overrideNull ? entityToDtoOverrideNull : entityToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<ManagementEntity>, List<ManagementDto>>(managementEntities);
        }

        /// <summary>
        /// DTOデータをEntityに詰め替える(List)
        /// </summary>
        /// <param name="managementDtos">LogicからもらったDtoのことを指している</param>
        /// <param name="overrideNull">true を指定すると NULL 値を上書きします。デフォルトでは false となります。</param>
        /// <returns>Entity型のデータを返す</returns>
        public List<ManagementEntity> ListExchangeDtoToEntity(List<ManagementDto> managementDtos, bool overrideNull = false)
        {
            var config = overrideNull ? dtoToEntityOverrideNull : dtoToEntityOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<ManagementDto>, List<ManagementEntity>>(managementDtos);
        }
        #endregion

        #region IEnumerable型のEntityとDTOの詰め替え処理
        /// <summary>
        /// EntityデータをDTOに詰め替え
        /// </summary>
        /// <param name="managementEntities">DAOでもらったEntityのことを指している</param>
        /// <param name="overrideNull">true を指定すると NULL 値を上書きします。デフォルトでは false となります。</param>
        /// <returns></returns>
        public IEnumerable<ManagementDto> IEnumerableExchangeEntityToDto(IEnumerable<ManagementEntity> managementEntities, bool overrideNull = false)
        {
            var config = overrideNull? entityToDtoOverrideNull : entityToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ManagementEntity>, IEnumerable<ManagementDto>>(managementEntities);
        }

        /// <summary>
        /// DTOデータをEntityに詰め替える
        /// </summary>
        /// <param name="managementDtos">LogicからもらったDtoのことを指している</param>
        /// <param name="overrideNull">true を指定すると NULL 値を上書きします。デフォルトでは false となります。</param>
        /// <returns></returns>
        public IEnumerable<ManagementEntity> IEnumerableExchangeDtoToEntity(IEnumerable<ManagementDto> managementDtos, bool overrideNull = false)
        {
            var config = overrideNull ? dtoToEntityOverrideNull : dtoToEntityOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ManagementDto>, IEnumerable<ManagementEntity>>(managementDtos);
        }

        #endregion
    }
}
