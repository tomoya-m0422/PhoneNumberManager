using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.StaffNumber.Interface
{
    public interface IStaffNumberEntityAndDtoDxo
    {
        StaffNumberDto ExchangeEntityToDto(StaffNumberEntity staffNumberEntitys);
        StaffNumberEntity ExchangeDtoToEntity(StaffNumberDto staffNumberDtos);
        List<StaffNumberDto> ListExchangeEntityToDto(List<StaffNumberEntity> staffNumberEntitys);
        List<StaffNumberEntity> ListExchangeDtoToEntity(List<StaffNumberDto> staffNumberDtos);
        IEnumerable<StaffNumberDto> IEnumerableExchangeEntityToDto(IEnumerable<StaffNumberEntity> staffNumberEntitys);
        IEnumerable<StaffNumberEntity> IEnumerableExchangeDtoToEntity(IEnumerable<StaffNumberDto> staffNumberDtos);
    }
}
