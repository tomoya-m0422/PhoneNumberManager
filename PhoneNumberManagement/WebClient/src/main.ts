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

  // 1. Select the div element using the id property
const app = document.getElementById("app");
// 2. Create a new <p></p> element programmatically
const p = document.createElement("p");
// 3. Add the text content
p.textContent = "Hello, World!";
// 4. Append the p element to the div element
app?.appendChild(p);

$.ajax({
  url: "https://localhost:7059/Management",
  type: "GET"
})
.done(function(data){
  $("#result").appendTo(data)
})
.fail(function(){
  window.alert("無理");
})

/*
$(function() {
    $.ajax(
      {
        async: true,
        url: "https://localhost:7059/Management",
        type: "get",
      }
    )
    // 検索成功時にはページに結果を反映
    .done(function(data) {
      // 結果リストをクリア
      $('#result').empty();
      // <Question>要素（個々の質問情報）を順番に処理
      $('Question', data).each(function() {
        // <Url>（詳細ページ）、<Content>（質問本文）を基にリンクリストを生成
        $('#result').append(
          $('<li></li>').append(
            $('<a></a>')
              .attr({
                href: $('Url', this).text(),
                target: '_blank'
              })
              .text($('Content', this).text().substring(0, 255) + '...')
          )
        );
      });
    })
    // 検索失敗時には、その旨をダイアログ表示
    .fail(function() {
      window.alert('正しい結果を得られませんでした。');
    });
  });

  $(function () {
    $.ajax(
      {
        async: true,
        url: "https://localhost:7059/Management",
        type: "get",

      }
    )
      .done(function (data) {
        $("#result").empty();
        $("Question", data).each(function () {
          $("#result").append(
            $("<a></a>")
              .attr({
                href: $("Url", this).text(),
                target: "_brank"
              })
              .text($("Content,this").text().substring(0, 255) + "...")
          )
        })
      })
      .fail(function () {
        window.alert("だめ");
      })
  })
*/
