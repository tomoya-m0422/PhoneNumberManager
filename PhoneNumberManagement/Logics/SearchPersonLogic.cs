using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class SearchPersonLogic
    {
        #region メンバー変数
        private ManagementDao managementDao;
        #endregion

        #region コンストラクタ
        public SearchPersonLogic()
        {
            this.managementDao = new ManagementDao();
        }
        #endregion

        public List<ManagementDto> searchLogic (SqlConnection connection , SearchViewModel search)
        {
            var entities = managementDao.searchDao(connection,search);
            var result = setSearchLogic(entities);
            return result;
        }

        public List<ManagementDto> setSearchLogic(IEnumerable<ManagementEntity>entities)
        {
            var dtos = new List<ManagementDto>();
            foreach(var entity in entities)
            {
                var dto = new ManagementDto();

                dto.StaffNumber = entity.StaffNumber;
                dto.StaffName = entity.StaffName;
                dto.CompanyID = entity.CompanyID;
                dto.DepartmentID = entity.DepartmentID;
                dto.ExtensionNumber = entity.ExtensionNumber;
                dto.Memo = entity.Memo;
                dto.DepartmentName = entity.DepartmentName;
                dto.CompanyName = entity.CompanyName;

                dtos.Add(dto);
            }
            return dtos;
        }

    }
}
