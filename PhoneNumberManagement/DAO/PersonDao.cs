using Dapper;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.DAO
{
    public class PersonDao : IPersonDao
    {
        public void registDao(SqlConnection connection,PersonEntity personEntities)
        {
            var query = "INSERT INTO Person VALUES " +
                "(' "+
                personEntities.StaffName+" ' , "+personEntities.CompanyID+" ,"+ personEntities.DepartmentID+",'"+ personEntities.ExtensionNumber+"','"+ personEntities.Memo+
                "'); ";
            connection.Query<PersonEntity>(query);
        }


        public void deleteDao(SqlConnection connection ,int staffNumber)
        {
            var qurey = "DELETE FROM Person WHERE StaffNumber =" + staffNumber+";";
            connection.Query<PersonEntity>(qurey);
        }

    }
}
