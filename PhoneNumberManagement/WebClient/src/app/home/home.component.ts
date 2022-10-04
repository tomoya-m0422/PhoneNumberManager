import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { Router } from '@angular/router';
import {ManagementPerson} from './home.viewmodel';
import { isArrayLiteralExpression } from 'typescript';
import { type } from 'jquery';
import { DepartmentViewModel } from './department.viewmodel';
import {AfterViewInit, ViewChild} from '@angular/core';
import {MatPaginator} from '@angular/material/paginator';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';

@Component({
  selector: 'app-home',
  templateUrl: "home.component.html",
  styleUrls: ['home.component.scss']
})

export class HomeComponent implements OnInit {

  managementPerson: ManagementPerson[] = [];
  departmentViewModel: DepartmentViewModel[] = [];
  depertment: any;
  selectedValue: string | undefined;
  displayedColumns: string[] = ['名前', '会社名', '部署名', '内線番号',"メモ"];


  constructor(private router: Router) {
    this.managementPerson = this.managementPerson;
    this.departmentViewModel = this.departmentViewModel;
   }

   //詳細ボタンの処理
   DetailClick(staffNumber:number): void{
    //alert("DetailClickできた!!")
    this.router.navigate(['/person-edit'],{queryParams:{id:staffNumber} })
    //this.router.navigate(['/products'], { queryParams: { order: 'popular' } });
   }

   //編集ボタンの処理
   EditClick(staffNumber:number):void{
    this.router.navigate(["/person-real-editing"],{queryParams:{id:staffNumber} })
   }

   //検索ボタンの処理
   SearchClick() :void{
    var staffName = $("#Name").val();
    var departmentName = $("#Department").val();
    var memo = $("#Memo").val();
    //alert(staffName);
    //alert(departmentName);
    //alert(memo);
    this.router.navigate(["/person-search"],{queryParams:{StaffName:staffName,DepartmentName:departmentName,Memo:memo}});
   }


  ngOnInit(): void {
    let managementPerson: ManagementPerson[] = [];
    let departmentViewModel: DepartmentViewModel[] = [];
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

    //A-1.検索欄
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
  //#endregion

  //テストボタン
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

