import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Rezerwacja } from '../Models/rezerwacja.model';
import { FormControl, FormGroup } from '@angular/forms';
import { RezerwacjaServiceService } from 'src/app/Services/rezerwacja-service.service';

@Component({
  selector: 'app-dodaj-rezerwacje',
  templateUrl: './dodaj-rezerwacje.component.html',
  styleUrls: ['./dodaj-rezerwacje.component.css']
})
export class DodajRezerwacjeComponent {


  osoba = new FormGroup ({
    imie: new FormControl,
    nazwisko: new FormControl,
  });


  constructor(private rezerwacjaService:RezerwacjaServiceService,private router: Router) {
    console.log(this.router.getCurrentNavigation()?.extras.state);
    // 1.Stworzyć formgroup z OD DO imie nazwisko idMiejsca z url
    // 2.Stworzyć metodę w serwisie typu post typu observable void
    // 3.Lokalna metoda która bedzie na submit działać
    // 4.Użyć routera router.naviateByUrl
    // 5.Angular Toast
  }

  Rezerwuj(){
    
    console.log(this.osoba.value);

  }


}
