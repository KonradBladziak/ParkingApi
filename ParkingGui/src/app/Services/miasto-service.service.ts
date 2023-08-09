import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Miasto } from '../Miasto/Models/miasto.model';
@Injectable({
  providedIn: 'root'
})
export class MiastoServiceService {
  
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  private readonly url: string = 'http://localhost:5068/api/Miasta';

  constructor(private httpClient: HttpClient) { }

  getAll(): Observable<Miasto[]>{
    return this.httpClient.get<Miasto[]>(this.url);
  }
}
