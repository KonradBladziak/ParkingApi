import { Component, OnInit } from '@angular/core';
import { MiastoServiceService } from 'src/app/Services/miasto-service.service';
import { Miasto } from '../Models/miasto.model';

import { FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-miasto-list',
  templateUrl: './miasto-list.component.html',
  styleUrls: ['./miasto-list.component.css'],
})
export class MiastoListComponent implements OnInit{
  wybraneWojewodztwo = null;
  miasta: Miasto[] = [];
  wojewodztwa: string[] = [];
  displayedColumns: string[] = ['Nazwa','Wojewodztwo','Akcja'];


  
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
      this.getWojewodztwa();
    })
  }

  getWojewodztwa(){
    if(this.miasta != null){
      this.wojewodztwa = this.miasta.map(x => x.wojewodztwo).filter((value, index, self) => self.indexOf(value) === index).sort((a,b)=> a.localeCompare(b));
      console.log(this.wojewodztwa[0]);
    }
  }

  filtrWojewodztwa(value : any){
    if(value != null){
      return this.miasta.filter(x => x.wojewodztwo == value);
    }
    else{
      return this.miasta.sort();
    }
  }



}
