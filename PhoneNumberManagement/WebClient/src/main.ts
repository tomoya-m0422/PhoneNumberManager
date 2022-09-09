import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

import { AppModule } from './app/app.module';
import { environment } from './environments/environment';
import * as $ from 'jquery'
if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));



//#region  確認用
/*
// 1. Select the div element using the id property
const app = document.getElementById("app");
// 2. Create a new <p></p> element programmatically
const p = document.createElement("p");
// 3. Add the text content
p.textContent = "Hello, TypeScript!";
// 4. Append the p element to the div element
app?.appendChild(p);
*/
//#endregion

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
        $.each(data,function(index,item){
          $("#table").append
          (
            "<tr>"+
            "<td class='Name' data-id="+item.staffNumber+">"+item.staffName+"</td>"+
            "<td>"+item.companyName+"</td>"+
            "<td>"+item.departmentName+"</td>"+
            "<td>"+item.extensionNumber+"</td>"+
            "<td>"+item.memo+"</td>"+
            "<td><button class = 'button' data-id="+item.staffNumber+"> 詳細　</button></td>"+
            "</tr>"
          )

        }
        )

        //TS-1.詳細表示の処理
        $(".Name , .button").on('click',function(){
          var staffNumber =  $(this).data('id');
          alert(staffNumber)
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
