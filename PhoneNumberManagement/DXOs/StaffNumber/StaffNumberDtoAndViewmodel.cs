using AutoMapper;
using PhoneNumberManagement.DTO;
using PhoneNumberManagement.Models;

namespace PhoneNumberManagement.DXOs.StaffNumber
{
    public class StaffNumberDtoAndViewmodel
    {
        static MapperConfiguration dtoToViewmodelOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<StaffNumberDto, StaffNumberViewModel>();
        });

        static MapperConfiguration viewmodelToDtoOverride = new MapperConfiguration(cgf =>
        {
            cgf.CreateMap<StaffNumberViewModel, StaffNumberDto>();
        });

        #region List,IEnumerable型以外のViewModelとDTOの入れ替え処理
        public StaffNumberViewModel ExchangeDtoToViewmodel (StaffNumberDto staffNumberDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<StaffNumberDto,StaffNumberViewModel>(staffNumberDtos);
        }

        public StaffNumberDto ExchangeViewmodelToDto (StaffNumberViewModel staffNumberViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<StaffNumberViewModel,StaffNumberDto>(staffNumberViewModels); 
        }
        #endregion

        #region List型のViewModelとDTOの入れ替え処理
        public List<StaffNumberViewModel> ExchangeDtoToViewmodel(List<StaffNumberDto> staffNumberDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<List<StaffNumberDto>, List<StaffNumberViewModel>>(staffNumberDtos);
        }

        public List<StaffNumberDto> ExchangeViewmodelToDto(List<StaffNumberViewModel> staffNumberViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<List<StaffNumberViewModel>, List<StaffNumberDto>>(staffNumberViewModels);
        }
        #endregion

        #region IEnumerable型のViewModelとDTOの入れ替え処理
        public IEnumerable<StaffNumberViewModel> ExchangeDtoToViewmodel(IEnumerable<StaffNumberDto> staffNumberDtos)
        {
            var mapper = dtoToViewmodelOverride.CreateMapper();
            return mapper.Map<IEnumerable<StaffNumberDto>, IEnumerable<StaffNumberViewModel>>(staffNumberDtos);
        }

        public IEnumerable<StaffNumberDto> ExchangeViewmodelToDto(IEnumerable<StaffNumberViewModel> staffNumberViewModels)
        {
            var mapper = viewmodelToDtoOverride.CreateMapper();
            return mapper.Map<IEnumerable<StaffNumberViewModel>, IEnumerable<StaffNumberDto>>(staffNumberViewModels);
        }
        #endregion

    }
}
