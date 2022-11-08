using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Management.Interface
{
    public interface IManagementEntityAndDtoDxo
    {
        ManagementDto ExchangeEntityToDto(ManagementEntity managementEntities);
        ManagementEntity ExchangeDtoToEntity(ManagementDto managementDtos);
        List<ManagementDto> ListExchangeEntityToDto(List<ManagementEntity> managementEntities);
        List<ManagementEntity> ListExchangeDtoToEntity(List<ManagementDto> managementDtos);
        IEnumerable<ManagementDto> IEnumerableExchangeEntityToDto(IEnumerable<ManagementEntity> managementEntities);
        IEnumerable<ManagementEntity> IEnumerableExchangeDtoToEntity(IEnumerable<ManagementDto> managementDtos);
    }
}
