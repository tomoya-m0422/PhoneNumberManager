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
        #region テスト:上手くつながっているか確認用

        /*
        #region メンバー変数
        private ManagementService managementService;
        #endregion

        #region コンストラクター

        public ManagementController()
        {
            this.managementService = new ManagementService();
        }
        #endregion

        #region 初期処理：一覧表示(全件取得)
        [HttpGet]
        public string Get()
        {
            var service = managementService.FirstService();
            string result = "Controllerやで";
            return result+service;
        }
        #endregion
       */
        #endregion

        #region 本番

        #region メンバー変数
        private ManagementService managementService;
        private PersonRegistService personRegisterService;
        #endregion

        #region コンストラクター
        public ManagementController()
        {
            this.managementService = new ManagementService();
            this.personRegisterService = new PersonRegistService();
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
        [HttpPost]
       public void registPerson()
       {
            PersonViewModel personViewModel = new PersonViewModel();
            personViewModel.StaffNumber = 2;
            personViewModel.StaffName = "トニースターク";
            personViewModel.CompanyID = 2;
            personViewModel.DepartmentID = 2;
            personViewModel.ExtensionNumber = "07055000427";
            var result = setDtoRegistPerson((IEnumerable<PersonViewModel>)personViewModel);
            personRegisterService.registService(result);
       }

       public IEnumerable<PersonDto> setDtoRegistPerson(IEnumerable<PersonViewModel> personViewModel)
       {
            var registerMan = new List<PersonDto>();
            foreach (var item in personViewModel)
            {
                var gomi = new PersonDto();

                gomi.StaffNumber = item.StaffNumber;
                gomi.StaffName = item.StaffName;
                gomi.CompanyID = item.CompanyID;
                gomi.DepartmentID = item.DepartmentID;
                gomi.ExtensionNumber = item.ExtensionNumber;

                registerMan.Add(gomi);
            }
            return registerMan;

            
       }
       #endregion
        
        #endregion


    }
}