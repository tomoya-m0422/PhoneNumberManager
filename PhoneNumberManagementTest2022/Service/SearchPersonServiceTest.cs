using Moq;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Logics.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberManagementTest.Service
{
    [TestClass]
    public class SearchPersonServiceTest
    {
        public Mock<ISearchPersonLogic> mock;
        public ManagementDto managementDto;

        public SearchPersonServiceTest()
        {
            mock = new Mock<ISearchPersonLogic>();
            managementDto = new ManagementDto();
        }
    }
}
