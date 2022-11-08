using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Person.Interface;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Person
{
    public class PersonEntityAndDtoDxo :IPersonEntityAndDtoDxo
    {
        static MapperConfiguration EntityToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PersonEntity, PersonDto>();
        });

        static MapperConfiguration DtoToEntityOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PersonDto, PersonEntity>();
        });

        #region List,IEnumerable型以外のDTOとEntityの入れ替え処理
        /// <summary>
        /// EntityデータをDTOに置き換えます
        /// </summary>
        /// <param name="personEntities">Daoから受け取ったEntity</param>
        /// <returns>DTOデータ</returns>
        public PersonDto ExchangeEntityToDto(PersonEntity personEntities)
        {
            var mapper = EntityToDtoOverride.CreateMapper();
            return mapper.Map<PersonEntity, PersonDto>(personEntities);
        }

        /// <summary>
        /// DTOデータをEntityに置き換えます
        /// </summary>
        /// <param name="personDto">Serviceから受け取ったDto</param>
        /// <returns>Entityデータ</returns>
        public PersonEntity ExchangeDtoToEntity(PersonDto personDtos)
        {
            var mapper = DtoToEntityOverride.CreateMapper();
            return mapper.Map<PersonDto, PersonEntity>(personDtos);
        }
        #endregion

        #region List型のEntityとDtoの入れ替え処理
        /// <summary>
        /// EntityデータをDtoに入れ替える 
        /// </summary>
        /// <param name="personEntities">Daoから渡されたEntityデータ</param>
        /// <returns>Dto型のデータを返す</returns>
        public List<PersonDto> ListExchangeDtoToEntity(List<PersonEntity> personEntities)
        {
            var mapper = DtoToEntityOverride.CreateMapper();
            return mapper.Map<List<PersonEntity>, List<PersonDto>>(personEntities);
        }

        /// <summary>
        /// DTOにEntity型に入れ替える
        /// </summary>
        /// <param name="personDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>Entity型のデータを返す</returns>
        public List<PersonEntity> ListExchangeEntityToDto(List<PersonDto> personDtos)
        {
            var mapper = EntityToDtoOverride.CreateMapper();
            return mapper.Map<List<PersonDto>, List<PersonEntity>>(personDtos);
        }
        #endregion

        #region IEnumerable型のDTOとViewModelの入れ替え作業
        /// <summary>
        /// EntityデータをDtoに入れ替える 
        /// </summary>
        /// <param name="personEntities">Daoから渡されたEntityデータ</param>
        /// <returns>Dto型のデータを返す</returns>
        public IEnumerable<PersonDto> IEnumerableExchangeEntityToDto(IEnumerable<PersonEntity> personEntities)
        {
            var mapper = EntityToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<PersonEntity>, IEnumerable<PersonDto>>(personEntities);
        }

        /// <summary>
        /// DTOにEntity型に入れ替える
        /// </summary>
        /// <param name="personDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>Entity型のデータを返す</returns>
        public IEnumerable<PersonEntity> IEnumerableExchangeDtoToEntity(IEnumerable<PersonDto> personDtos)
        {
            var mapper = DtoToEntityOverride.CreateMapper();
            return mapper.Map<IEnumerable<PersonDto>, IEnumerable<PersonEntity>>(personDtos);
        }
        #endregion
    }
}
