using PhoneNumberManagement.Logics;

namespace PhoneNumberManagement.Services

{
    public class PhoneNumberManagementService
    {
        public PhoneNumberManagementDto FirstService()
        {
            var PhoneNumberManagementDto = PhoneNumberManagementLogic.FirstLogic();
            return PhoneNumberManagementDto;

        }
    }
}
