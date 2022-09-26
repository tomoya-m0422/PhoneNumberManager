import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { Router } from '@angular/router';
import { ManagementPerson } from './home.viewmodel';
import { isArrayLiteralExpression } from 'typescript';
import { type } from 'jquery';

@Component({
  selector: 'app-home',
  templateUrl: "home.component.html",
  styleUrls: ['home.component.scss']
})

export class HomeComponent implements OnInit {

  managementPerson: ManagementPerson[] = [];

  constructor(private router: Router) {
    this.managementPerson = this.managementPerson
   }

   DetailClick(staffNumber:number): void{
    //alert("DetailClickできた!!")
    this.router.navigate(['/person-edit'],{queryParams:{id:staffNumber} })
    //this.router.navigate(['/products'], { queryParams: { order: 'popular' } });
   }

   EditClick(staffNumber:number):void{
    this.router.navigate(["/person-real-editing"],{queryParams:{id:staffNumber} })
   }

   SearchClick() :void{
    var staffName = $("#Name").val();
    var departmentID = $(".depatmentabc").attr("data-id");
    var memo = $("#Memo").val();
    alert(departmentID);
    //this.router.navigate(["/person-search"],{queryParams:{StaffName:staffName,DepartmentID:departmentID,Memo:memo}});
   }

  ngOnInit(): void {
    let managementPerson: ManagementPerson[] = [];
    //#region 初期処理
    $(function () {
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management",
          type: "get",
          dataType: "json",

        }
      )
        .done(function (data) {
          //alert("done")
          //A-1.検索欄の初期処理
          $.each(data,function(index,item){
            $("#NameList").append
            ('<option value="'+item.staffName+'">')
          })

          //A-2.一覧表示の初期処理
          $.each(data,function(index,item){
            managementPerson.push({
              StaffNumber: item.staffNumber,
              StaffName: item.staffName,
              CompanyID: item.companyID,
              CompanyName: item.companyName,
              DepartmentID: item.departmentID,
              DepartmentName: item.departmentName,
              ExtensionNumber: item.extensionNumber,
              Memo: item.memo
            })
          }
          )
        }
        )

        .fail(function () {
          window.alert("ERROR:データベースと接続できませんでした");
          $("#table").append
          (
            "<tr><td colspan='6'>データベースと接続できませんでした</td></tr>"
          )
        }
        )
    }
    )

    this.managementPerson = managementPerson;
    //検索欄の部署の部分の処理
    $(function(){
      $.ajax({
        async:false,
        url:"https://localhost:7059/Management/Department",
        type: "get",
        dataType: "json"
      })
      .done(function(data){
        $.each(data,function(index,item){
          $("#DepartmentList").append
          ('<option class= "depatmentabc" data-id="'+item.departmentID+'" value="'+item.departmentName+'">')
        })
      })
      .fail(function(){
        alert("EERROR:部署の検索欄")
      })
    })
  }
  //#endregion

  TestButton(): void{
    $.ajax({
      type: "GET",
      url:"https://localhost:7059/Management/TestButton",
      data:"json"
    })
    .done(function(data){
      alert(data)
      console.log(data)
    })
    .fail(function(){
      alert("むり")
    })
  }

}

