import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Parking } from '../Parking/Models/parking.model';

@Injectable({
  providedIn: 'root'
})
export class ParkingServiceService {

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  }

  private readonly url: string = 'http://localhost:5068/api/Parkingi/GetParkingiByIdMiasta'

  constructor(private httpClient: HttpClient) { }

  getParkingiMiasta(id: number):Observable<Parking[]>{
    return this.httpClient.get<Parking[]>(this.url + '/' + id);
  }
}
