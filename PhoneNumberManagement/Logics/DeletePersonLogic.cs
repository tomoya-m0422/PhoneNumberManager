using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.StaffNumber;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class DeletePersonLogic
    {
        private PersonDao personDao;
        private StaffNumberEntityAndDto staffNumberEntityAndDto;

        public DeletePersonLogic()
        {
            this.personDao = new PersonDao();
            this.staffNumberEntityAndDto = new StaffNumberEntityAndDto();
        }

        public void deleteLogic(SqlConnection connection, StaffNumberDto staffNumber)
        {
            var result =staffNumberEntityAndDto.ExchangeDtoToEntity(staffNumber);
            personDao.deleteDao(connection, result);
        }
    }
}
