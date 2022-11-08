using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Person;
using PhoneNumberManagement.DXOs.Person.Interface;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Models;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class EditPersonLogic : IEditPersonLogic
    {
        #region メンバー変数
        private IPersonDao personDao;
        private IPersonEntityAndDtoDxo personEntityAndDto;
        #endregion

        #region コンストラクタ
        public EditPersonLogic(IPersonDao personDao, IPersonEntityAndDtoDxo personEntityAndDto)
        {
            personDao = this.personDao;
            personEntityAndDto = this.personEntityAndDto;
        }
        #endregion

        public void editLogic(SqlConnection connection,PersonDto dto)
        {
            var result = personEntityAndDto.ExchangeDtoToEntity(dto);
            personDao.editDao(connection,result);
        }
    }
}
