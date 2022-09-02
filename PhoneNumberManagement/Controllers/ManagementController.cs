using Microsoft.AspNetCore.Mvc;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneNumberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        #region メンバー変数
        private ManagementService managementService;
        private RedistPersonService personRegisterService;
        private DeletePersonService deletePersonService;
        private SearchPersonService searchPersonService;
        private EditPersonService editPersonService;
        #endregion

        #region コンストラクター
        public ManagementController()
        {
            this.managementService = new ManagementService();
            this.personRegisterService = new RedistPersonService();
            this.deletePersonService = new DeletePersonService();
            this.searchPersonService = new SearchPersonService();
            this.editPersonService = new EditPersonService();
        }
        #endregion

        #region 初期処理：一覧表示(全件取得)
        [HttpGet]
        public IEnumerable<ManagementViewModel> Get()
        {
           var service = managementService.FirstService();
           var result = setManagementViewModel(service);
           return result;
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
        [HttpDelete("{staffNumber}")]
        public void DeletePerson(int staffNumber)
        {
            deletePersonService.deleteService(staffNumber);
        }
        #endregion

        #region 検索
        [HttpGet("Search")]
        public IEnumerable<ManagementViewModel> SearchController(SearchViewModel search)
        {
            var service = searchPersonService.searchService(search);
            var result = setManagementViewModel(service);
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