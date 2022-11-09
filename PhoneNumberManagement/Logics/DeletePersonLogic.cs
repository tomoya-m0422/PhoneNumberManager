using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.StaffNumber;
using PhoneNumberManagement.DXOs.StaffNumber.Interface;
using PhoneNumberManagement.Logics.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class DeletePersonLogic : IDeletePersonLogic
    {
        #region メンバー変数
        private IPersonDao personDao;
        private IStaffNumberEntityAndDtoDxo staffNumberEntityAndDto;
        #endregion

        #region コンストラクタ
        public DeletePersonLogic(IPersonDao personDao, IStaffNumberEntityAndDtoDxo staffNumberEntityAndDto)
        {
            this.personDao = personDao;
            this.staffNumberEntityAndDto = staffNumberEntityAndDto;
        }
        #endregion

        public void deleteLogic(SqlConnection connection, StaffNumberDto staffNumber)
{
            var result =staffNumberEntityAndDto.ExchangeDtoToEntity(staffNumber);
            personDao.deleteDao(connection, result);
        }
    }
}
