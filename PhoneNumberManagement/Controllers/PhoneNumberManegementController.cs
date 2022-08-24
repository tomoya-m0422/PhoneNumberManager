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


            result = PhoneNumberManagementService.FirstService();
            //Dtol→ViewModelの詰め替え
            //foreach的なやつかく

            foreach (var item in result)
            {

            }
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
    var phoneNumberManagementEntity = new PhoneNumberManagementEntity();
    phoneNumberManagementEntity = PerSonDao.aaaa();
    var result = new (List)phoneNumberManagementDto();
    foreach (var entity in phoneNumberManagementEntity)
    {
        entity.FirstName = result.LastName;
        entity.LastName = result.FirstName;
    }
    return result;
}
*/