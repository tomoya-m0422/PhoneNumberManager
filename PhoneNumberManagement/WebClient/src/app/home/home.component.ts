import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { Router } from '@angular/router';
import { ManagementPerson } from './home.viewmodel';

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
          alert("done")
          //A-1.検索欄の初期処理
          $.each(data,function(index,item){
            $("#NameList").append
            ('<option value="'+item.staffName+'">')

            $("#DepartmentList").append
            ('<option value="'+item.departmentName+'">')
          })

          //A-2.一覧表示の初期処理
          //これが難しい
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
            hoge(managementPerson)
            var aaa = 0;
            moge(aaa);
          }
          )
          //TS-1.詳細表示の処理
          $(".Name , .button").on('click',function(){
            var staffNumber =  $(this).data('id');
            //HomeComponent.router.navigateByUrl("./../person-create")
          });
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

      function hoge(managementPerson: ManagementPerson){
        this.managementPerson = managementPerson
      }

    }
    )
    //#endregion
    function moge(managementPerson: ManagementPerson[]){
      this.managementPerson = managementPerson;
    }
    this.managementPerson = managementPerson;
  }

  /*
  hoge(item: any) : void {
    let res: ManagementPerson = {
      StaffNumber: item.staffNumber,
      StaffName: item.staffName,
      CompanyID: item.CompanyID,
      CompanyName: item.CompanyName,
      DepartmentID: item.DepartmentID,
      DepartmentName: item.DepartmentName,
      ExtensionNumber: item.ExtensionNumber,
      Memo: item.Memo
    }

    this.managementPerson.push(res);
  }

}
*/
