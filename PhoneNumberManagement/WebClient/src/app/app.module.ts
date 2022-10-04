import { NgModule } from '@angular/core';
//モジュールを定義するためのAngularが提供する標準モジュール
import { BrowserModule } from '@angular/platform-browser';
//アプリをブラウザ上で動作させるためのAngularが提供する標準モジュール
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
//Angularアプリの実態となるルートコンポーネント
//実態はsrc/app/app.component.ts
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PersonEditComponent } from './person-edit/person-edit.component';
import { PersonCreateComponent } from './person-create/person-create.component';
import { HomeComponent } from './home/home.component';
import { PersonRealEditingComponent } from './person-real-editing/person-real-editing.component';
import { PersonSearchComponent } from './person-search/person-search.component';
import { MaterialModule } from './material/material.module';
import { FormsModule }   from '@angular/forms';

@NgModule({
  declarations: [
    //現在のモジュールに属するコンポーネントを宣言
    AppComponent,
    PersonEditComponent,
    PersonCreateComponent,
    HomeComponent,
    PersonRealEditingComponent,
    PersonSearchComponent,
  ],
  imports: [
    //現在のモジュールで私用する他のモジュール宣言
    //importしていることが前提
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule
  ],
  providers: [],
  //依存性注入
  //利用したいサービス指定する
  //サービスはimport前提
  //モジュール全体でアクセス可能
  bootstrap: [AppComponent]
  //アプリで最初に起動するコンポーネントを指定
  //import前提
})

export class AppModule { }
//モジュールクラスを定義し且つ外部公開を宣言している
