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

        #region　テスト用
        /*
        string FirstService();
        */
        #endregion

        #region 本番用
        IEnumerable<ManagementDto> FirstService();
        #endregion
    }

}
