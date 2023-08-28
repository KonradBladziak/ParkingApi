import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MiastoListComponent } from './Miasto/miasto-list/miasto-list.component';

const routes: Routes = [
  {path:'',component:MiastoListComponent},
  {path:':id/parking',component:MiastoListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
