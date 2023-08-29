import { Component } from '@angular/core';
import { Miejsce } from '../Models/miejsce.model';
import { MiejsceServiceService } from 'src/app/Services/miejsce-service.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-miejsca-list',
  templateUrl: './miejsca-list.component.html',
  styleUrls: ['./miejsca-list.component.css']
})
export class MiejscaListComponent {

  miejsca: Miejsce[] = [];

  constructor(private parkingService: MiejsceServiceService,activatedRoute: ActivatedRoute){
    activatedRoute.params.subscribe(params => {
      const id = params['id'];
      this.parkingService.getMiejscaParkingu(id).subscribe(res => {
        this.miejsca = res;
      })
    })
    console.log(this.miejsca);
    console.log()
  }
}
