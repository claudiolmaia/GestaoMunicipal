import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';
import { Iptu } from '../models/iptu';

@Injectable()
export class CidadaoService extends BaseService {

    constructor(private http: HttpClient) { super(); }

    obterIptuPorCidadao(id: string): Observable<Iptu[]> {
        return this.http
            .get<Iptu[]>(`${this.UrlIntegracaoV1}integracao/iptu/${id}`, super.ObterAuthHeaderJson())
            .pipe(catchError(super.serviceError));
    }
}