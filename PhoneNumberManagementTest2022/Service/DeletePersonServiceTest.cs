using Moq;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace PhoneNumberManagementTest.Service
{
    [TestClass]
    public class DeletePersonServiceTest
    {
        public Mock<IDeletePersonLogic> mock;
        public StaffNumberDto staffNumber;

        public DeletePersonServiceTest()
        {
            mock = new Mock<IDeletePersonLogic>();
            staffNumber = new StaffNumberDto();
            staffNumber.StaffNumber = 1;
        }

        #region 正常に動くテストメソッド
        [TestMethod]
        public void deleteServiceOkTest()
        {
            mock.Setup(x => x.deleteLogic(It.IsAny<SqlConnection>(), It.IsAny<StaffNumberDto>()));
            var service = new DeletePersonService(mock.Object);

            try
            {
                service.deleteService(staffNumber);
                mock.Verify(x => x.deleteLogic(It.IsAny<SqlConnection>(), It.IsAny<StaffNumberDto>()), Times.Once);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        #endregion

        #region Exceptionを起こすテスト
        [TestMethod]
        public void registServiceExceptionTest()
        {
            var hoge = FormatterServices.GetUninitializedObject(typeof(Exception)) as Exception;
            mock.Setup(x => x.deleteLogic(It.IsAny<SqlConnection>(), It.IsAny<StaffNumberDto>()))
                .Throws(hoge);

            var service = new DeletePersonService(mock.Object);
            var ex2 = string.Empty;

            try
            {
                service.deleteService(staffNumber);
            }
            catch (Exception ex)
            {
                ex2 = ex.Message;
                Assert.IsNotNull(ex);
            }
            Assert.AreNotEqual(String.Empty, ex2);
        }
        #endregion

        #region SqlExceptionを起こすテスト
        [TestMethod]
        public void DeletePersonSqlExceptionTest()
        {
            var hoge = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mock.Setup(x => x.deleteLogic(It.IsAny<SqlConnection>(), It.IsAny<StaffNumberDto>()))
                .Throws(hoge);

            var service = new DeletePersonService(mock.Object);
            var ex2 = string.Empty;

            try
            {
                service.deleteService(staffNumber);
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    ex2 = ex.Message;
                    Assert.IsNotNull(ex);
                }
                else
                {
                    ex2 = String.Empty;
                }
            }
            Assert.AreNotEqual(String.Empty, ex2);
        }
        #endregion
    }
}
