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
  id!: number;
  range = new FormGroup({
    start: new FormControl,
    end: new FormControl,
  });

  constructor(private parkingService: MiejsceServiceService,activatedRoute: ActivatedRoute){
    activatedRoute.params.subscribe(params => {
      this.id = params['id'];
      this.SprawdzDate();
    })
    console.log(this.miejsca);
    console.log()
  }

  SprawdzDate(): void{
      console.log(this.range.value);
      this.parkingService.getMiejscaParkingu(this.id, this.range.value).subscribe(res => {
        this.miejsca = res;
      })
  }
}
