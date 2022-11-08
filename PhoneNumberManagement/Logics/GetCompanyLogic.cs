using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Company;
using PhoneNumberManagement.DXOs.Company.Interface;
using PhoneNumberManagement.Entity;
using PhoneNumberManagement.Logics.Interface;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class GetCompanyLogic : IGetCompanyLogic
    {
        private ICompanyDao companyDao;
        private ICompanyEntityAndDtoDxo companyEntityAndDto;

        public GetCompanyLogic(ICompanyDao companyDao, ICompanyEntityAndDtoDxo companyEntityAndDto)
        {
            companyDao = this.companyDao;
            companyEntityAndDto = this.companyEntityAndDto;
        }

        public IEnumerable<CompanyDto> Logic(SqlConnection connection)
        {
            var dao = companyDao.Dao(connection);
            var result = companyEntityAndDto.IEnumerableExchangeEntityToDto(dao);
            return result;
        }
    }
}
