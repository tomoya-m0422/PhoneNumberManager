using PhoneNumberManagement.DTO;

namespace PhoneNumberManagement.Services.Interface
{
    public interface IGetCompanyService
    {
        IEnumerable<CompanyDto> Service();
    }
}
