using PhoneNumberManagement.Entity;

namespace PhoneNumberManagement.DTO
{
    public class ManagementDto
    {
        public int StaffNumber { get; set; }
        public string StaffName { get; set; }
        public int CompanyID { get; set; }
        public int DepartmentID { get; set; }
        public string ExtensionNumber { get; set; }
        public string Memo { get; set; }
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }

        //public static explicit operator ManagementDto(ManagementEntity v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}