using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Person;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class EditPersonLogic
    {
        #region メンバー変数
        private PersonDao personDao;
        private PersonEntityAndDto personEntityAndDto;
        #endregion

        #region コンストラクタ
        public EditPersonLogic()
        {
            this.personDao = new PersonDao();
            this.personEntityAndDto = new PersonEntityAndDto();
        }
        #endregion

        public void editLogic(SqlConnection connection,PersonDto dto)
        {
            var result = personEntityAndDto.ExchangeDtoToEntity(dto);
            personDao.editDao(connection,result);
        }
    }
}
