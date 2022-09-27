import { Component, OnInit } from '@angular/core';
import { ajax, param, type } from 'jquery';
import * as $ from 'jquery';
import { EditPerson } from './person-edit.viewmodel';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { idText } from 'typescript';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.scss']
})
export class PersonEditComponent implements OnInit {

  editPerson: EditPerson[] = [];
  //id: string;

  constructor(private router: Router,private activatedRoute: ActivatedRoute) {
    this.editPerson = this.editPerson
   }

   //初期処理：詳細表示
   //D-1.詳細表示
  ngOnInit(): void {
    //idをホーム画面から受取
    var id = null
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
       id = params.get("id");
    })
    let editPerson: EditPerson[] = [];

    //受け取るidによってURLが変わるため先に定義しておく
    var url = "https://localhost:7059/Management/Detail/"+id;

    $(function(){
      $.ajax(
        {
          async: false,
          url: url,
          type: "GET",
          dataType: "json"
        }
      )
      .done(function(data){
        //alert("EditDone")
        editPerson.push({
          StaffNumber: data.staffNumber,
          StaffName: data.staffName,
          CompanyID: data.companyID,
          CompanyName: data.companyName,
          DepartmentID: data.departmentID,
          DepartmentName: data.departmentName,
          ExtensionNumber: data.extensionNumber,
          Memo: data.memo
        })
      })
      .fail(function(){
        window.alert("ERROR:データベースと接続できませんでした")
      })
    })
  this.editPerson = editPerson;
  }

  //D-2.削除ボタン
  //削除機能
  DeleteClick(id: number):void{
    //alert(id);
    var deleteConfirm = confirm("削除してもよろしいでしょうか");
    var aurl = "https://localhost:7059/Management/Delete/"+id;
    const that = this
    if(deleteConfirm == true){
      $(function(){
        $.ajax({
          async: false,
          url: aurl,
          type: "GET",
          //dataType:"json"
          //contentType: "application/json"
        })
        .done(function(){
          alert("削除しました")
          that.router.navigate(["/home"])
          //tsconfig.jsonの"noImplicitThis": false
        })
        .fail(function(XMLHttpRequest, textStatus, errorThrown){
          console.log(XMLHttpRequest.status);
          console.log(textStatus);
          console.log(errorThrown);
          alert("ERROR")

        })
      })
    }else{
      alert("削除を取りやめました")
    }

  }

  //D-3.編集ボタン
  EditClick(staffNumber:number):void{
    //idを編集画面に渡して遷移する
    this.router.navigate(["/person-real-editing"],{queryParams:{id:staffNumber} })
   }

}
