using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public interface IManagementLogic
    {
        /// <summary>
        /// 最初のLogic
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        List<ManagementDto> FirstLogic(SqlConnection connection);
        List<ManagementDto> setPhoneNumberManagementDto(IEnumerable<ManagementEntity> entities);
    }
}
