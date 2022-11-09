using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics.Interface
{
    public interface IRegistPersonLogic
    {
        public void registLogic(SqlConnection connection, PersonDto personDto);
        //PersonEntity setRegistLogic(PersonDto personDto);
    }
}
