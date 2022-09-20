export class RealEditingPerson{
  constructor(
    StaffNumber: number,
    StaffName: string,
    CompanyID: number,
    DepartmentID: number,
    ExtensionNumber: string,
    Memo: string,
    CompanyName: string,
    DepartmentName: string
  ) {
    this.StaffNumber = StaffNumber;
    this.StaffName = StaffName;
    this.CompanyID = CompanyID;
    this.DepartmentID = DepartmentID;
    this.ExtensionNumber = ExtensionNumber;
    this.Memo = Memo;
    this.CompanyName = CompanyName;
    this.DepartmentName = DepartmentName;
  }
  public StaffNumber: number;
  public StaffName: string;
  public CompanyID: number;
  public DepartmentID: number;
  public ExtensionNumber: string;
  public Memo: string;
  public CompanyName: string;
  public DepartmentName: string;
}
