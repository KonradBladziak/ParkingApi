import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dodaj-rezerwacje',
  templateUrl: './dodaj-rezerwacje.component.html',
  styleUrls: ['./dodaj-rezerwacje.component.css']
})
export class DodajRezerwacjeComponent {

  constructor(private router: Router) {
    console.log(this.router.getCurrentNavigation()?.extras.state);
    // 1.Stworzyć formgroup z OD DO imie nazwisko idMiejsca z url
    // 2.Stworzyć metodę w serwisie typu post typu observable void
    // 3.Lokalna metoda która bedzie na submit działać
    // 4.Użyć routera router.naviateByUrl
    // 5.Angular Toast
  }
}
