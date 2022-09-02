using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics

{
    public class ManagementLogic : IManagementLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        #endregion 

        #region コンストラクタ
        public ManagementLogic()
        {
            this.managementDao = new ManagementDao();
        }
        #endregion 


        public List<ManagementDto> FirstLogic(SqlConnection connection)
        {
            //DaoにSQLServerからデータを取ってくるように指示したあとenetityにデータを入れる
            var entity = managementDao.FirstConnect(connection);
            var result = setPhoneNumberManagementDto(entity);
            return result;
        }



        public List<ManagementDto> setPhoneNumberManagementDto(IEnumerable<ManagementEntity> entities)
        {
            var dtos = new List<ManagementDto>();

            foreach (var entity in entities)
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