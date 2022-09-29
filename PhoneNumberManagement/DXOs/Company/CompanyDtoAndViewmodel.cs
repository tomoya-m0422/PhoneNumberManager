using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Company
{
    public class CompanyDtoAndViewmodel
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CompanyDto, CompanyViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<CompanyViewModel, CompanyDto>();
        });

        #region List型のDtoとViewModelの入れ替え処理
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="companyDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>ViewModel型のデータを返す</returns>
        public List<CompanyViewModel> ListExchangeDtoToViewmodel(List<CompanyDto> companyDtos)
        {
            var config = dtoToViewmodelOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<CompanyDto>, List<CompanyViewModel>>(companyDtos);
        }

        /// <summary>
        /// ViewModelにDTO型に入れ替える
        /// </summary>
        /// <param name="companyViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<CompanyDto> ListExchangeViewmodelToDto(List<CompanyViewModel> companyViewModels)
        {
            var config = viewmodelToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<CompanyViewModel>, List<CompanyDto>>(companyViewModels);
        }
        #endregion

        #region IEnumerable型のDTOとViewModelの入れ替え作業
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="companyDtos">Serviceから渡されたDtoデータ</param>
        /// <returns></returns>
        public IEnumerable<CompanyViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<CompanyDto> companyDtos)
        {
            var config = dtoToViewmodelOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<CompanyDto>, IEnumerable<CompanyViewModel>>(companyDtos);
        }

        /// <summary>
        /// ViewModelデータをDTOを入れ替える
        /// </summary>
        /// <param name="companyViewModels">FromtEndから渡されたViewModelデータ</param>
        /// <returns></returns>
        public IEnumerable<CompanyDto> IEnumerableExchangeViewmodelToDto(IEnumerable<CompanyViewModel> companyViewModels)
        {
            var config = viewmodelToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<CompanyViewModel>, IEnumerable<CompanyDto>>(companyViewModels);
        }
        #endregion
    }
}
