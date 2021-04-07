import { Component, OnInit } from '@angular/core';
import { CidadaoService } from '../services/cidadao.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

import { Iptu } from '../models/iptu';

@Component({
  selector: 'app-iptu',
  templateUrl: './iptu.component.html'
})
export class IptuComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public iptus: Iptu[];
  errorMessage: string;

  constructor(private cidadaoService: CidadaoService, 
    private router: Router,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService) { }

  ngOnInit(): void {
    this.spinner.show();
    // let user = this.cidadaoService.LocalStorage.obterUsuario();
    // let id = user.claims.find(e=> e.type == 'sub')?.value;
    this.cidadaoService.obterIptuPorCidadao()
      .subscribe(
        iptus => this.iptus = iptus,
        error => {this.processarFalha(error)});

    setTimeout(() => {
      this.spinner.hide();
    }, 1000);
  }

  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
    this.spinner.hide();
  }

   DownloadPDF(Id){
     this.spinner.show();
    this.cidadaoService.obterPDFIptu(Id)
    .subscribe((x) =>
      {
        if(x) {
          let link = document.createElement("a");
          link.download = 'IPTU.pdf';          
          const data = 'data:application/pdf;base64,' + x;
          link.href = data;
          link.click();
        }
        this.spinner.hide();
      },
      error => {this.processarFalha(error)});
  }

}
