using Moq;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using PhoneNumberManagement.Services.Interface;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace PhoneNumberManagementTest.Service
{
    [TestClass]
    public class RegistPersonServiceTest
    {
        #region メンバー変数とコンストラクタ
        public Mock<IRegistPersonLogic> mock;
        public PersonDto personDtos;

        public RegistPersonServiceTest()
        {
            this.mock = new Mock<IRegistPersonLogic>();
            this.personDtos = new PersonDto();
            #region personDtosの中身の定義
            personDtos.StaffName = "ももも";
            personDtos.CompanyID = 6;
            personDtos.DepartmentID = 9;
            personDtos.ExtensionNumber = "1979";
            personDtos.Memo = "も";
            #endregion
        }
        #endregion

        #region 正常に動くテスト
        [TestMethod]
        public void registServiceOkTest()
        {
            mock.Setup(x => x.registLogic(It.IsAny<SqlConnection>(), It.IsAny<PersonDto>()));
            var service = new RegistPersonService(mock.Object);

            try
            {
                service.registService(personDtos);
                mock.Verify(x => x.registLogic(It.IsAny<SqlConnection>(), It.IsAny<PersonDto>()), Times.Once);
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
            var hoge = FormatterServices.GetUninitializedObject(typeof(Exception))as Exception;
            mock.Setup(x => x.registLogic(It.IsAny<SqlConnection>(), It.IsAny<PersonDto>()))
                .Throws(hoge);

            var service = new RegistPersonService(mock.Object);
            var ex2 = String.Empty;

            try
            {
               service.registService(personDtos);
               
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
        public void registServiceSqlExceptionTest()
        {
            var hoge = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;
            mock.Setup(x => x.registLogic(It.IsAny<SqlConnection>(), It.IsAny<PersonDto>()))
                .Throws(hoge);

            var service = new RegistPersonService(mock.Object);
            var ex2 = String.Empty;

            try
            {
                service.registService(personDtos);

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

