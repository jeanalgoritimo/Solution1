import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Calculo } from '../Models/Calculo';
import { Observable } from 'rxjs';
import { ParamtrosCalculo } from '../Models/ParamtrosCalculo';
import { enviroment } from '../enviroments/enviroments.prod';

@Injectable({ providedIn: 'root' })
export class CalculoService {
  private baseUrl = enviroment.API_URL;;
 
  constructor(private httpClient: HttpClient, ) { }

  Calcular(formValue: ParamtrosCalculo): Observable<Calculo> {
    return this.httpClient.post<Calculo>(this.baseUrl + 'api/Calculos', formValue);
  }
}
