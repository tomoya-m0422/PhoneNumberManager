using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;


namespace PhoneNumberManagement.Logics

{
    public class PhoneNumberManagementLogic
    {
        public PhoneNumberManagementDto FirstLogic()
        {
            var phoneNumberManagementEntity = new PhoneNumberManagementEntity();
            phoneNumberManagementEntity = ManagementDao.Connect1();
            var result = new PhoneNumberManagementDto();
            foreach(var entity in phoneNumberManagementEntity)
            {
                result.Add = entity;
            }
            return result;
        }
    }
}
