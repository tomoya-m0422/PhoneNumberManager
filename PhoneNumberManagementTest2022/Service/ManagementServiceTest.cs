using Moq;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace PhoneNumberManagementUnitTest
{
    [TestClass]
    public class ManagementServiceTest
    {

        [TestMethod]
        public void FirstServiceOkTest()
        {
            #region テスト実行準備
            var mockManagementLogic = new Mock<IManagementLogic>();
            List<ManagementDto> managementDto = new List<ManagementDto>();

            mockManagementLogic.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Returns(managementDto);
            #endregion

            var service = new ManagementService(mockManagementLogic.Object);
            var result = service.FirstService();

            Assert.IsNotNull(result);
            Assert.AreEqual(managementDto, result);
        }

        [TestMethod]
        public void FirstServiceExceptionTest()
        {
            var mockManagementLogic = new Mock<IManagementLogic>();
            var hoge = FormatterServices.GetUninitializedObject(typeof(Exception)) as Exception;
            mockManagementLogic.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Throws(hoge);

            var ex2 = String.Empty;

            var service = new ManagementService(mockManagementLogic.Object);
            try
            {
                var result = service.FirstService();
            }
            catch(Exception ex)
            {
                ex2 = ex.Message;
                Assert.IsNotNull(ex);
            }
            Assert.AreNotEqual(String.Empty,ex2);
        }

        [TestMethod]
        public void FirstServiceSqlExceptionTest()
        {
            var mockManagementLogic = new Mock<IManagementLogic>();
            var hoge = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mockManagementLogic.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Throws(hoge);

            var ex2 = String.Empty;

            var service = new ManagementService(mockManagementLogic.Object);
            try
            {
                var result = service.FirstService();
            }
            catch (Exception ex)
            {
                if(ex is SqlException)
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
    }
}
