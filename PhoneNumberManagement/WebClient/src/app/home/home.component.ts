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

  public managementPerson: ManagementPerson[] = [];

  constructor(private router: Router) {
    this.managementPerson = this.managementPerson;
   }


  ngOnInit(): void {
    //#region 初期処理
    $(function () {
      $.ajax(
        {
          async: true,
          url: "https://localhost:7059/Management",
          type: "get",
          dataType: "json"

        }
      )
        .done(function (data) {
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
            managementPerson.push(item)
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
    }
    )
    //#endregion

  }


}



