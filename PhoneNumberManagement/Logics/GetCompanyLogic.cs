using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.Company;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class GetCompanyLogic
    {
        private CompanyDao companyDao;
        private CompanyEntityAndDto companyEntityAndDto;

        public GetCompanyLogic()
        {
            this.companyDao = new CompanyDao();
            this.companyEntityAndDto = new CompanyEntityAndDto();
        }

        public IEnumerable<CompanyDto> Logic(SqlConnection connection)
        {
            var dao = companyDao.Dao(connection);
            var result = companyEntityAndDto.IEnumerableExchangeEntityToDto(dao);
            return result;
        }
    }
}
