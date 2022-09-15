using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using PhoneNumberManagement.DTO;
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
        }
        #endregion

        #region 初期処理：一覧表示(全件取得)
        [HttpGet]
        public ActionResult<IEnumerable<ManagementViewModel>> Get()
        {
            //var response = this.Request.CreateResponse(HttpStatusCode.OK);
            //Response.Headers.Add("Access-Control-Allow-Origin", "https://localhost:4200");
            var service = managementService.FirstService();
            var result = setManagementViewModel(service);
            //return new HttpResponse(result);
            return Ok(result);
        }


        public IEnumerable<ManagementViewModel> setManagementViewModel(IEnumerable<ManagementDto> DTO)
        {
            var viewModels = new List<ManagementViewModel>();
            foreach (var items in DTO)
            {
                var gomi = new ManagementViewModel();

                gomi.StaffNumber = items.StaffNumber;
                gomi.StaffName = items.StaffName;
                gomi.CompanyID = items.CompanyID;
                gomi.DepartmentID = items.DepartmentID;
                gomi.ExtensionNumber = items.ExtensionNumber;
                gomi.Memo = items.Memo;
                gomi.DepartmentName = items.DepartmentName;
                gomi.CompanyName = items.CompanyName;

                viewModels.Add(gomi);
            }

            return viewModels;
        }
        #endregion

        #region　新規作成
        [HttpPost("register")]
       public void registPerson(PersonViewModel viewModel)
       {
            var result = setDtoRegistPerson(viewModel);
            personRegisterService.registService(result);
       }

       public PersonDto setDtoRegistPerson(PersonViewModel viewModel)
       {
            var registerMan = new PersonDto();
           
            registerMan.StaffName = viewModel.StaffName;
            registerMan.CompanyID = viewModel.CompanyID;
            registerMan.DepartmentID = viewModel.DepartmentID;
            registerMan.ExtensionNumber = viewModel.ExtensionNumber;
            registerMan.Memo = viewModel.Memo;  

            return registerMan;
       }
        #endregion

        #region  削除
        [HttpGet("Delete/{staffNumber}")]
        public ActionResult DeletePerson(int staffNumber)
        {
            deletePersonService.deleteService(staffNumber);
            return Ok();
        }

        #endregion

        #region 検索
        [HttpGet("Search")]
        public IEnumerable<ManagementViewModel> SearchController(SearchViewModel search)
        {
            var Dto = setSearchDto(search);
            var service = searchPersonService.searchService(Dto);
            var result = setManagementViewModel(service);
            return result;
        }

        public SearchDto setSearchDto (SearchViewModel search)
        {
            var searchMan = new SearchDto();
            searchMan.StaffName = search.StaffName;
            searchMan.CompanyID = search.CompanyID;
            searchMan.Memo = search.Memo;

            return searchMan;
        }
        #endregion

        #region 詳細
        [HttpGet("Detail/{id}")]
        public ManagementViewModel DetailController(int id)
        {
            var Dto = setDetailDto(id);
            var service = detailPersonService.detailService(Dto);
            var result = setDownManagementViewModel(service);
            return result;
        }

        public DetailDto setDetailDto(int detail)
        {
            var detailMan = new DetailDto();
            detailMan.StaffNumber = detail;
            return detailMan;
        }

        public ManagementViewModel setDownManagementViewModel(ManagementDto service)
        {
            var result = new ManagementViewModel();
            result.StaffNumber = service.StaffNumber;
            result.StaffName = service.StaffName;
            result.CompanyID = service.CompanyID;
            result.CompanyName = service.CompanyName;
            result.DepartmentID = service.DepartmentID;
            result.DepartmentName = service.DepartmentName;
            result.Memo = service.Memo;
            result.ExtensionNumber = service.ExtensionNumber;

            return result;
        }
        #endregion

        #region 編集
        [HttpPost("edit")]
        public void editController(PersonViewModel personViewModel)
        {
            var result = setDtoEditPerson(personViewModel);
            editPersonService.editService(result);

        }

        public PersonDto setDtoEditPerson (PersonViewModel personViewModel)
        {
            var editMan = new PersonDto();

            editMan.StaffNumber = personViewModel.StaffNumber;
            editMan.StaffName = personViewModel.StaffName;
            editMan.CompanyID = personViewModel.CompanyID;
            editMan.DepartmentID = personViewModel.DepartmentID;
            editMan.ExtensionNumber = personViewModel.ExtensionNumber;
            editMan.Memo = personViewModel.Memo;

            return editMan;
        }
        #endregion


    }
}