using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;

namespace PhoneNumberManagement.Logics

{
    public class PhoneNumberManagementLogic : IPhoneNumberManagementLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        #endregion 

        #region コンストラクタ
        public PhoneNumberManagementLogic(IManagementDao managementDao)
        {
            this.managementDao = managementDao;
        }
        #endregion 


        public IEnumerable<PhoneNumberManagementDto> FirstLogic()
        {
            //DaoにSQLServerからデータを取ってくるように指示したあとDaoResultにデータを入れる
            var entity = managementDao.FirstConnect();

            var result = setPhoneNumberManagementDto(entity);

            return result;
        }

        public IEnumerable<PhoneNumberManagementDto> setPhoneNumberManagementDto(IEnumerable<PhoneNumberManagementEntity> entities)
        {
            var dtos = new List<PhoneNumberManagementDto>();

            foreach (var entity in entities)
            {
                foreach(var dto in dtos)
                {
                    dto.StaffNumber = entity.StaffNumber;
                    dto.StaffName = entity.StaffName;
                    dto.DepartmentName = entity.DepartmentName;
                    dto.ExtensionNumber = entity.ExtensionNumber;
                    dto.CompanyName = entity.CompanyName;
                    dto.Memo = entity.Memo;
                }
            }
            return dtos;
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