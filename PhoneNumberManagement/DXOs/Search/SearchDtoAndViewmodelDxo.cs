using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Search.Interface;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Search
{
    public class SearchDtoAndViewmodelDxo : ISearchDtoAndViewmodelDxo
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<SearchDto, SearchViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<SearchViewModel, SearchDto>();
        });


        #region List,IEnumerable型以外のViewModelとDtoの詰め替え
        /// <summary>
        /// ViewModelデータをDtoに詰め替える
        /// </summary>
        /// <param name="searchDtos">Serviceから受け取ったDTOデータ</param>
        /// <returns>ViewModel</returns>
        public SearchViewModel ExchangeDtoToViewmodel (SearchDto searchDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<SearchDto, SearchViewModel>(searchDtos);
        }

        /// <summary>
        /// DtoデータをViewmodelに詰め替える
        /// </summary>
        /// <param name="searchViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>Dto</returns>
        public SearchDto ExchangeViewmodelToDto (SearchViewModel searchViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<SearchViewModel,SearchDto>(searchViewModels);
        }
        #endregion

        #region List型のViewModelとDtoの詰め替え
        /// <summary>
        /// ViewModelデータをDtoに詰め替える
        /// </summary>
        /// <param name="searchDtos">Serviceから受け取ったDto</param>
        /// <returns>SearchViewModel</returns>
        public List<SearchViewModel> ListExchangeDtoToViewmodel(List<SearchDto> searchDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<List<SearchDto>,List<SearchViewModel>>(searchDtos);
        }

        /// <summary>
        /// DtoデータをViewmodelに詰め替える
        /// </summary>
        /// <param name="searchViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>Dto</returns>
        public List<SearchDto> ListExchangeViewmodelToDto(List<SearchViewModel> searchViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<List<SearchViewModel>, List<SearchDto>>(searchViewModels);
        }
        #endregion

        #region IEnumerable型のModelとDtoの詰め替え
        /// <summary>
        /// ViewModelデータをDtoに詰め替える
        /// </summary>
        /// <param name="searchDtos">Serviceから受け取ったDto</param>
        /// <returns>ViewModel</returns>
        public IEnumerable<SearchViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<SearchDto> searchDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<IEnumerable<SearchDto>,IEnumerable<SearchViewModel>>(searchDtos);
        }

        /// <summary>
        /// DtoデータをViewModelに詰め替える
        /// </summary>
        /// <param name="searchViewModels">FrontEndから受け取ったViewModel</param>
        /// <returns>Dto</returns>
        public IEnumerable<SearchDto> IEnumerableExchangeViewmodelToDto(IEnumerable<SearchViewModel> searchViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<SearchViewModel>, IEnumerable<SearchDto>>(searchViewModels);
        }
        #endregion
    }
}
