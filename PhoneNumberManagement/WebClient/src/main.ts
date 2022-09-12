import { enableProdMode } from '@angular/core';
//本番環境用でアプリを起動する際に実行される
//20行目のif文によるチェックで実行の是非が決まる

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
//ブラウザでアプリを起動するために用意されたAngular標準のモジュール

import { AppModule } from './app/app.module';
//Angularアプリの本体となるモジュール
//app.module.tsで定義されている

import { environment } from './environments/environment';
//環境設定ファイル
//ここで定義されている productionの値をif文でチェックする
//trueならば本番環境、falseなら開発環境

import * as $ from 'jquery'
import { HomeComponent } from './app/home/home.component';
import { AppComponent } from './app/app.component';
if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));


