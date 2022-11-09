using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;
using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DXOs.Person;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DXOs.Person.Interface;

namespace PhoneNumberManagement.Logics
{
    public class RegistPersonLogic : IRegistPersonLogic
    {
        #region メンバー変数
        private IPersonDao personRegistDao;
        private IPersonEntityAndDtoDxo personEntityAndDto;
        #endregion

        #region　コンストラクター
        public RegistPersonLogic(IPersonDao personRegistDao, IPersonEntityAndDtoDxo personEntityAndDto)
        {
            this.personRegistDao = personRegistDao;
            this.personEntityAndDto = personEntityAndDto;
        }
        #endregion

        public void registLogic(SqlConnection connection, PersonDto personDtos)
        {
            var personEntities = personEntityAndDto.ExchangeDtoToEntity(personDtos);
            personRegistDao.registDao(connection,personEntities);
        }

        //public PersonEntity setRegistLogic(PersonDto personDtos)
        //{
        //    var registerMan = new PersonEntity();

        //    registerMan.StaffName = personDtos.StaffName;
        //    registerMan.CompanyID = personDtos.CompanyID;
        //    registerMan.DepartmentID = personDtos.DepartmentID;
        //    registerMan.ExtensionNumber = personDtos.ExtensionNumber;
        //    registerMan.Memo = personDtos.Memo;

        //    return registerMan;

        //}
    }
}
