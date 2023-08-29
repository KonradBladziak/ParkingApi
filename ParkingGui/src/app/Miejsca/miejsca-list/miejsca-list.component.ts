import { Component } from '@angular/core';
import { Miejsce } from '../Models/miejsce.model';
import { MiejsceServiceService } from 'src/app/Services/miejsce-service.service';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-miejsca-list',
  templateUrl: './miejsca-list.component.html',
  styleUrls: ['./miejsca-list.component.css']
})
export class MiejscaListComponent {

  miejsca: Miejsce[] = [];
  // minDate!: number;
  // maxDate!: number;
  // stepHour!: number;
  // stepMinute!: number;
  // stepSecond!: number;
  // enableMeridian: boolean = true;
  // showSpinners: boolean = true;

  // data = new FormGroup({
  //   minDate: new FormControl('', Validators.required),
  //   maxDate: new FormControl('', Validators.required),
  //   stepHour: new FormControl('', Validators.required),
  //   stepMinute: new FormControl('', Validators.required),
  //   stepSecond: new FormControl('', Validators.required),
  //   wynagrodzenie: new FormControl('', Validators.required),
  //   idZarzad: new FormControl('', Validators.required)
  // });

  range = new FormGroup({
    start: new FormControl<Date | null>(null),
    end: new FormControl<Date | null>(null),
  });

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

  SprawdzDate(): void{
      console.log(this.range.value);
  };
}
