using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.Search.Interface
{
    public interface ISearchEntityAndDtoDxo
    {
        SearchDto ExchangeEntityToDto(SearchEntity searchEntitys);
        SearchEntity ExchangeDtoToEntity(SearchDto searchDtos);
        List<SearchDto> ListExchangeEntityToDto(List<SearchEntity> searchEntitys);
        List<SearchEntity> ListExchangeDtoToEntity(List<SearchDto> searchDtos);
        IEnumerable<SearchDto> IEnumerableExchangeEntityToDto(IEnumerable<SearchEntity> searchEntitys);
        IEnumerable<SearchEntity> IEnumerableExchangeDtoToEntity(IEnumerable<SearchDto> searchDtos);
    }
}
