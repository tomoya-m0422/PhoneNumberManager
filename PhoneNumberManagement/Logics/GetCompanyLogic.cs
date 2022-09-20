using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Data.SqlClient;

namespace PhoneNumberManagement.Logics
{
    public class GetCompanyLogic
    {
        private CompanyDao companyDao;

        public GetCompanyLogic()
        {
            this.companyDao = new CompanyDao();
        }

        public List<CompanyDto> Logic(SqlConnection connection)
        {
            var dao = companyDao.Dao(connection);
            var result = setCompanyDto(dao);
            return result;
        }

        public List<CompanyDto> setCompanyDto(IEnumerable<CompanyEntity> entities)
        {
            var dtos = new List<CompanyDto>();

            foreach(var item in entities)
            {
                var aho = new CompanyDto();

                aho.CompanyID = item.CompanyID;
                aho.CompanyName = item.CompanyName;

                dtos.Add(aho);
            }
            return dtos;
        }
    }
}
