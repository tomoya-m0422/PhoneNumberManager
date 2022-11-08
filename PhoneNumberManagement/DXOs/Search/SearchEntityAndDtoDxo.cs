using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Search.Interface;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.Search
{
    public class SearchEntityAndDtoDxo: ISearchEntityAndDtoDxo
    {
        static MapperConfiguration entityToDtoOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<SearchEntity, SearchDto>();
        });

        static MapperConfiguration dtoToEntityOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<SearchDto, SearchEntity>();
        });

        #region List,IEnumerable以外のEntityとDtoの詰め替え処理
        public SearchDto ExchangeEntityToDto(SearchEntity searchEntitys)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<SearchEntity,SearchDto>(searchEntitys);
        }

        public SearchEntity ExchangeDtoToEntity(SearchDto searchDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<SearchDto, SearchEntity>(searchDtos);
        }
        #endregion

        #region List型のEntityとDtoの詰め替え処理
        public List<SearchDto> ListExchangeEntityToDto(List<SearchEntity> searchEntitys)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<List<SearchEntity>, List<SearchDto>>(searchEntitys);
        }

        public List<SearchEntity> ListExchangeDtoToEntity(List<SearchDto> searchDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<List<SearchDto>, List<SearchEntity>>(searchDtos);
        }
        #endregion

        #region IEnumerable型のEntityとDtoの詰め替え処理
        public IEnumerable<SearchDto> IEnumerableExchangeEntityToDto(IEnumerable<SearchEntity> searchEntitys)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<SearchEntity>, IEnumerable<SearchDto>>(searchEntitys);
        }

        public IEnumerable<SearchEntity> IEnumerableExchangeDtoToEntity(IEnumerable<SearchDto> searchDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<IEnumerable<SearchDto>, IEnumerable<SearchEntity>>(searchDtos);
        }
        #endregion


    }
}
