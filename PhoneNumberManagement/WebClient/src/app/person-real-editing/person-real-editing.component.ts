import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap, Router } from '@angular/router';
import { EditPerson } from '../person-edit/person-edit.viewmodel';
import { RealEditingPerson } from './person-real-editing.viewmodel';
import * as $ from 'jquery';

@Component({
  selector: 'app-person-real-editing',
  templateUrl: './person-real-editing.component.html',
  styleUrls: ['./person-real-editing.component.scss']
})
export class PersonRealEditingComponent implements OnInit {


  realEditPerson: RealEditingPerson[] = [];
  //id: string;

  constructor(private router: Router,private activatedRoute: ActivatedRoute) {
    this.realEditPerson = this.realEditPerson
   }

  ngOnInit(): void {
    //id受取
    var id = null
    this.activatedRoute.queryParamMap.subscribe((params:ParamMap)=>{
       id = params.get("id");
    })

    let realEditPerson: RealEditingPerson[] = [];
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
        //alert("EditDone")
        realEditPerson.push({
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
  this.realEditPerson = realEditPerson;


  }

}
