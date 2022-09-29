using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.Company
{
    public class CompanyEntityAndDto
    {
        static MapperConfiguration EntityToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CompanyEntity, CompanyDto>();
        });

        static MapperConfiguration DtoToEntityOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CompanyDto, CompanyEntity>();
        });

        #region List型のEntityとDtoの入れ替え処理
        /// <summary>
        /// EntityデータをDtoに入れ替える 
        /// </summary>
        /// <param name="companyEntities">Daoから渡されたEntityデータ</param>
        /// <returns>Dto型のデータを返す</returns>
        public List<CompanyDto> ListExchangeDtoToEntity(List<CompanyEntity> companyEntities)
        {
            var config = EntityToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<CompanyEntity>, List<CompanyDto>>(companyEntities);
        }

        /// <summary>
        /// DTOにEntity型に入れ替える
        /// </summary>
        /// <param name="companyDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>Entity型のデータを返す</returns>
        public List<CompanyEntity> ListExchangeEntityToDto(List<CompanyDto> companyDtos)
        {
            var config = DtoToEntityOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<CompanyDto>, List<CompanyEntity>>(companyDtos);
        }
        #endregion

        #region IEnumerable型のEntityとDtoの入れ替え作業
        /// <summary>
        /// EntityデータをDtoに入れ替える 
        /// </summary>
        /// <param name="companyEntities">Daoから渡されたEntityデータ</param>
        /// <returns>Dto型のデータを返す</returns>
        public IEnumerable<CompanyDto> IEnumerableExchangeEntityToDto(IEnumerable<CompanyEntity> companyEntities)
        {
            var config = EntityToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<CompanyEntity>, IEnumerable<CompanyDto>>(companyEntities);
        }

        /// <summary>
        /// DTOにEntity型に入れ替える
        /// </summary>
        /// <param name="companyDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>Entity型のデータを返す</returns>
        public IEnumerable<CompanyEntity> IEnumerableExchangeDtoToEntity(IEnumerable<CompanyDto> companyDtos)
        {
            var config = DtoToEntityOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<CompanyDto>, IEnumerable<CompanyEntity>>(companyDtos);
        }
        #endregion
    }
}
