using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXO.Management;
using PhoneNumberManagement.DXOs.Company;
using PhoneNumberManagement.DXOs.Department;
using PhoneNumberManagement.DXOs.Person;
using PhoneNumberManagement.DXOs.Search;
using PhoneNumberManagement.DXOs.StaffNumber;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;
using System.Net;
using System.Text;
using System.Web;
using static Dapper.SqlMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneNumberManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {

        #region メンバー変数
        private ManagementService managementService;
        private RedistPersonService personRegisterService;
        private DeletePersonService deletePersonService;
        private SearchPersonService searchPersonService;
        private EditPersonService editPersonService;
        private DetailPersonService detailPersonService;
        private GetCompanyService getCompanyService;
        private GetDepartmentService getDepartmentService;
        private ManagementDtoAndViewmodel managementDtoAndViewmodel;
        private CompanyDtoAndViewmodel companyDtoAndViewmodel;
        private DepartmentDtoAndViewmodel departmentDtoAndViewmodel;
        private PersonDtoAndViewmodel personDtoAndViewmodel;
        private SearchDtoAndViewmodel searchDtoAndViewmodel;
        private StaffNumberDtoAndViewmodel staffNumberDtoAndViewmodel;
        #endregion

        #region コンストラクター
        public ManagementController()
        {
            this.managementService = new ManagementService();
            this.personRegisterService = new RedistPersonService();
            this.deletePersonService = new DeletePersonService();
            this.searchPersonService = new SearchPersonService();
            this.editPersonService = new EditPersonService();
            this.detailPersonService = new DetailPersonService();
            this.getCompanyService = new GetCompanyService();
            this.getDepartmentService = new GetDepartmentService();
            this.managementDtoAndViewmodel = new ManagementDtoAndViewmodel();
            this.companyDtoAndViewmodel = new CompanyDtoAndViewmodel();
            this.departmentDtoAndViewmodel = new DepartmentDtoAndViewmodel();
            this.personDtoAndViewmodel = new PersonDtoAndViewmodel();   
            this.searchDtoAndViewmodel = new SearchDtoAndViewmodel();
            this.staffNumberDtoAndViewmodel = new StaffNumberDtoAndViewmodel();

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