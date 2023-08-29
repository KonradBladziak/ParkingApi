import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Miejsce } from '../Miejsca/Models/miejsce.model';

@Injectable({
  providedIn: 'root'
})


export class MiejsceServiceService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  private readonly url: string = 'http://localhost:5068/api/Miejsca/GetWszystkieMiejscaNaParkingu';

  constructor(private httpClient: HttpClient) { }

  getMiejscaParkingu(id : number):Observable<Miejsce[]>{
    return this.httpClient.get<Miejsce[]>(this.url + '/' + id);
  }

}
