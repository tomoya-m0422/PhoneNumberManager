using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Logics.Interface;
using PhoneNumberManagement.Services;
using PhoneNumberManagement.Services.Interface;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PhoneNumberManagementUnitTest
{
    [TestClass]
    public class ManagementServiceTest
    {

        //[TestInitialize]
        //public void setUp()
        //{
        //     //mockManagementDao = new Mock<IManagementDao>();
        //     //mockManagementEntityAndDtoDxo = new Mock<IManagementEntityAndDtoDxo>();
        //     //mockManagementLogic = new Mock<IManagementLogic>(mockManagementDao.Object, mockManagementEntityAndDtoDxo.Object);
        //     //service = new ManagementService(mockManagementLogic.Object);
        //}

        [TestMethod]
        public void FirstServiceTest()
        {
            var mockManagementDao = new Mock<IManagementDao>();
            var mockManagementEntityAndDtoDxo = new Mock<IManagementEntityAndDtoDxo>();
            var mockManagementLogic = new Mock<IManagementLogic>(mockManagementDao.Object, mockManagementEntityAndDtoDxo.Object);
            
            mockManagementLogic.Setup(x => x.FirstLogic(It.IsAny<SqlConnection>()))
                .Returns(new List<ManagementDto>());
            
            var service = new ManagementService(mockManagementLogic.Object);

            var result = service.FirstService();

            Assert.IsNotNull(result);
            Assert.AreEqual(new List<ManagementDto>(),result);
        }
    }
}
