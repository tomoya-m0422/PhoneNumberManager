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
        #region 追加
        public void registDao(SqlConnection connection,PersonEntity personEntities)
        {
            var query = "INSERT INTO Person VALUES (@Name,@CompanyID,@DepartmentID,@PNumber,@Memo);";

            SqlCommand cmd = new SqlCommand(query, connection);

            #region @を使えるようにする作業
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = personEntities.StaffName;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = personEntities.CompanyID;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = personEntities.DepartmentID;
            cmd.Parameters.Add("@PNumber", SqlDbType.NVarChar).Value = personEntities.ExtensionNumber;
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = personEntities.Memo;
            #endregion
            cmd.ExecuteNonQuery();
            // connection.Query<PersonEntity>(query);
        }
        #endregion

        #region 削除
        public void deleteDao(SqlConnection connection ,int staffNumber)
        {
            var query = "DELETE FROM Person WHERE StaffNumber =" + staffNumber+";";
            connection.Query<PersonEntity>(query);
        }
        #endregion

        #region 編集
        public void editDao(SqlConnection connection, PersonEntity personEntities)
        {
            var query = "UPDATE Person SET StaffName = @Name,CompanyID = @CompanyID,DepartmentID = @DepartmentID,ExtensionNumber = @PNumber,Memo = @Memo" +
                                "WHERE StaffNumber = @SNumber;";

            SqlCommand cmd = new SqlCommand(query, connection);

            #region cmd.Parameters
            cmd.Parameters.Add("@SNumber", SqlDbType.Int).Value = personEntities.StaffNumber;
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = personEntities.StaffName; ;
            cmd.Parameters.Add("@CompanyID", SqlDbType.Int).Value = personEntities.CompanyID; ;
            cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = personEntities.DepartmentID;
            cmd.Parameters.Add("@PNumber",SqlDbType.NVarChar).Value = personEntities.ExtensionNumber;
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = personEntities.Memo;
            #endregion

            connection.Query<PersonEntity>(query);
        }
        #endregion

    }
}
