using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXO.Management
{
    public class ManagementDtoAndViewmodelDxo : IManagementDtoAndViewmodelDxo
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementDto, ManagementViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<ManagementViewModel, ManagementDto>();
        });



        #region List,IEnumerable以外ののDTOとViewModelの入れ替え作業
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="managementDtos">Serviceから渡されたDtoデータ</param>
        /// <returns></returns>
        public ManagementViewModel ExchangeDtoToViewmodel(ManagementDto managementDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<ManagementDto, ManagementViewModel>(managementDtos);
        }

        /// <summary>
        /// ViewModelデータをDTOを入れ替える
        /// </summary>
        /// <param name="managementViewModels">FromtEndから渡されたViewModelデータ</param>
        /// <returns></returns>
        public ManagementDto ExchangeViewmodelToDto(ManagementViewModel managementViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<ManagementViewModel, ManagementDto>(managementViewModels);
        }
        #endregion

        #region List型のDtoとViewModelの入れ替え処理
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="managementDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>ViewModel型のデータを返す</returns>
        public List<ManagementViewModel> ListExchangeDtoToViewmodel (List<ManagementDto> managementDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<List<ManagementDto>, List<ManagementViewModel>>(managementDtos);
        }

        /// <summary>
        /// ViewModelにDTO型に入れ替える
        /// </summary>
        /// <param name="managementViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<ManagementDto> ListExchangeViewmodelToDto (List<ManagementViewModel> managementViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
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
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<IEnumerable<ManagementDto>, IEnumerable<ManagementViewModel>>(managementDtos);
        }

        /// <summary>
        /// ViewModelデータをDTOを入れ替える
        /// </summary>
        /// <param name="managementViewModels">FromtEndから渡されたViewModelデータ</param>
        /// <returns></returns>
        public IEnumerable<ManagementDto> IEnumerableExchangeViewmodelToDto (IEnumerable<ManagementViewModel> managementViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<ManagementViewModel>, IEnumerable<ManagementDto>>(managementViewModels);
        }
        #endregion
    }
}
