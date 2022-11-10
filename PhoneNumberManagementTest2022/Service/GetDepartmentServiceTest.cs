using Moq;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace PhoneNumberManagementTest.Service
{
    [TestClass]
    public class GetDepartmentServiceTest
    {
        #region メンバー変数とコンストラクタ
        public Mock<IGetDepartmentLogic> mock;
        public GetDepartmentService service;

        public GetDepartmentServiceTest()
        {
            this.mock = new Mock<IGetDepartmentLogic>();
            this.service = new GetDepartmentService(mock.Object);
        }
        #endregion

        #region 正常に動くテスト
        [TestMethod]
        public void ServiceOkTest()
        {
            List<DepartmentDto>  departmentDto = new List<DepartmentDto>();

            mock.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Returns(departmentDto);

            var result = service.Service();

            Assert.IsNotNull(result);
            Assert.AreEqual(departmentDto, result);
        }
        #endregion

        #region Exceptionを起こすテスト
        [TestMethod]
        public void ServiceExceptionTest()
        {
            var hoge = FormatterServices.GetUninitializedObject(typeof(Exception)) as Exception;
            mock.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Throws(hoge);
            var ex2 = String.Empty;

            try
            {
                var result = service.Service();
            }
            catch(Exception ex)
            {
                ex2=ex.Message;
                Assert.IsNotNull(ex);
            }
            Assert.IsNotNull(String.Empty, ex2);
        }
        #endregion

        #region SqlExceptionを起こすテスト
        [TestMethod]
        public void ServiceSqlExceptionTest()
        {
            var hoge = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mock.Setup(x => x.Logic(It.IsAny<SqlConnection>()))
                .Throws(hoge);
            var ex2 = String.Empty;

            try
            {
                var result = service.Service();
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
            Assert.IsNotNull(String.Empty, ex2);
        }
        #endregion
    }
}
