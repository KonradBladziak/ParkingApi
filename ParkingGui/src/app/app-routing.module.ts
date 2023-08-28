import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MiastoListComponent } from './Miasto/miasto-list/miasto-list.component';
import { ParkingListComponent } from './Parking/parking-list/parking-list.component';
import { MiejscaListComponent } from './Miejsca/miejsca-list/miejsca-list.component';

const routes: Routes = [
  {path:'',component:MiastoListComponent},
  {path:':id/parking',component:ParkingListComponent},
  {path:'id/miejsca',component:MiejscaListComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
