import { Component, Inject, Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Calculo } from '../Models/Calculo';
import { Observable } from 'rxjs';
import { ParamtrosCalculo } from '../Models/ParamtrosCalculo';

@Injectable({ providedIn: 'root' })
export class CalculoService {
  private baseUrl: String = "https://localhost:44365/";
  constructor(private httpClient: HttpClient, ) { }

  Calcular(formValue: ParamtrosCalculo): Observable<Calculo> {
    return this.httpClient.post<Calculo>(this.baseUrl + 'api/Calculo', formValue);
  }
}
