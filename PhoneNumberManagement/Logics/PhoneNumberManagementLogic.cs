using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Dto;
using PhoneNumberManagement.DTO;


namespace PhoneNumberManagement.Logics

{
    public class PhoneNumberManagementLogic
    {
        public PhoneNumberManagementDto FirstLogic()
        {
            var phoneNumberManagementEntity = new PhoneNUmberManagementEntity();
            phoneNumberManagementEntity = PersonDao.aaaaa();
            var result = new PhoneNumberManagementDto<>();
            foreach(var entity in phoneNumberManagementEntity)
            {

            }
            return result;
        }
    }
}
