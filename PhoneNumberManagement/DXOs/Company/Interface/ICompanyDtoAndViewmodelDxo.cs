using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.Company.Interface
{
    public interface ICompanyDtoAndViewmodelDxo
    {
        CompanyViewModel ExchangeDtoToViewmodel(CompanyDto companyDtos);
        CompanyDto ExchangeViewmodelToDto(CompanyViewModel companyViewModels);
        List<CompanyViewModel> ListExchangeDtoToViewmodel(List<CompanyDto> companyDtos);
        List<CompanyDto> ListExchangeViewmodelToDto(List<CompanyViewModel> companyViewModels);
        IEnumerable<CompanyViewModel> IEnumerableExchangeDtoToViewmodel(IEnumerable<CompanyDto> companyDtos);
        IEnumerable<CompanyDto> IEnumerableExchangeViewmodelToDto(IEnumerable<CompanyViewModel> companyViewmodels);

    }
}
