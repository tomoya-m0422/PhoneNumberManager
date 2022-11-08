import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import {ManagementPerson} from './home.viewmodel';
import { DepartmentViewModel } from './department.viewmodel';


@Component({
  selector: 'app-home',
  templateUrl: "home.component.html",
  styleUrls: ['home.component.scss']
})

export class HomeComponent implements OnInit {

  managementPerson: ManagementPerson[] = [];
  departmentViewModel: DepartmentViewModel[] = [];
  PersonName : ManagementPerson[] = [];
  selectedNameValue: string | undefined;
  selectedDepartmentValue: string | undefined;

  constructor(private router: Router,private activatedRoute: ActivatedRoute) {
    this.managementPerson = this.managementPerson;
    this.departmentViewModel = this.departmentViewModel;
    this.PersonName = this.PersonName;
    this.router.routeReuseStrategy.shouldReuseRoute = function(){
      return false;
    };
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
    var flg = "Search";
    //alert(staffName);
    //alert(departmentName);
    //alert(memo);
    this.router.navigate(["/home"],{queryParams:{StaffName:staffName,DepartmentName:departmentName,Memo:memo,SearchFlag:flg}});
   }


  ngOnInit(): void {
    let managementPerson: ManagementPerson[] = [];
    let departmentViewModel: DepartmentViewModel[] = [];
    let PersonName: ManagementPerson[] = [];

    //全件表示か検索表示か判断するフラグを作成
    //flg == null :全件表示(初期表示)
    //flg == "Search" :検索表示(52行目からのSearchClick関数参照)
    var flg = null;
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
      flg = params.get("SearchFlag");
    })
   //console.log(flg);

    if (flg == null){
      managementPerson = this.AllSelecter()
     }else{
      managementPerson = this.SearchSelecter()
     }
     this.managementPerson = managementPerson;

    //A-1.検索欄
    //検索欄の名前の部分の処理
    $(function(){
      $.ajax({
        async:false,
        url:"https://localhost:7059/Management",
        type: "get",
        dataType: "json"
      })
      .done(function(data){
         $.each(data,function(index,item){
          PersonName.push({
            StaffNumber: item.staffNumber,
            StaffName: item.staffName,
            CompanyID: item.companyID,
            CompanyName: item.companyName,
            DepartmentID: item.departmentID,
            DepartmentName: item.departmentName,
            ExtensionNumber: item.extensionNumber,
            Memo: item.memo
          })
         })
      })
      .fail(function(){
        alert("ERORR:名前の検索欄")
      })
    })
    this.PersonName = PersonName;

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

  //データを全件取得する関数
  AllSelecter():ManagementPerson[]{
    let managementPerson: ManagementPerson[] = [];
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
    return managementPerson;
  }

  //検索データを取得する関数
  SearchSelecter():ManagementPerson[]{
    let managementPerson: ManagementPerson[]= [];
    let PersonName : ManagementPerson[] = [];
    let departmentViewModel: DepartmentViewModel[] = [];

    var staffName = null
    var departmentName = null
    var memo = null
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
       staffName = params.get("StaffName");
       departmentName = params.get("DepartmentName");
       memo = params.get("Memo");
    })

    var searchInfo = {
      "StaffName" : staffName,
      "DepartmentName" : departmentName,
      "Memo" : memo
    };

    var searchJson = JSON.stringify(searchInfo);
    console.log(searchJson);

    $(function(){
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management/Search",
          type: "post",
          data: searchJson,
          contentType: 'application/json',
          dataType: "json"
        }
      )
      .done(function(data){
        // $.each(data,function(index,item){
        //   $("#NameList").append
        //   ("<option value='"+item.staffName+"'>")
        // })

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
        })
      })
      .fail(function(){
        window.alert("ERROR:データベースと接続できませんでした");
      })
    })
    this.managementPerson = managementPerson;
    return managementPerson
  }

  //テストボタン
  // TestButton(): void{
  //   $.ajax({
  //     type: "GET",
  //     url:"https://localhost:7059/Management/TestButton",
  //     data:"json"
  //   })
  //   .done(function(data){
  //     alert(data)
  //     console.log(data)
  //   })
  //   .fail(function(){
  //     alert("むり")
  //   })
  // }

}

