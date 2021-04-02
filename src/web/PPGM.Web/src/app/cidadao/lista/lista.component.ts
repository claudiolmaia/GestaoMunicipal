import { Component, OnInit } from '@angular/core';
import { Iptu } from '../models/iptu';
import { CidadaoService } from '../services/cidadao.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public iptus: Iptu[];
  errorMessage: string;

  constructor(private cidadaoService: CidadaoService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    // if(!this.cidadaoService.LocalStorage.usuarioLogado()) {
    //   this.toastr.warning('Acesso apenas para usuários autenticados!', 'Alerta');
    //   this.router.navigate(["/conta/login"]);
    // }
  }
  
}
