using Moq;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace PhoneNumberManagementTest.Service
{
    [TestClass]
    public class ManagementServiceTest
    {
        #region メンバー変数とコンストラクタ
        public  Mock<IManagementLogic> mock;
        public  ManagementService service;

        public ManagementServiceTest()
        {
            this.mock = new Mock<IManagementLogic>();
            this.service = new ManagementService(mock.Object);
        }
        #endregion

        #region 正常に動くテスト
        [TestMethod]
        public void FirstServiceOkTest()
        {
            #region テスト実行準備
            List<ManagementDto> managementDto = new List<ManagementDto>();

            mock.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Returns(managementDto);
            #endregion

            var result = service.FirstService();

            Assert.IsNotNull(result);
            Assert.AreEqual(managementDto, result);
        }
        #endregion

        #region Exceptionを起こすテスト
        [TestMethod]
        public void FirstServiceExceptionTest()
        {

            var hoge = FormatterServices.GetUninitializedObject(typeof(Exception)) as Exception;
            mock.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Throws(hoge);

            var ex2 = String.Empty;

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
        #endregion

        #region SqlExceptionを起こすテスト
        [TestMethod]
        public void FirstServiceSqlExceptionTest()
        {

            var hoge = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mock.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Throws(hoge);

            var ex2 = String.Empty;

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
        #endregion 
    }
}
