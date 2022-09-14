import { Component, OnInit } from '@angular/core';
import { ajax, param, type } from 'jquery';
import * as $ from 'jquery';
import { EditPerson } from './person-edit.viewmodel';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { idText } from 'typescript';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.scss']
})
export class PersonEditComponent implements OnInit {

  editPerson: EditPerson[] = [];
  //id: string;

  constructor(private router: Router,private activatedRoute: ActivatedRoute) {
    this.editPerson = this.editPerson

   }

  ngOnInit(): void {
    var id = null
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
       id = params.get("id");
    })

    //this.activatedRoute.params.subscribe(params=>(this.id = params["id"]))
    let editPerson: EditPerson[] = [];
    var url = "https://localhost:7059/Management/Detail/"+id;
    $(function(){
      $.ajax(
        {
          async: false,
          url: url,
          type: "GET",
          dataType: "json"
        }
      )
      .done(function(data){
        alert("EditDone")
        editPerson.push({
          StaffNumber: data.staffNumber,
          StaffName: data.staffName,
          CompanyID: data.companyID,
          CompanyName: data.companyName,
          DepartmentID: data.departmentID,
          DepartmentName: data.departmentName,
          ExtensionNumber: data.extensionNumber,
          Memo: data.memo
        })
      })
      .fail(function(){
        window.alert("ERROR:データベースと接続できませんでした")
      })
    })
  this.editPerson = editPerson;
  }

}
