import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { toEditorSettings } from 'typescript';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PersonCreateComponent } from './person-create/person-create.component';
import { PersonEditComponent } from './person-edit/person-edit.component';
import { PersonRealEditingComponent } from './person-real-editing/person-real-editing.component';
import { PersonSearchComponent } from './person-search/person-search.component';


const routes: Routes = [
  {path: "", redirectTo: "./home",pathMatch: "full"},
  {path:"home", component: HomeComponent},
  {path:"person-edit", component: PersonEditComponent},
  {path:"person-create", component: PersonCreateComponent},
  {path:"person-real-editing", component:PersonRealEditingComponent},
  {path:"person-search", component:PersonSearchComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { onSameUrlNavigation: "reload"})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
