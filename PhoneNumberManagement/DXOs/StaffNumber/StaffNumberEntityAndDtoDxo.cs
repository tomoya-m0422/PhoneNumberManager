using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.DXOs.StaffNumber.Interface;
using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DXOs.StaffNumber
{
    public class StaffNumberEntityAndDtoDxo : IStaffNumberEntityAndDtoDxo
    {
        static MapperConfiguration entityToDtoOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<StaffNumberEntity, StaffNumberDto>();
        });

        static MapperConfiguration dtoToEntityOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<StaffNumberDto,StaffNumberEntity>();
        });

        #region List,IEnumerable以外のEntityとDtoの入れ替え
        public StaffNumberDto ExchangeEntityToDto(StaffNumberEntity staffNumberEntitys)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<StaffNumberEntity, StaffNumberDto>(staffNumberEntitys);
        }

        public StaffNumberEntity ExchangeDtoToEntity(StaffNumberDto staffNumberDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<StaffNumberDto, StaffNumberEntity>(staffNumberDtos);
        }
        #endregion

        #region List型のEntityとDtoの入れ替え
        public List<StaffNumberDto> ListExchangeEntityToDto(List<StaffNumberEntity> staffNumberEntitys)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<List<StaffNumberEntity>, List<StaffNumberDto>>(staffNumberEntitys);
        }

        public List<StaffNumberEntity> ListExchangeDtoToEntity(List<StaffNumberDto> staffNumberDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<List<StaffNumberDto>, List<StaffNumberEntity>>(staffNumberDtos);
        }
        #endregion

        #region IEnumerable型のEntityとDtoの入れ替え
        public IEnumerable<StaffNumberDto> IEnumerableExchangeEntityToDto(IEnumerable<StaffNumberEntity> staffNumberEntitys)
        {
            var mapper = entityToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<StaffNumberEntity>, IEnumerable<StaffNumberDto>>(staffNumberEntitys);
        }

        public IEnumerable<StaffNumberEntity> IEnumerableExchangeDtoToEntity(IEnumerable<StaffNumberDto> staffNumberDtos)
        {
            var mapper = dtoToEntityOverride.CreateMapper();
            return mapper.Map<IEnumerable<StaffNumberDto>, IEnumerable<StaffNumberEntity>>(staffNumberDtos);
        }
        #endregion
    }
}
