using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Dto;

namespace PhoneNumberManagement.Services

{
    public class PhoneNumberManagementService
    {
        public PhoneNumberManagementDto FirstService()
        {

            var PhoneNumberManagementDto = new PhoneNumberManagementLogic.FirstLogic();
            return PhoneNumberManagementDto;

        }
    }
}
