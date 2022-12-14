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
        #region メンバー変数とコンストラクタ
        public Mock<IGetCompanyLogic> mock;
        public GetCompanyService service;

        public GetCompanyServiceTest()
        {
            this.mock = new Mock<IGetCompanyLogic>();
            this.service = new GetCompanyService(mock.Object);
        }
        #endregion

        #region 正常に動くテスト
        [TestMethod]
        public void ServiceOkTest()
        {
            List<CompanyDto> companyDto = new List<CompanyDto>();
            mock.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Returns(companyDto);

            var result = service.Service();

            Assert.IsNotNull(result);
            Assert.AreEqual(companyDto, result);
        }
        #endregion

        #region Exceptionを起こすテスト
        [TestMethod]
        public void ServiceExceptionTest()
        {
            var exep = FormatterServices.GetUninitializedObject(typeof(Exception)) as Exception;
            mock.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Throws(exep);

            var ex2 = String.Empty;

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
            var exep = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mock.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Throws(exep);

            var ex2 = String.Empty;

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
