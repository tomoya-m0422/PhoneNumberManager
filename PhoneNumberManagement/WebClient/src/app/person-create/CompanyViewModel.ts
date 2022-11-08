export class CompanyViewModel{
  constructor(
    CompanyID:number,
    CompanyName:string
  ){
    this.CompanyID = CompanyID;
    this.CompanyName = CompanyName;
  }
  public CompanyID: number;
  public CompanyName: string;
}
