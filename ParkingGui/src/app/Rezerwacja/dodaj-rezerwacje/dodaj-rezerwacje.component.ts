import { Component } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { Rezerwacja } from '../Models/rezerwacja.model';
import { FormControl, FormGroup } from '@angular/forms';
import { RezerwacjaServiceService } from 'src/app/Services/rezerwacja-service.service';

@Component({
  selector: 'app-dodaj-rezerwacje',
  templateUrl: './dodaj-rezerwacje.component.html',
  styleUrls: ['./dodaj-rezerwacje.component.css']
})
export class DodajRezerwacjeComponent {

  idMiejsca!: number;
  rezerwacja!: Rezerwacja;

  osoba = new FormGroup ({
    imie: new FormControl,
    nazwisko: new FormControl,
  });
  data = new FormGroup ({
    start: new FormControl,
    end: new FormControl,
  });

// 1.Stworzyć formgroup z OD DO imie nazwisko idMiejsca z url
    // 2.Stworzyć metodę w serwisie typu post typu observable void
    // 3.Lokalna metoda która bedzie na submit działać
    // 4.Użyć routera router.naviateByUrl
    // 5.Angular Toast

  constructor(private rezerwacjaService:RezerwacjaServiceService, activatedRoute: ActivatedRoute, private router: Router) {
    console.log(this.router.getCurrentNavigation()?.extras.state);

    activatedRoute.params.subscribe(params => {
      this.idMiejsca = params['idMiejsca'];
      
    })
    const currentNavigation = this.router.getCurrentNavigation()?.extras.state;
    if(currentNavigation)
    {
      this.data.value.start = currentNavigation['start'];
      this.data.value.end = currentNavigation['end'];
    }
    
  }

  Rezerwuj(){
  
    this.rezerwacja = {
    
      od: this.data.value.start,
      do: this.data.value.end,
      idMiejsca: this.idMiejsca,
      imie: this.osoba.value.imie,
      nazwisko: this.osoba.value.nazwisko
    }
    this.rezerwacjaService.addRezerwacja(this.rezerwacja).subscribe(res=>{
      console.log(this.rezerwacja);
    });

    this.router.navigate(['']);
    
  }


}
