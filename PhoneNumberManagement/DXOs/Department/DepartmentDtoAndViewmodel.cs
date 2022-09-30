using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Department
{
    public class DepartmentDtoAndViewmodel
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DepartmentDto, DepartmentViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DepartmentViewModel, DepartmentDto>();
        });

        #region List,IEnumerable型以外のViewModelとDtoの詰め替え処理
        public DepartmentViewModel ExchangeDtoToViewmodel (DepartmentDto departmentDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<DepartmentDto,DepartmentViewModel>(departmentDtos);
        }

        public DepartmentDto ExchangeViewmodelToDto(DepartmentViewModel departmentViewModel)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<DepartmentViewModel, DepartmentDto>(departmentViewModel);
        }
        #endregion

        #region List型のDtoとViewModelの入れ替え処理
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="departmentDtos">Serviceから渡されたDtoデータ</param>
        /// <returns>ViewModel型のデータを返す</returns>
        public List<DepartmentViewModel> ListExchangeDtoToViewmodel(List<DepartmentDto> departmentDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<List<DepartmentDto>, List<DepartmentViewModel>>(departmentDtos);
        }

        /// <summary>
        /// ViewModelにDTO型に入れ替える
        /// </summary>
        /// <param name="departmentViewModels">FrontEndから渡されたViewModelデータ</param>
        /// <returns>DTO型のデータを返す</returns>
        public List<DepartmentDto> ListExchangeViewmodelToDto(List<DepartmentViewModel> departmentViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<List<DepartmentViewModel>, List<DepartmentDto>>(departmentViewModels);
        }
        #endregion

        #region IEnumerable型のDTOとViewModelの入れ替え作業
        /// <summary>
        /// DTOデータをViewModelに入れ替える 
        /// </summary>
        /// <param name="departmentDtos">Serviceから渡されたDtoデータ</param>
        /// <returns></returns>
        public IEnumerable<DepartmentViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<DepartmentDto> departmentDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<IEnumerable<DepartmentDto>, IEnumerable<DepartmentViewModel>>(departmentDtos);
        }

        /// <summary>
        /// ViewModelデータをDTOを入れ替える
        /// </summary>
        /// <param name="departmentViewModels">FromtEndから渡されたViewModelデータ</param>
        /// <returns></returns>
        public IEnumerable<DepartmentDto> IEnumerableExchangeViewmodelToDto(IEnumerable<DepartmentViewModel> departmentViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<DepartmentViewModel>, IEnumerable<DepartmentDto>>(departmentViewModels);
        }
        #endregion
    }
}
