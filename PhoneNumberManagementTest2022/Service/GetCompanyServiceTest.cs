using Moq;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace PhoneNumberManagementTest.Service
{
    [TestClass]
    public class GetCompanyServiceTest
    {

        #region 正常に動くテスト
        [TestMethod]
        public void ServiceOkTest()
        {
            var mockGetCompanyLogic = new Mock<IGetCompanyLogic>();
            List<CompanyDto> companyDto = new List<CompanyDto>();

            mockGetCompanyLogic.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Returns(companyDto);

            var service = new GetCompanyService(mockGetCompanyLogic.Object);
            var result = service.Service();

            Assert.IsNotNull(result);
            Assert.AreEqual(companyDto, result);
        }
        #endregion

        #region Exceptionを起こすテスト
        [TestMethod]
        public void ServiceExceptionTest()
        {
            var mockGetCompanyLogic = new Mock<IGetCompanyLogic>();
            var exep = FormatterServices.GetUninitializedObject(typeof(Exception)) as Exception;
            mockGetCompanyLogic.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Throws(exep);

            var ex2 = String.Empty;

            var service = new GetCompanyService(mockGetCompanyLogic.Object);

            try
            {
                var result = service.Service();
            }
            catch(Exception ex)
            {
                ex2 = ex.Message;
                Assert.IsNotNull(ex);
            }
            Assert.AreNotEqual(String.Empty, ex2);
        }
        #endregion

        #region SqlExceptionを起こすテスト
        [TestMethod]
        public void ServiceSqlExceptionTest()
        {
            var mockGetCompanyLogic = new Mock<IGetCompanyLogic>();
            var exep = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mockGetCompanyLogic.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Throws(exep);

            var ex2 = String.Empty;

            var service = new GetCompanyService(mockGetCompanyLogic.Object);

            try
            {
                var result = service.Service();
            }
            catch (SqlException ex)
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
        #endregion

    }
}
