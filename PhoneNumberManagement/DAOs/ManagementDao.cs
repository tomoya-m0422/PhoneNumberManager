using System.Data.SqlClient;
using Dapper;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Models;
using System.Data;

namespace PhoneNumberManagement.DAO
{


    public class ManagementDao : IManagementDao
    {

        #region 一覧取得
        public IEnumerable<ManagementEntity> FirstConnect(SqlConnection connection)
        {
            var query = "SELECT * FROM Person AS p,Company AS c,Department AS d WHERE p.CompanyID = c.CompanyID AND p.DepartmentID = d.DepartmentID";
            var result = connection.Query<ManagementEntity>(query);
            return result;
        }
        #endregion

        #region 検索
        public IEnumerable<ManagementEntity> searchDao(SqlConnection connection,SearchEntity search)
        {
            //検索クエリの生成
            var query = "SELECT * FROM Person AS p LEFT JOIN Company AS c ON p.CompanyID = c.CompanyID LEFT JOIN Department AS d ON p.DepartmentID = d.DepartmentID " +
                                "WHERE p.StaffName = @Name OR d.DepartmentName = @DepartmentName OR p.Memo = @Memo";

            SqlCommand cmd = new SqlCommand(query, connection);

            #region @を使えるようにする作業(commansd.Parameters)
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = search.StaffName;
            cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar).Value = search.DepartmentName;     
            cmd.Parameters.Add("@Memo", SqlDbType.NVarChar).Value = search.Memo;
            #endregion

            //SQLからのデータをEntityに変換している
            var gomi = cmd.ExecuteReader();
            var result = new List<ManagementEntity>();
            
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
        #endregion

        #region 詳細
        public ManagementEntity detailDao(SqlConnection connection, StaffNumberEntity upEntity)
        {
            var query = "SELECT * FROM Person AS p,Company AS c,Department AS d " +
                                "WHERE p.StaffNumber = @Number AND p.CompanyID = c.CompanyID AND p.DepartmentID = d.DepartmentID";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@Number", SqlDbType.Int).Value = upEntity.StaffNumber;

            var kekka = cmd.ExecuteReader();
            var result = new ManagementEntity();

            while (kekka.Read())
            {
                result.StaffNumber = (int)kekka["StaffNumber"];
                result.StaffName = (string)kekka["StaffName"];
                result.CompanyID = (int)kekka["CompanyID"];
                result.DepartmentID = (int)kekka["DepartmentID"];
                result.ExtensionNumber = (string)kekka["ExtensionNumber"];
                result.Memo = (string)kekka["Memo"];
                result.CompanyName = (string)kekka["CompanyName"];
                result.DepartmentName = (string)kekka["DepartmentName"];
            }
            return result;

        }
        #endregion
    }
}
