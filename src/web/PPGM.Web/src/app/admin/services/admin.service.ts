import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';
import { Iptu } from '../models/iptu';
import { Consulta } from '../models/consulta';
import { ConsultaComponent } from '../consulta/consulta.component';

@Injectable()
export class AdminService extends BaseService {

    constructor(private http: HttpClient) { super(); }

    obterIptu(): Observable<Iptu[]> {
        return this.http
            .get<Iptu[]>(`${this.UrlIntegracaoV1}integracao/iptu`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    baixarIptu(Id: number): Observable<boolean> {
        return this.http
            .put<boolean>(`${this.UrlIntegracaoV1}integracao/iptu/${Id}`, [], super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    obterConsulta(): Observable<Consulta[]> {
        return this.http
            .get<Consulta[]>(`${this.UrlIntegracaoV1}integracao/consulta`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    adicionarConsulta(consulta: Consulta): Observable<Consulta> {
        return this.http
            .post<Consulta>(`${this.UrlIntegracaoV1}integracao/consulta`,consulta, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    removerConsulta(id: number): Observable<Consulta> {
        return this.http
            .delete<Consulta>(`${this.UrlIntegracaoV1}integracao/consulta/${id}`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }
}