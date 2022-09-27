import { getCurrencySymbol } from '@angular/common';
//Angularが提供する標準モジュール
//コンポーネントを定義するために必要なモジュール
import { Component } from '@angular/core';
import { Router } from '@angular/router';


//export文で外部公開の宣言で定義したクラスのコンポーネント構成情報を
//宣言するデコレーター
@Component({
  selector: 'app-root',
  //外部から参照される際に指定されるタグの定義
  //app-rootはindex.htmlで指定されて読み込まれる

  templateUrl: 'app.component.html',
  //本コンポーネントのhtmlテンプレートファイルのファイルパスを指定する

  styleUrls: ['app.component.scss']
  //本コンポーネントのcssファイルパスを配列する
})

export class AppComponent {
  title = 'WebClient';

  constructor(private router: Router){
  }

  ngOnInit(): void{
    this.router.navigateByUrl('/home');
  }
}


