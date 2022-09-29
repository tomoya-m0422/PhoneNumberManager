using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXO.Management
{
    public class ManagementDtoAndViewmodel
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementDto, ManagementViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementViewModel, ManagementDto>();
        });

        #region List型のDtoとViewModelの入れ替え処理
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="managementDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>ViewModel型のデータを返す</returns>
        public List<ManagementViewModel> ListExchangeDtoToViewmodel (List<ManagementDto> managementDtos)
        {
            var config =  dtoToViewmodelOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<ManagementDto>, List<ManagementViewModel>>(managementDtos);
        }

        /// <summary>
        /// ViewModelにDTO型に入れ替える
        /// </summary>
        /// <param name="managementViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<ManagementDto> ListExchangeViewmodelToDto (List<ManagementViewModel> managementViewModels)
        {
            var config = viewmodelToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<List<ManagementViewModel>, List<ManagementDto>>(managementViewModels);
        }
        #endregion

        #region IEnumerable型のDTOとViewModelの入れ替え作業
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="managementDtos">Serviceから渡されたDtoデータ</param>
        /// <returns></returns>
        public IEnumerable<ManagementViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<ManagementDto> managementDtos)
        {
            var config = dtoToViewmodelOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ManagementDto>, IEnumerable<ManagementViewModel>>(managementDtos);
        }

        /// <summary>
        /// ViewModelデータをDTOを入れ替える
        /// </summary>
        /// <param name="managementViewModels">FromtEndから渡されたViewModelデータ</param>
        /// <returns></returns>
        public IEnumerable<ManagementDto> IEnumerableExchangeViewmodelToDto (IEnumerable<ManagementViewModel> managementViewModels)
        {
            var config = viewmodelToDtoOverride;

            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<ManagementViewModel>, IEnumerable<ManagementDto>>(managementViewModels);
        }
        #endregion
    }
}
