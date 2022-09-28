import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { ActivatedRoute, ParamMap, Router, UrlHandlingStrategy } from '@angular/router';
import { ManagementPerson } from './SearchPerson.viewmodel';
import { isArrayLiteralExpression } from 'typescript';
import { DepartmentViewModel } from './SearchPersonDepartment.ViewModel';
import { type } from 'jquery';

@Component({
  selector: 'app-person-search',
  templateUrl: './person-search.component.html',
  styleUrls: ['./person-search.component.scss']
})
export class PersonSearchComponent implements OnInit {

  managementPerson: ManagementPerson[] = [];
  departmentViewModel: DepartmentViewModel[] = [];
  PersonName : ManagementPerson[] = [];
  depertment: any;

  constructor(private router: Router,private activatedRoute: ActivatedRoute) {
    this.managementPerson = this.managementPerson;
    this.departmentViewModel = this.departmentViewModel;
    this.PersonName = this.PersonName;
    this.router.routeReuseStrategy.shouldReuseRoute = function(){
      return false;
    };
   }

   //削除ボタンの処理
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
    // alert(staffName);
    // alert(departmentName);
    // alert(memo);
    this.router.navigate(["/person-search"],{queryParams:{StaffName:staffName,DepartmentName:departmentName,Memo:memo}});
   }



  ngOnInit(): void {
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
        alert("ERROR:部署の検索欄")
      })
    })
    this.departmentViewModel = departmentViewModel;

  }

}
