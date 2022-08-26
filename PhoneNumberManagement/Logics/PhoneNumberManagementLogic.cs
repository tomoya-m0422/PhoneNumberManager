using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;
using System.Collections.Generic;

namespace PhoneNumberManagement.Logics

{
    public class PhoneNumberManagementLogic : IPhoneNumberManagementLogic
    {
        public IEnumerable<PhoneNumberManagementDto> FirstLogic()
        {
            //DaoにSQLServerからデータを取ってくるように指示したあとDaoResultにデータを入れる
            var Dao = new ManagementDao();
            var DaoResult = Dao.FirstConnect();


            var phoneNumberManagementEntity = new List<PhoneNumberManagementEntity>();
            


            var result = new List<PhoneNumberManagementDto>();
            foreach(var item in DaoResult)
            {
                result.Add(item);
            }
            return result;
        }
    }
}

/*
// Logic
public PhoneNumberManagementDto StoreLogic()
{
    //Dto→Entity    
    //Dao ←SQL
    var phoneNumberManagementEntity = new PhoneNumberManagementEntity(); //Enitityのインスタンス
    phoneNumberManagementEntity = PerSonDao.aaaa();　//DaoのやつをEntityに持ってきてる
    var result = new(List)phoneNumberManagementDto();　//Dtoのインスタンス
    foreach (var entity in phoneNumberManagementEntity) //DtoをEntityに入れてる？？？
    {
        entity.FirstName = result.LastName;
        entity.LastName = result.FirstName;
    }
    return result;
}
*/