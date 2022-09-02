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


        #region 本番用
        List<ManagementDto> FirstService();
        #endregion
    }

}
