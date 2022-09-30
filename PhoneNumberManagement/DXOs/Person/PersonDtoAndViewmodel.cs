using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Person
{
    public class PersonDtoAndViewmodel
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PersonDto, PersonViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<PersonViewModel, PersonDto>();
        });

        #region List,IEnumerable型以外のViewModelとDTOの入れ替え処理
        /// <summary>
        /// DTOデータをViewmodelに置き換えます
        /// </summary>
        /// <param name="personDtos">Serviceから受け取ったDtoデータ</param>
        /// <returns>ViewModelデータ</returns>
        public PersonViewModel ExchangeDtoToViewmodel(PersonDto personDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<PersonDto,PersonViewModel>(personDtos); 
        }

        /// <summary>
        /// ViewModelデータをDTOに置き換えます
        /// </summary>
        /// <param name="personViewModels">FrontEndから受け取ったViewModel</param>
        /// <returns>DTOデータ</returns>
        public PersonDto ExchangeViewmodelToDto(PersonViewModel personViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<PersonViewModel,PersonDto>(personViewModels);
        }
        #endregion

        #region List型のDtoとViewModelの入れ替え処理
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="personDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>ViewModel型のデータを返す</returns>
        public List<PersonViewModel> ListExchangeDtoToViewmodel(List<PersonDto> personDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<List<PersonDto>, List<PersonViewModel>>(personDtos);
        }

        /// <summary>
        /// ViewModelにDTO型に入れ替える
        /// </summary>
        /// <param name="personViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<PersonDto> ListExchangeViewmodelToDto(List<PersonViewModel> personViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<List<PersonViewModel>, List<PersonDto>>(personViewModels);
        }
        #endregion

        #region IEnumerable型のDTOとViewModelの入れ替え作業
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="personDtos">Serviceから渡されたDtoデータ</param>
        /// <returns></returns>
        public IEnumerable<PersonViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<PersonDto> personDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<IEnumerable<PersonDto>, IEnumerable<PersonViewModel>>(personDtos);
        }

        /// <summary>
        /// ViewModelデータをDTOを入れ替える
        /// </summary>
        /// <param name="personViewModels">FromtEndから渡されたViewModelデータ</param>
        /// <returns></returns>
        public IEnumerable<PersonDto> IEnumerableExchangeViewmodelToDto(IEnumerable<PersonViewModel> personViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<PersonViewModel>, IEnumerable<PersonDto>>(personViewModels);
        }
        #endregion
    }
}
