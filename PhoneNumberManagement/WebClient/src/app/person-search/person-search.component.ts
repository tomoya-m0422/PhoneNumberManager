import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { ActivatedRoute, ParamMap, Router, UrlHandlingStrategy } from '@angular/router';
import { ManagementPerson } from './SearchPerson.viewmodel';
import { isArrayLiteralExpression } from 'typescript';

@Component({
  selector: 'app-person-search',
  templateUrl: './person-search.component.html',
  styleUrls: ['./person-search.component.scss']
})
export class PersonSearchComponent implements OnInit {

  managementPerson: ManagementPerson[] = [];

  constructor(private router: Router,private activatedRoute: ActivatedRoute) {
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
    var departmentID = $(".depatmentabc").attr("id");
    var memo = $("#Memo").val();
    this.router.navigate(["/person-search"],{queryParams:{StaffName:staffName,DepartmentID:departmentID,Memo:memo}});
   }


  ngOnInit(): void {
    let managementPerson: ManagementPerson[]= [];

    var staffName = null
    var departmentID = null
    var memo = null
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
       staffName = params.get("StaffName");
       departmentID = params.get("DepartmentID");
       memo = params.get("Memo");
    })

    var searchInfo = {
      "StaffName" : staffName,
      "CompanyID" : departmentID,
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
          ('<option class= "depatmentabc" id="'+item.departmentID+'" value="'+item.departmentName+'">')
        })
      })
      .fail(function(){
        alert("ERROR:部署の検索欄")
      })
    })

    $(function(){
      $.ajax({
        async:false,
        url:"https://localhost:7059/Management",
        type:"get",
        dataType:"json"
      })
      .done(function(data){
        $.each(data,function(index,item){
          $("#NameList").append
          ('<option value="'+item.staffName+'">')
        })
      })
      .fail(function(){
        alert("ERROR:名前の検索欄")
      })
    })
  }

}
