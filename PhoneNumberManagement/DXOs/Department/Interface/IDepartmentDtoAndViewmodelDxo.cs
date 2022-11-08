using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Department.Interface
{
    public interface IDepartmentDtoAndViewmodelDxo
    {
        DepartmentViewModel ExchangeDtoToViewmodel(DepartmentDto departmentDtos);
        DepartmentDto ExchangeViewmodelToDto(DepartmentViewModel departmentViewModels);
        List<DepartmentViewModel> ListExchangeDtoToViewmodel(List<DepartmentDto> departmentDtos);
        List<DepartmentDto> ListExchangeViewmodelToDto(List<DepartmentViewModel> departmentViewModels);
        IEnumerable<DepartmentViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<DepartmentDto> departmentDtos );
        IEnumerable<DepartmentDto> IEnumerableExchangeViewmodelToDto(IEnumerable<DepartmentViewModel> departmentViewModels);
    }
}
