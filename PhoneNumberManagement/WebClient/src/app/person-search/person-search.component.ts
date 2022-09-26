import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { Router, UrlHandlingStrategy } from '@angular/router';
import { ManagementPerson } from './SearchPerson.viewmodel';
import { isArrayLiteralExpression } from 'typescript';
import { type } from 'jquery';

@Component({
  selector: 'app-person-search',
  templateUrl: './person-search.component.html',
  styleUrls: ['./person-search.component.scss']
})
export class PersonSearchComponent implements OnInit {

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

   //未完成
   SearchClick() :void{
    this.router.navigate(["/person-search"]);
   }


  ngOnInit(): void {
    let managementPerson: ManagementPerson[]= [];

    $(function(){
      $.ajax(
        {
          async: false,
          url: "https://localhost:7059/Management/Search",
          type: "get",
          dataType: "json"
        }
      )
      .done(function(data){
        alert("どーん")
        $.each(data,function(index,item){
          $("#NameList").append
          ("<option value='"+item.staffName+"'>")
        })
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
          ('<option value="'+item.departmentName+'">')
        })
      })
      .fail(function(){
        alert("EERROR:部署の検索欄")
      })
    })
  }

}
