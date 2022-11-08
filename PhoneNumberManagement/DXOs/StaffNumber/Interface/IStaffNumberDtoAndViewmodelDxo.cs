using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.StaffNumber.Interface
{
    public interface IStaffNumberDtoAndViewmodelDxo
    {
        StaffNumberViewModel ExchangeDtoToViewmodel(StaffNumberDto staffNumberDtos);
        StaffNumberDto ExchangeViewmodelToDto(StaffNumberViewModel staffNumberViewModels);
        List<StaffNumberViewModel> ExchangeDtoToViewmodel(List<StaffNumberDto> staffNumberDtos);
        List<StaffNumberDto> ExchangeViewmodelToDto(List<StaffNumberViewModel> staffNumberViewModels);
        IEnumerable<StaffNumberViewModel> ExchangeDtoToViewmodel(IEnumerable<StaffNumberDto> staffNumberDtos);
        IEnumerable<StaffNumberDto> ExchangeViewmodelToDto(IEnumerable<StaffNumberViewModel> staffNumberViewModels);
    }
}
