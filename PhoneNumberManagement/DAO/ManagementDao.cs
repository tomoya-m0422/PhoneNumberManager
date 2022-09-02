﻿using System.Data.SqlClient;
using Dapper;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;
using System.Data;

namespace PhoneNumberManagement.DAO
{


    public class ManagementDao : IManagementDao
    {
        public IEnumerable<ManagementEntity> FirstConnect(SqlConnection connection)
        {
            var query = "SELECT * FROM Person AS p,Company AS c,Department AS d WHERE p.CompanyID = c.CompanyID AND p.DepartmentID = d.DepartmentID";
            var result = connection.Query<ManagementEntity>(query);

            return result;
        }


        public IEnumerable<ManagementEntity> searchDao(SqlConnection connection,SearchViewModel search)
        {

            var query = "SELECT * FROM Person AS p LEFT JOIN Company AS c ON p.CompanyID = c.CompanyID LEFT JOIN Department AS d ON p.DepartmentID = d.DepartmentID " +
                                "WHERE p.StaffName = @Name OR c.CompanyID = @CompanyID OR p.Memo = @Memo";

            SqlCommand command = new SqlCommand(query, connection);

            #region commansd.Parameters
            command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = search.StaffName;
            command.Parameters.Add("@CompanyID", SqlDbType.Int).Value = search.CompanyID;     
            command.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = search.Memo;
            #endregion

            //var result = connection.Query<ManagementEntity>(query);
            var gomi = command.ExecuteReader();
            var result = new List<ManagementEntity>();
            //var ans = new List<ManagementEntity>();
            
            while (gomi.Read())
            {
                var hoge = new ManagementEntity();
                hoge.StaffNumber = (int)gomi["StaffNumber"];
                hoge.StaffName = (string)gomi["StaffName"];
                hoge.CompanyID = (int)gomi["CompanyID"];
                hoge.DepartmentID = (int)gomi["DepartmentID"];
                hoge.ExtensionNumber = (string)gomi["ExtensionNumber"];
                hoge.Memo = (string)gomi["Memo"];
                hoge.CompanyName = (string)gomi["CompanyName"];
                hoge.DepartmentName = (string)gomi["DepartmentName"];

                result.Add(hoge);
            }

            return result;
        }
    }
}
