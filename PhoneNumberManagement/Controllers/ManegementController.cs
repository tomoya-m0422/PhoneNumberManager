using Microsoft.AspNetCore.Mvc;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;

namespace PhoneNumberManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManegementController : ControllerBase
    {
        #region メンバー変数
        private ManagementService managementService;
        #endregion

        #region コンストラクター
        public ManegementController()
        {
            this.managementService = new ManagementService(new Logics.ManagementLogic(new DAO.ManagementDao()));
        }
        #endregion


        [HttpGet]
        public IEnumerable< ManagementViewModel> FirstDawnController()
        {
            var service = managementService.FirstDawnService();

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
    }
}

/*
// Service
public PhoneNumberManagementDto StoreService()
{
    //DB接続ぞく
    var phoneNumberManagementDto = MainLogic.Store(); 

    return phoneNumberManagementDto;
}

// Logic
public PhoneNumberManagementDto StoreLogic()
{
    //Dto→Entity    
    //Dao ←SQL
    var phoneNumberManagementEntity = new PhoneNumberManagementEntity(); //Enitityのインスタンス
    phoneNumberManagementEntity = PerSonDao.aaaa();　//DaoのやつをEntityに持ってきてる
    var result = new (List)phoneNumberManagementDto();　//Dtoのインスタンス
    foreach (var entity in phoneNumberManagementEntity) //DtoをEntityに入れてる？？？
    {
        entity.FirstName = result.LastName;
        entity.LastName = result.FirstName;
    }
    return result;
}
*/