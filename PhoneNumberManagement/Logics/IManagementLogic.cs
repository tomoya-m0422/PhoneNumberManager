using PhoneNumberManagement.DTO;

namespace PhoneNumberManagement.Logics
{
    public interface IManagementLogic
    {
        /// <summary>
        /// 最初のLogic
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        IEnumerable<ManagementDto> FirstDawnLogic();
    }
}
