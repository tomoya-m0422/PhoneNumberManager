using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;

namespace PhoneNumberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberManegementController : ControllerBase
    {
        #region メンバー変数
        private PhoneNumberManagementService managementService;
        #endregion

        #region コンストラクター
        public PhoneNumberManegementController(PhoneNumberManagementService phoneNumberManagementService)
        {
            this.managementService = phoneNumberManagementService;
        }
        #endregion

        public IEnumerable< PhoneNumberManagementViewModel> FirstDawnController()
        {
            var service = managementService.FirstDawnService();

            var result = setManagementViewModel(service);

            return result;
        }



        public IEnumerable<PhoneNumberManagementViewModel> setManagementViewModel(IEnumerable<PhoneNumberManagementDto> DTO)
        {
            var viewModels = new List<PhoneNumberManagementViewModel>();
            foreach (var items in DTO)
            {
                var gomi = new PhoneNumberManagementViewModel();

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