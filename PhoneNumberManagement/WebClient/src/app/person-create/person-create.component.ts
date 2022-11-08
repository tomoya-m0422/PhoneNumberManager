import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { data, post } from 'jquery';
import { CompanyViewModel } from './CompanyViewModel';
import { DepartmentViewModel } from './DepartmentViewModel';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.scss']
})

export class PersonCreateComponent implements OnInit {

  constructor() { }

  companyViewModel: CompanyViewModel[] = [];
  departmentViewModel: DepartmentViewModel[] = [];
  selectedCompanyID: string| undefined;
  selectedDepartmentID: string| undefined;

  emailFormControl = new FormControl('', [Validators.required, Validators.email]);

  ngOnInit(): void {
    let departmentViewModel: DepartmentViewModel[] = [];
    let companyViewModel: CompanyViewModel[] = [];
    //初期処理

    //C-1.会社欄
    $(function(){
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management/Company",
          type: "get",
          dataType: "json",
        })
      .done(function(data){
        $.each(data,function(index,item){
          companyViewModel.push({
            CompanyID : item.companyID,
            CompanyName : item.companyName
          })
        })
      })
      .fail(function(){
        window.alert("ERROR:会社欄");
      })
    })
    this.companyViewModel = companyViewModel;
    //C-2.部署欄
    $(function(){
      $.ajax({
        async:false,
        url:"https://localhost:7059/Management/Department",
        type: "get",
        dataType: "json"
      })
      .done(function(data){
        $.each(data,function(index,item){
          departmentViewModel.push({
            DepartmentID : item.departmentID,
            DepartmentName: item.departmentName
          })
        })
      })
      .fail(function(){
        alert("EERROR:部署の検索欄")
      })
    })
    this.departmentViewModel = departmentViewModel;

  }

  //C-3.登録ボタン
  //登録ボタンを押下したときの処理
  StaffRedister() :void {

    //HTMLで記入したデータを変数に格納
    var staffName = $("#Name").val()
    var companyID = $("#Company").val()
    var departmentID = $("#Department").val()
    var ExectionNumber = $("#ExectionNumber").val()
    var Memo = $("#Memo").val()

    //alert(staffName)
    //alert(companyID)
    //alert(departmentID)

    //上記の変数をリスト型に変換
    var registerInfo = {
      "StaffName":staffName,
      "CompanyID":companyID,
      "DepartmentID":departmentID,
      "ExtensionNumber":ExectionNumber,
      "Memo":Memo
    };

    //リストをBEに渡すためにJSONに変換
    var registerJson = JSON.stringify(registerInfo)
    console.log(registerJson)

    $(function(){
      $.ajax({
        async: true,
        url: "https://localhost:7059/Management/register",
        type: "Post",
        data: registerJson,
        //dataType:"json",
        contentType: 'application/json',
      })

      .done(function(){
        alert(staffName+"さんを作成しました")
      })

      .fail(function(XMLHttpRequest, textStatus, errorThrown){
        alert("ERROR:社員登録を行うことができませんでした")
        // console.log(XMLHttpRequest.status);
        // console.log(textStatus);
        // console.log(errorThrown);
      })
    })
  }
}
