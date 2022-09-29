using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.Department
{
    public class DepartmentEntityAndDto
    {
        static MapperConfiguration EntityToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DepartmentEntity, DepartmentDto>();
        });

        static MapperConfiguration DtoToEntityOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DepartmentDto, DepartmentEntity>();
        });

        #region List型のEntityとDtoの入れ替え処理
        /// <summary>
        /// EntityデータをDtoに入れ替える 
        /// </summary>
        /// <param name="departmentEntities">Daoから渡されたEntityデータ</param>
        /// <returns>Dto型のデータを返す</returns>
        public List<DepartmentDto> ListExchangeDtoToEntity(List<DepartmentEntity> departmentEntities)
        {
            var config = DtoToEntityOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<DepartmentEntity>, List<DepartmentDto>>(departmentEntities);
        }

        /// <summary>
        /// DTOにEntity型に入れ替える
        /// </summary>
        /// <param name="departmentDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>Entity型のデータを返す</returns>
        public List<DepartmentEntity> ListExchangeEntityToDto(List<DepartmentDto> departmentDtos)
        {
            var config = EntityToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<DepartmentDto>, List<DepartmentEntity>>(departmentDtos);
        }
        #endregion

        #region IEnumerable型のDTOとViewModelの入れ替え作業
        /// <summary>
        /// EntityデータをDtoに入れ替える 
        /// </summary>
        /// <param name="departmentEntities">Daoから渡されたEntityデータ</param>
        /// <returns>Dto型のデータを返す</returns>
        public IEnumerable<DepartmentDto> IEnumerableExchangeEntityToDto(IEnumerable<DepartmentEntity> departmentEntities)
        {
            var config = EntityToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<DepartmentEntity>, IEnumerable<DepartmentDto>>(departmentEntities);
        }

        /// <summary>
        /// DTOにEntity型に入れ替える
        /// </summary>
        /// <param name="departmentDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>Entity型のデータを返す</returns>
        public IEnumerable<DepartmentEntity> IEnumerableExchangeDtoToEntity(IEnumerable<DepartmentDto> departmentDtos)
        {
            var config = DtoToEntityOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<DepartmentDto>, IEnumerable<DepartmentEntity>>(departmentDtos);
        }
        #endregion
    }
}
