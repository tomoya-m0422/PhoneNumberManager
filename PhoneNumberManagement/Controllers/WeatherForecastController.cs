/*

using Microsoft.AspNetCore.Mvc;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;

namespace PhoneNumberManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        #region メンバー変数
        private ManagementService managementService;
        #endregion

        private readonly ILogger<WeatherForecastController> _logger;

        #region コンストラクタ
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            //this.managementService = new ManagementService(new Logics.ManagementLogic(new DAO.ManagementDao()));
        }
        #endregion

        //#region コンストラクター
        //public ManagementController(ManagementService ManagementService)
        //{
        //    this.managementService = ManagementService;
        //}
        //#endregion

        [HttpGet]
        public IEnumerable<CompanyViewModel> Get()
        //public string Get()
        {
            var service = managementService.FirstService();
            var result = setCompanyViewModel(service);
            return service;

        }


        public IEnumerable<CompanyViewModel> setCompanyViewModel(IEnumerable<ManagementDto> DTO)
        {
            var viewModels = new List<CompanyViewModel>();
            foreach (var items in DTO)
            {
                var gomi = new CompanyViewModel();

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
    }
}
*/