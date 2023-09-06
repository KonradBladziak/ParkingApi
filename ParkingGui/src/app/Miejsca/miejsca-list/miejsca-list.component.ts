import { Component } from '@angular/core';
import { Miejsce } from '../Models/miejsce.model';
import { MiejsceServiceService } from 'src/app/Services/miejsce-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-miejsca-list',
  templateUrl: './miejsca-list.component.html',
  styleUrls: ['./miejsca-list.component.css']
})
export class MiejscaListComponent {

  miejsca: Miejsce[] = [];
  idParkingu!: number;
  idMiasta!: number;
  range = new FormGroup({
    start: new FormControl,
    end: new FormControl,
  });

  constructor(private parkingService: MiejsceServiceService,activatedRoute: ActivatedRoute,private router: Router){
    activatedRoute.params.subscribe(params => {
      this.idParkingu = params['idParkingu'];
      this.idMiasta = params['idMiasta'];
      this.SprawdzDate();
    })
    console.log(this.miejsca);
    console.log(this.idMiasta);
    console.log(this.idParkingu);
  }

  SprawdzDate(): void{
      console.log(this.range.value);
      this.parkingService.getMiejscaParkingu(this.idParkingu, this.range.value).subscribe(res => {
        this.miejsca = res.filter(item => item.czyDostepne === true);
      })
  }
  jakasMetoda(idMiejsca: number): void{
    this.router.navigate(['Miasta/' + this.idMiasta + '/Parkingi/' + this.idParkingu + '/Miejsca/' + idMiejsca], {
      state: {
        start: this.range.value.start,
        end: this.range.value.end
      }
    });
  }
}
