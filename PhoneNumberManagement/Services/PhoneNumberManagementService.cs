using PhoneNumberManagement.Logics;
using PhoneNumberManagement.DTO;

namespace PhoneNumberManagement.Services

{
    public class PhoneNumberManagementService
    {
        public PhoneNumberManagementDto FirstService()
        {

            var PhoneNumberManagementDto = new PhoneNumberManagementLogic();
            var result = (PhoneNumberManagementDto)PhoneNumberManagementDto.FirstLogic();
            return result;
            
        }
    }
}
