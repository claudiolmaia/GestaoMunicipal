import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from '../models/usuario';
import { UsuarioLogin } from '../models/usuario-login';

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';

@Injectable()
export class ContaService extends BaseService {

    constructor(private http: HttpClient) { super(); }

    registrarUsuario(usuario: Usuario): Observable<Usuario> {
        let response = this.http
            .post(this.UrlAutenticacaoV1 + 'autenticacao/nova-conta', usuario, this.ObterHeaderJson())
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }

    login(usuario: UsuarioLogin): Observable<Usuario> {
        let response = this.http
            .post(this.UrlAutenticacaoV1 + 'autenticacao/autenticar', usuario, this.ObterHeaderJson())
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }
}