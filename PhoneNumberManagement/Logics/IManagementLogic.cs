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
        IEnumerable<ManagementDto> FirstLogic(SqlConnection connection);
        //IEnumerable<ManagementDto> setPhoneNumberManagementDto(IEnumerable<ManagementEntity> entities);
    }
}
