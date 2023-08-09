import { Component, OnInit } from '@angular/core';
import { MiastoServiceService } from 'src/app/Services/miasto-service.service';
import { Miasto } from '../Models/miasto.model';

@Component({
  selector: 'app-miasto-list',
  templateUrl: './miasto-list.component.html',
  styleUrls: ['./miasto-list.component.css'],
})
export class MiastoListComponent implements OnInit{
  
  
  miasta: Miasto[] = [];
  displayedColumns: string[] = ['Nazwa','Wojewodztwo'];

  constructor(private miastoService: MiastoServiceService){
    this.getMiasta();
  }

  ngOnInit(): void {
    this.getMiasta();
  }

  getMiasta(){
    this.miastoService.getAll().subscribe(res => {
      this.miasta = res;
      console.log(this.miasta);
    })
  }
}
