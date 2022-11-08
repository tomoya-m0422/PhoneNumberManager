using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.Department.Interface
{
    public interface IDepartmentEntityAndDtoDxo
    {
        DepartmentDto ExchangeEntityToDto(DepartmentEntity departmentEntities);
        DepartmentEntity ExchangeDtoToEntity(DepartmentDto departmentDto);
        List<DepartmentDto> ListExchangeDtoToEntity(List<DepartmentEntity> departmentEntities);
        List<DepartmentEntity> ListExchangeEntityToDto(List<DepartmentDto> departmentDtos);
        IEnumerable<DepartmentDto> IEnumerableExchangeEntityToDto(IEnumerable<DepartmentEntity> departmentEntities);
        IEnumerable<DepartmentEntity> IEnumerableExchangeDtoToEntity(IEnumerable<DepartmentDto> departmentDtos);
    }
}
