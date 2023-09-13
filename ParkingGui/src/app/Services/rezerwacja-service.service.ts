import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Rezerwacja } from '../Rezerwacja/Models/rezerwacja.model';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RezerwacjaServiceService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  private readonly url: string = 'http://localhost:5068/api/Rezerwacja/DodajRezerwacje'

  constructor(private httpClient: HttpClient) { }

  addRezerwacja(rezerwacja: Rezerwacja):Observable<void> {
    return this.httpClient.post<void>(this.url, rezerwacja);
  }

}
