import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';
import { LocalidadeIbge } from '../models/localidade-ibge';
import { IndicadorIbge } from '../models/indicador-ibge';

@Injectable({
  providedIn: 'root'
})
export class GeoService extends BaseService {

  constructor(private http: HttpClient) { super(); }

  obterMalhaGeografica(): Observable<string> {
    return this.http
      .get<string>(`${this.UrlIbge}v2/malhas/3108008?formato=application/vnd.geo+json`)
      .pipe(catchError(super.serviceError));
  }

  obterLocalidades(): Observable<LocalidadeIbge> {
    return this.http
      .get<LocalidadeIbge>(`${this.UrlIbge}v1/localidades/municipios/3108008`)
      .pipe(catchError(super.serviceError));
  }

  obterIndicadoresPopulacao(): Observable<IndicadorIbge[]> {
    return this.http
      .get<IndicadorIbge[]>(`${this.UrlIbge}v1/pesquisas/indicadores/60045|29765|30279?localidade=3108008&lang=pt`)
      .pipe(catchError(super.serviceError));
  }  

}
