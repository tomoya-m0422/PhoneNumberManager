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
    $(function(){
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management",
          type: "get",
          dataType: "json",
        }
      )
      .done(function(data){
        //会社と部署の欄の作成
        $.each(data,function(index,item){
          $("#CompanyList").append
          ("<option class='companyID' id="+item.companyID+" value='"+item.companyName+"'>")

          $("#DepartmentList").append
          ("<option class='departmentID' id="+item.departmentID+" value='"+item.departmentName+"'>")
        })

      })
      .fail(function(){
        window.alert("ERROR");
      })
    })
  }

  StaffRedister() :void {
    var staffName = $("#staffName").val()
    var companyID = $(".companyID").attr("id")
    var departmentID = $(".departmentID").attr("id")
    var ExectionNumber = $("#ExectionNumber").val()
    var Memo = $("#memo").val()
    var registerInfo = {
      "StaffName":staffName,
      "CompanyID":companyID,
      "DepartmentID":departmentID,
      "ExtensionNumber":ExectionNumber,
      "Memo":Memo
  };
    var registerJson = JSON.stringify(registerInfo)
    console.log(registerJson)

    $(function(){
      $.ajax({
        async: true,
        url: "https://localhost:7059/Management/register",
        type: "Post",
        data:registerJson,
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
        alert(staffName+"作成しました")
      })
      .fail(function(XMLHttpRequest, textStatus, errorThrown){
        alert("ERROR")
        console.log(XMLHttpRequest.status);
        console.log(textStatus);
        console.log(errorThrown);
      })
    })

  }

}
