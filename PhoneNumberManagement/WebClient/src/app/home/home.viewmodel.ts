export class ManagementPerson {
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

//datamodelBaseを継承しないといけない

/*
//Jsonをmodelにする
class DataModelBase {
  /**
   * Jsonからモデルのインスタンスを生成する
   * @param jsonArray
   * @param cls
   */
  /*
  public static fillFromJsons<T extends DataModelBase>(
    jsonArray: Array<JSON>,
    cls: typeof DataModelBase
  ): Array<T> {
    var array: Array<DataModelBase> = new Array<DataModelBase>();
    var dataCount = jsonArray == null ? 0 : jsonArray.length;
    for (var i = 0; i < dataCount; i++) {
      var json = jsonArray[i];
      var model = new cls();
      for (var propName in json) {
        model[propName as keyof DataModelBase] = json[propName as keyof JSON];
        //model[keyof typeof propName] = json[keyof typeof propName];
      }
      array.push(model);
    }
    return <Array<T>>array;
  }
}

*/
