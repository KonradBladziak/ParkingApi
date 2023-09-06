import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MiastoListComponent } from './Miasto/miasto-list/miasto-list.component';
import { ParkingListComponent } from './Parking/parking-list/parking-list.component';
import { MiejscaListComponent } from './Miejsca/miejsca-list/miejsca-list.component';
import { RezerwacjaListComponent } from './Rezerwacja/rezerwacja-list/rezerwacja-list.component';
import { DodajRezerwacjeComponent } from './Rezerwacja/dodaj-rezerwacje/dodaj-rezerwacje.component';

const routes: Routes = [
  {path:'',component:MiastoListComponent},
  {path:'Miasta', component:MiastoListComponent},
  {path:'Miasta/:idMiasta/Parkingi',component:ParkingListComponent},
  {path:'Miasta/:idMiasta/Parkingi/:idParkingu/Miejsca',component:MiejscaListComponent},
  {path:'Miasta/:idMiasta/Parkingi/:idParkingu/Miejsca/:id',component:DodajRezerwacjeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
