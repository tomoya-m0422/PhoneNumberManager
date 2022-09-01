using PhoneNumberManagement.DAO;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class DeletePersonLogic
    {
        private PersonDao personDao;

        public DeletePersonLogic()
        {
            personDao = new PersonDao();
        }

        public void deleteLogic(SqlConnection connection, int staffNumber)
        {
            personDao.deleteDao(connection,staffNumber);
        }
    }
}
