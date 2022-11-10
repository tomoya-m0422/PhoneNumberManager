using Microsoft.AspNetCore.Mvc;
using PhoneNumberManagement.DAO;
using PhoneNumberManagement.DAOs.Interface;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.Company;
using PhoneNumberManagement.DXOs.Company.Interface;
using PhoneNumberManagement.DXOs.Department;
using PhoneNumberManagement.DXOs.Department.Interface;
using PhoneNumberManagement.DXOs.Management.Interface;
using PhoneNumberManagement.DXOs.Person;
using PhoneNumberManagement.DXOs.Person.Interface;
using PhoneNumberManagement.DXOs.Search;
using PhoneNumberManagement.DXOs.Search.Interface;
using PhoneNumberManagement.DXOs.StaffNumber;
using PhoneNumberManagement.DXOs.StaffNumber.Interface;
using PhoneNumberManagement.Logics;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;
using PhoneNumberManagement.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneNumberManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {

        #region メンバー変数
        private IManagementService managementService;
        private IRedistPersonService personRegisterService;
        private IDeletePersonService deletePersonService;
        private ISearchPersonService searchPersonService;
        private IEditPersonService editPersonService;
        private IDetailPersonService detailPersonService;
        private IGetCompanyService getCompanyService;
        private IGetDepartmentService getDepartmentService;
        private IManagementDtoAndViewmodelDxo managementDtoAndViewmodel;
        private ICompanyDtoAndViewmodelDxo companyDtoAndViewmodel;
        private IDepartmentDtoAndViewmodelDxo departmentDtoAndViewmodel;
        private IPersonDtoAndViewmodelDxo personDtoAndViewmodel;
        private ISearchDtoAndViewmodelDxo searchDtoAndViewmodel;
        private IStaffNumberDtoAndViewmodelDxo staffNumberDtoAndViewmodel;
        #endregion

        #region コンストラクター
        public ManagementController()
        {
            this.managementService = new ManagementService(new ManagementLogic(new ManagementDao(),new ManagementEntityAndDtoDxo()));
            this.personRegisterService = new RegistPersonService(new RegistPersonLogic(new PersonDao(),new PersonEntityAndDtoDxo()));
            this.deletePersonService = new DeletePersonService(new DeletePersonLogic(new PersonDao(),new StaffNumberEntityAndDtoDxo()));
            this.searchPersonService = new SearchPersonService(new SearchPersonLogic(new ManagementDao(),new SearchEntityAndDtoDxo(),new ManagementEntityAndDtoDxo()));
            this.editPersonService = new EditPersonService(new EditPersonLogic(new PersonDao(),new PersonEntityAndDtoDxo()));
            this.detailPersonService = new DetailPersonService(new DetailPersonLogic(new ManagementDao(),new ManagementEntityAndDtoDxo(),new StaffNumberEntityAndDtoDxo()));
            this.getCompanyService = new GetCompanyService(new GetCompanyLogic(new CompanyDao(),new CompanyEntityAndDtoDxo()));
            this.getDepartmentService = new GetDepartmentService(new GetDepartmentLogic(new DepartmentDao(),new DepartmentEntityAndDtoDxo()));
            this.managementDtoAndViewmodel = new ManagementDtoAndViewmodelDxo();
            this.companyDtoAndViewmodel = new CompanyDtoAndViewmodelDxo();
            this.departmentDtoAndViewmodel = new DepartmentDtoAndViewmodelDxo();
            this.personDtoAndViewmodel = new PersonDtoAndViewmodelDxo();
            this.searchDtoAndViewmodel = new SearchDtoAndViewmodelDxo();
            this.staffNumberDtoAndViewmodel = new StaffNumberDtoAndViewmodelDxo();

        }
        #endregion

        #region 初期処理：一覧表示(全件取得) HttpGet
        [HttpGet]
        public ActionResult<IEnumerable<ManagementViewModel>> Get()
        {
            //var response = this.Request.CreateResponse(HttpStatusCode.OK);
            //Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:4200");
            var service = managementService.FirstService();
            var result = managementDtoAndViewmodel.IEnumerableExchangeDtoToViewmodel(service);
            //var result = setManagementViewModel(service);
            //return new HttpResponse(result);
            return Ok(result);
        }
        #endregion

        #region 会社一覧取得 HttpGet("Company")
        [HttpGet ("Company")]
        public ActionResult<IEnumerable<CompanyViewModel>> CompanyGet()
        {
            var service = getCompanyService.Service();
            var result = companyDtoAndViewmodel.IEnumerableExchangeDtoToViewmodel(service);
            return Ok(result);
        }

        #endregion

        #region 部署一覧取得 HttpGet("Department")
        [HttpGet("Department")]
        public ActionResult<IEnumerable<DepartmentViewModel>> DepartmentGet()
        {
            var service = getDepartmentService.Service();
            var result = departmentDtoAndViewmodel.IEnumerableExchangeDtoToViewmodel(service);
            return Ok(result);
        }

        public IEnumerable<DepartmentViewModel> setDepartmentViewModel(IEnumerable<DepartmentDto> dtos)
        {
            var viewModel = new List<DepartmentViewModel>();

            foreach(var item in dtos)
            {
                DepartmentViewModel department = new DepartmentViewModel();

                department.DepartmentID = item.DepartmentID;
                department.DepartmentName = item.DepartmentName;

                viewModel.Add(department);
            }
            return viewModel;
        }
        #endregion
        
        #region　新規作成 HttpPost("register")
        [HttpPost("register")]
       public ActionResult registPerson(PersonViewModel viewModel)
       {
            var result = personDtoAndViewmodel.ExchangeViewmodelToDto(viewModel);
            personRegisterService.registService(result);
            return Ok();
       }
        #endregion

        #region  削除 HttpGet ("Delete/{staffNumber}")
        [HttpPost("Delete")]
        public void DeletePerson(StaffNumberViewModel staffNumber)
        {
            var result = staffNumberDtoAndViewmodel.ExchangeViewmodelToDto(staffNumber);
            deletePersonService.deleteService(result);
            //return Ok();
        }

        #endregion

        #region 検索 HttpPost("Search")
        [HttpPost("Search")]
        public IEnumerable<ManagementViewModel> SearchController(SearchViewModel search)
        {
            var Dto = searchDtoAndViewmodel.ExchangeViewmodelToDto(search);
            var service = searchPersonService.searchService(Dto);
            var result = managementDtoAndViewmodel.IEnumerableExchangeDtoToViewmodel(service);
            return result;
        }
        #endregion

        #region 詳細 HttpPost("Detail")
        [HttpPost("Detail")]
        public ManagementViewModel DetailController(StaffNumberViewModel id)
        {
            var Dto = staffNumberDtoAndViewmodel.ExchangeViewmodelToDto(id);
            var service = detailPersonService.detailService(Dto);
            var result = managementDtoAndViewmodel.ExchangeDtoToViewmodel(service);
            return result;
        }
        #endregion

        #region 編集 HttpPost("edit")
        [HttpPost("edit")]
        public void editController(PersonViewModel personViewModel)
        {
            var result = personDtoAndViewmodel.ExchangeViewmodelToDto(personViewModel);
            editPersonService.editService(result);
        }
        #endregion

        #region テスト用 HttpGet("TestButton")
        [HttpGet("TestButton")]
        public string aaa()
        {
            return "<aaa";
        }
        #endregion  

    }
}