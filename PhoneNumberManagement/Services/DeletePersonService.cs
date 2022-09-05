﻿using PhoneNumberManagement.Logics;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Services
{
    public class DeletePersonService
    {
        #region メンバー変数
        private DeletePersonLogic deletePersonLogic;
        #endregion

        #region コンストラクタ
        public DeletePersonService()
        {
            deletePersonLogic = new DeletePersonLogic();
        }
        #endregion


        public void deleteService(int staffNumber)
        {
            var connectionString = "Data Source=NCP-TM04945-1;Initial Catalog=ManagementDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (var connection = new SqlConnection(connectionString))
            using (var command = connection.CreateCommand())
            {
                try
                {
                    //DB接続開始
                    connection.Open();
                    //SQLの実行
                    deletePersonLogic.deleteLogic(connection, staffNumber);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

    }
}