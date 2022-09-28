﻿using PhoneNumberManagement.Entity;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DAO;
using System.Data.SqlClient;
using PhoneNumberManagement.DXO.Management;

namespace PhoneNumberManagement.Logics

{
    public class ManagementLogic : IManagementLogic
    {
        #region メンバー変数
        private IManagementDao managementDao;
        private ManagementEntityToDto entityToDto;
        #endregion 

        #region コンストラクタ
        public ManagementLogic()
        {
            this.managementDao = new ManagementDao();
            this.entityToDto = new ManagementEntityToDto();
        }
        #endregion 


        public IEnumerable<ManagementDto> FirstLogic(SqlConnection connection)
        {
            //DaoにSQLServerからデータを取ってくるように指示したあとenetityにデータを入れる
            var entity = managementDao.FirstConnect(connection);
            //var result = setPhoneNumberManagementDto(entity);
            var result = entityToDto.IEnumerableExchangeEntityToDto(entity);
            return result;
        }


        /*
        public IEnumerable<ManagementDto> setPhoneNumberManagementDto(IEnumerable<ManagementEntity> entities)
        {
            var dtos = new List<ManagementDto>();

            foreach (var entity in entities)
            {
                var dto = new ManagementDto();
                
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
        */
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