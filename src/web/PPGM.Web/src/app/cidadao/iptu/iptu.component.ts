import { Component, OnInit } from '@angular/core';
import { Iptu } from '../models/iptu';
import { CidadaoService } from '../services/cidadao.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";

import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lista',
  templateUrl: './iptu.component.html'
})
export class IptuComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public iptus: Iptu[];
  errorMessage: string;

  constructor(private cidadaoService: CidadaoService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    let user = this.cidadaoService.LocalStorage.obterUsuario();
    let id = user.claims.find(e=> e.type == 'sub')?.value;
    this.cidadaoService.obterIptuPorCidadao(id)
      .subscribe(
        iptus => this.iptus = iptus,
        error => {this.processarFalha(error)});
  }

  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

}