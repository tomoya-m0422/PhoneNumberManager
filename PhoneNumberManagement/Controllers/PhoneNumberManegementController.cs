using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneNumberManagement.Models;
using PhoneNumberManagement.Services;

namespace PhoneNumberManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumberManegementController : ControllerBase
    {
        public PhoneNumberManagementViewModel FirstController()
        {
            var result = new PhoneNumberManagementViewModel();
            var Service = new PhoneNumberManagementService();

            Service = Service.FirstService();
            //Dto→ViewModelの詰め替え
            //foreach的なやつかく

            foreach (var entity in Service)
            {
                result = Service;
            }

            return result;
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