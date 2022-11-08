using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.Person.Interface
{
    public interface IPersonEntityAndDtoDxo
    {
        PersonDto ExchangeEntityToDto(PersonEntity personEntities);
        PersonEntity ExchangeDtoToEntity(PersonDto personDto);
        List<PersonDto> ListExchangeDtoToEntity(List<PersonEntity> personEntities);
        List<PersonEntity> ListExchangeEntityToDto(List<PersonDto> personDtos);
        IEnumerable<PersonDto> IEnumerableExchangeEntityToDto(IEnumerable<PersonEntity> personEntities);
        IEnumerable<PersonEntity> IEnumerableExchangeDtoToEntity(IEnumerable<PersonDto> personDtos);

    }
}
