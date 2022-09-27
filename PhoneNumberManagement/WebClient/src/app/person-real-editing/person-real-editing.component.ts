import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { RealEditingPerson } from './person-real-editing.viewmodel';
import * as $ from 'jquery';
import { Location } from '@angular/common';

@Component({
  selector: 'app-person-real-editing',
  templateUrl: './person-real-editing.component.html',
  styleUrls: ['./person-real-editing.component.scss']
})
export class PersonRealEditingComponent implements OnInit {


  realEditPerson: RealEditingPerson[] = [];
  //id: string;

  constructor(private router: Router,private activatedRoute: ActivatedRoute,private location: Location) {
    this.realEditPerson = this.realEditPerson
   }


  ngOnInit(): void {
    //id受取
    var id = null
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
       id = params.get("id");
    })

    let realEditPerson: RealEditingPerson[] = [];
    //idによってURLが変わるため先に定義
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
        //社員情報をViewModel型にする
        realEditPerson.push({
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
  this.realEditPerson = realEditPerson;

  //会社取得
  $(function(){
    $.ajax({
      async: false,
      url: "https://localhost:7059/Management/Company",
      type: "GET",
      dataType: "json"
    })
    .done(function(data){
      $.each(data,function(index,item){
        $("#CompanySelect").append
        ("<option class='CompanyID' id='"+item.companyID+"' value='"+item.companyID+"'>"+item.companyID+":"+item.companyName+"</option>")
      })
    })
    .fail(function(){
      alert("ERROR:会社データ取得")
    })
  })

  //部署取得
  $(function(){
    $.ajax({
      async: false,
      url: "https://localhost:7059/Management/Department",
      type: "GET",
      dataType: "json"
    })
    .done(function(data){
      $.each(data,function(index,item){
      $("#DepartmentSelect").append
      ("<option class='DepartmentID' value='"+item.departmentID+"'>"+item.departmentID+":"+item.departmentName+"</option>")
      })
    })

  })
  }

  //更新ボタン処理
  updatingButton(): void{
    //alert("ok")
    //HTMLで記入した情報を変数に格納している
    var staffNumber = $("#StaffNumber").text().trim() //←idに空白があるためtrimで空白を削除
    var staffName = $("#StaffName").val()
    var companyID = $("#CompanySelect").val()
    var departmentID = $("#DepartmentSelect").val()
    var extensionNumber = $("#ExtensionNumber").val()
    var memo = $("#Memo").val()
    //alert(memo);
    //上記のデータをリスト型にしている
    var updatingData = {
      "staffNumber":staffNumber,
      "staffName":staffName,
      "companyID":companyID,
      "departmentID":departmentID,
      "extensionNumber":extensionNumber,
      "memo":memo
    }
    //データをBEに送るためにリストデータをJSONに変換
    var updatingJson = JSON.stringify(updatingData)
    console.log(updatingJson)

    $(function(){
      $.ajax({
        async: false,
        url:"https://localhost:7059/Management/edit",
        type: "POST",
        data: updatingJson,
        contentType: 'application/json'
      })
      .done(function(){
        alert("更新しました")
      })
      .fail(function(){
        alert("ERROR")
      })
    })

  }

  //戻るボタン
  backButton(): void{
    this.location.back();
  }

  alertButton(): void{
    alert("IDは変更できません")
  }

}
