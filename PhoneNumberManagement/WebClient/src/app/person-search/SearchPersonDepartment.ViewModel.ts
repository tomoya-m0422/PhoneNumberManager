export class DepartmentViewModel{
  constructor(
    DepartmentID:number,
    DepartmentName:string
  ){
    this.DepartmentID = DepartmentID;
    this.DepartmentName = DepartmentName;
  }
  public DepartmentID: number;
  public DepartmentName: string;
}
