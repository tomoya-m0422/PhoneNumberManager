using PhoneNumberManagement.DTO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services

{
    public interface IManagementService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ManagementDto> FirstDawnService();
    }

}
