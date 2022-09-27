import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { data, post } from 'jquery';

@Component({
  selector: 'app-person-create',
  templateUrl: './person-create.component.html',
  styleUrls: ['./person-create.component.scss']
})
export class PersonCreateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    //初期処理

    //C-1.会社欄
    $(function(){
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management/Company",
          type: "get",
          dataType: "json",
        }
      )
      .done(function(data){
        $.each(data,function(index,item){
          $("#CompanySelect").append
          ("<option class='CompanyID' id='"+item.companyID+"' value='"+item.companyID+"'>"+item.companyID+":"+item.companyName+"</option>")
        })

      })
      .fail(function(){
        window.alert("ERROR:会社欄");
      })
    })

    //C-2.部署欄
    $(function(){
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management/Department",
          type: "get",
          dataType: "json",
        }
      )
      .done(function(data){
        //会社と部署の欄の作成
        $.each(data,function(index,item){
          $("#DepartmentSelect").append
          ("<option class='DepartmentID' value='"+item.departmentID+"'>"+item.departmentID+":"+item.departmentName+"</option>")
        })

      })
      .fail(function(){
        window.alert("ERROR:部署欄");
      })
    })

  }

  //C-3.登録ボタン
  //登録ボタンを押下したときの処理
  StaffRedister() :void {

    //HTMLで記入したデータを変数に格納
    var staffName = $("#staffName").val()
    var companyID = $("#CompanySelect").val()
    var departmentID = $("#DepartmentSelect").val()
    var ExectionNumber = $("#ExectionNumber").val()
    var Memo = $("#memo").val()

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
        // "crossDomain":true,
        // "headers":{
        //   "accept": "application/json",
        //   "Access-Control-Allow-Origin":"*"
        // }
        //  xhrFields: {
        //    withCredentials: true,
        //    X-Requested-With : 'XMLHttpRequest'
        // }
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
