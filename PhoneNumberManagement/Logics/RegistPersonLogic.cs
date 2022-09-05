using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;
using PhoneNumberManagement.DAO;

namespace PhoneNumberManagement.Logics
{
    public class RegistPersonLogic : IRegistPersonLogic
    {
        #region メンバー変数
        private PersonDao personRegistDao;
        #endregion

        #region　コンストラクター
        public RegistPersonLogic()
        {
            this.personRegistDao = new PersonDao();
        }
        #endregion

        public void registLogic(SqlConnection connection, PersonDto personDtos)
        {
            var personEntities = setRegistLogic(personDtos);
            personRegistDao.registDao(connection,personEntities);
        }

        public PersonEntity setRegistLogic(PersonDto personDtos)
        {
            var registerMan = new PersonEntity();

            registerMan.StaffName = personDtos.StaffName;
            registerMan.CompanyID = personDtos.CompanyID;
            registerMan.DepartmentID = personDtos.DepartmentID;
            registerMan.ExtensionNumber = personDtos.ExtensionNumber;
            registerMan.Memo = personDtos.Memo;

            return registerMan;

        }
    }
}
