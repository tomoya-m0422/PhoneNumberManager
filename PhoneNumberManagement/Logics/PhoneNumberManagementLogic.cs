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


        public IEnumerable<PhoneNumberManagementDto> FirstDawnLogic()
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
                var dto = new PhoneNumberManagementDto();
                
                dto.StaffNumber = entity.StaffNumber;
                dto.StaffName = entity.StaffName;
                dto.CompanyID = entity.CompanyID;
                dto.DepartmentID = entity.DepartmentID;
                dto.ExtensionNumber = entity.ExtensionNumber;
                dto.Memo = entity.Memo;
                dto.DepartmentName = entity.DepartmentName;
                dto.CompanyName = entity.CompanyName;

                dtos.Add(dto);
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