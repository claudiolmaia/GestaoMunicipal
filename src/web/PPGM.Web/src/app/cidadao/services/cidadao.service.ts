import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';
import { Iptu } from '../models/iptu';
import { Consulta } from '../models/consulta';

@Injectable()
export class CidadaoService extends BaseService {

    constructor(private http: HttpClient) { super(); }

    obterIptuPorCidadao(): Observable<Iptu[]> {
        return this.http
            .get<Iptu[]>(`${this.UrlIntegracaoV1}integracao/iptu/${super.ObterUserId()}`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    obterPDFIptu(id: number): Observable<Blob> {
        
        return this.http
            .get<Blob>(`${this.UrlIntegracaoV1}integracao/iptu/pdf/${id}`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }

    obterConsultaPorCidadao(): Observable<Consulta[]> {
        
        return this.http
            .get<Iptu[]>(`${this.UrlIntegracaoV1}integracao/consulta/${super.ObterUserId()}`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }
}