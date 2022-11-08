using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Search.Interface
{
    public interface ISearchDtoAndViewmodelDxo
    {
        SearchViewModel ExchangeDtoToViewmodel(SearchDto searchDtos);
        SearchDto ExchangeViewmodelToDto(SearchViewModel searchViewModels);
        List<SearchViewModel> ListExchangeDtoToViewmodel(List<SearchDto> searchDtos);
        List<SearchDto> ListExchangeViewmodelToDto(List<SearchViewModel> searchViewModels);
        IEnumerable<SearchViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<SearchDto> searchDtos);
        IEnumerable<SearchDto> IEnumerableExchangeViewmodelToDto(IEnumerable<SearchViewModel> searchViewModels);
    }
}
