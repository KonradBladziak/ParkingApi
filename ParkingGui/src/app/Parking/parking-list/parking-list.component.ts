import { Component } from '@angular/core';
import { ParkingServiceService } from '../../Services/parking-service.service';
import { Parking } from '../Models/parking.model';
import { ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-parking-list',
  templateUrl: './parking-list.component.html',
  styleUrls: ['./parking-list.component.css']
})
export class ParkingListComponent {

  parkingi: Parking[] = [];
  displayedColumns: string[]=['Nazwa','Adres','Miejsca','Miejsca inwalidzkie','Akcja']


  constructor(private parkingService: ParkingServiceService,activatedRoute: ActivatedRoute){
    activatedRoute.params.subscribe(params => {
      const id = params['idMiasta'];
      this.parkingService.getParkingiMiasta(id).subscribe(res => {
        this.parkingi = res;
      })
    })
  }

}
