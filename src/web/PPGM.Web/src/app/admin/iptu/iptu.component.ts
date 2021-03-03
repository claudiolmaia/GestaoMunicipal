import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';

import { Iptu } from '../models/iptu';

@Component({
  selector: 'app-iptu',
  templateUrl: './iptu.component.html'
})
export class IptuComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public iptus: Iptu[];
  errorMessage: string;

  constructor(private AdminService: AdminService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    // let user = this.cidadaoService.LocalStorage.obterUsuario();
    // let id = user.claims.find(e=> e.type == 'sub')?.value;
    this.AdminService.obterIptuPorCidadao()
      .subscribe(
        iptus => this.iptus = iptus,
        error => {this.processarFalha(error)});
  }

  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

}
