using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Entity;
using System.Net;

namespace PhoneNumberManagement.DXOs.Company.Interface
{
    public interface ICompanyEntityAndDtoDxo
    {
        CompanyDto ExchangeEntityToDto(CompanyEntity companyEntitiys);
        CompanyEntity ExchangeDtoToEntity(CompanyDto companyDtos);
        List<CompanyDto> ListExchangeDtoToEntity(List<CompanyEntity> companyEntities);
        List<CompanyEntity> ListExchangeEntityToDto(List<CompanyDto> companyDtos);
        IEnumerable<CompanyDto> IEnumerableExchangeEntityToDto(IEnumerable<CompanyEntity> companyEntities);
        IEnumerable<CompanyEntity> IEnumerableExchangeDtoToEntity(IEnumerable<CompanyDto> companyDtos);

    }
}
