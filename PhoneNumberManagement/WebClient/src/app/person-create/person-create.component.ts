import { Component, OnInit } from '@angular/core';
import * as $ from 'jquery'
import { Router } from '@angular/router';

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
          ("<option value='"+item.companyName+"'>")

          $("#DepartmentList").append
          ("<option value='"+item.departmentName+"'>")
        })

      })
      .fail(function(){
        window.alert("ERROR");
      })
    })
  }




}
