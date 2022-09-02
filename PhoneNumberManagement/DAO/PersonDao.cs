using Dapper;
using Microsoft.VisualBasic;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;
using System;
using System.ComponentModel.Design;
using System.Data;
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
            var query = "DELETE FROM Person WHERE StaffNumber =" + staffNumber+";";
            connection.Query<PersonEntity>(query);
        }

        public void editDao(SqlConnection connection, PersonEntity personEntities)
        {
            var query = "UPDATE Person SET StaffName = @Name,CompanyID = @CompanyID,DepartmentID = @DepartmentID,ExtensionNumber = @PNumber,Memo = @Memo" +
                                "WHERE StaffNumber = @SNumber;";

            #region command.Parameters
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@SNumber", SqlDbType.Int);
            command.Parameters["@SNumber"].Value = personEntities.StaffNumber;
            command.Parameters.Add("@Name", SqlDbType.NVarChar);
            command.Parameters["@Name"].Value = personEntities.StaffName;
            command.Parameters.Add("@CompanyID", SqlDbType.Int);
            command.Parameters["@CompanyID"].Value = personEntities.CompanyID;
            command.Parameters.Add("@DepartmentID", SqlDbType.Int);
            command.Parameters["@DepartmentID"].Value = personEntities.DepartmentID;
            command.Parameters.Add("@PNumber",SqlDbType.NVarChar);
            command.Parameters["@PNumber"].Value = personEntities.ExtensionNumber;
            command.Parameters.Add("@Memo", SqlDbType.NVarChar);
            command.Parameters["@Memo"].Value = personEntities.Memo;
            #endregion

            connection.Query<PersonEntity>(query);
        }

    }
}
