using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Person.Interface
{
    public interface IPersonDtoAndViewmodelDxo
    {
        PersonViewModel ExchangeDtoToViewmodel(PersonDto personDtos);
        PersonDto ExchangeViewmodelToDto(PersonViewModel personViewModels);
        List<PersonViewModel> ListExchangeDtoToViewmodel(List<PersonDto> personDtos);
        List<PersonDto> ListExchangeViewmodelToDto(List<PersonViewModel> personViewModels);
        IEnumerable<PersonViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<PersonDto> personDtos);
        IEnumerable<PersonDto> IEnumerableExchangeViewmodelToDto(IEnumerable<PersonViewModel> personViewModels);
    }
}
