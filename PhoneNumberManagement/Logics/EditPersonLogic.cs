using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class EditPersonLogic
    {
        #region メンバー変数
        private PersonDao personDao;
        #endregion

        #region コンストラクタ
        public EditPersonLogic()
        {
            personDao = new PersonDao();
        }
        #endregion

        public void editLogic(SqlConnection connection,PersonDto dto)
        {
            var result = setEditLogic(dto);
            personDao.editDao(connection,result);
        }

        public PersonEntity setEditLogic(PersonDto dto)
        {
            var editMan = new PersonEntity();

            editMan.StaffNumber = dto.StaffNumber;
            editMan.StaffName = dto.StaffName;
            editMan.CompanyID = dto.CompanyID;
            editMan.DepartmentID = dto.DepartmentID;
            editMan.ExtensionNumber = dto.ExtensionNumber;
            editMan.Memo = dto.Memo;

            return editMan;
        }
    }
}
