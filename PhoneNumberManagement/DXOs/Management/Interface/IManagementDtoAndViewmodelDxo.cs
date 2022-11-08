using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Management.Interface
{
    public interface IManagementDtoAndViewmodelDxo
    {
        ManagementViewModel ExchangeDtoToViewmodel(ManagementDto managementDtos);
        ManagementDto ExchangeViewmodelToDto(ManagementViewModel managementViewModels);
        List<ManagementViewModel> ListExchangeDtoToViewmodel(List<ManagementDto> managementDtos);
        List<ManagementDto> ListExchangeViewmodelToDto(List<ManagementViewModel> managementViewModels);
        IEnumerable<ManagementViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<ManagementDto> managementDtos);
        IEnumerable<ManagementDto> IEnumerableExchangeViewmodelToDto(IEnumerable<ManagementViewModel> managementViewModels);
    }
}
