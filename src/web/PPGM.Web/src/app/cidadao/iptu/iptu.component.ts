import { Component, OnInit } from '@angular/core';
import { CidadaoService } from '../services/cidadao.service';
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

  constructor(private cidadaoService: CidadaoService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    // let user = this.cidadaoService.LocalStorage.obterUsuario();
    // let id = user.claims.find(e=> e.type == 'sub')?.value;
    this.cidadaoService.obterIptuPorCidadao()
      .subscribe(
        iptus => this.iptus = iptus,
        error => {this.processarFalha(error)});
  }

  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

   DownloadPDF(Id){
    this.cidadaoService.obterPDFIptu(Id)
    .subscribe((x) =>
      {
        if(x) {
          var link = document.createElement("a");
          link.download = `IPTU.pdf`;
          var data = "application/pdf;charset=utf-8," + x;
          link.href = "data:" + data;
          link.click();
        }
          
      },
      error => {this.processarFalha(error)});
  }

  GerarPdf(res: any, fileName: string) {    
    var link = document.createElement("a");
    link.download = `${fileName}.json`;
    var data = "text/json;charset=utf-8," + encodeURIComponent(JSON.stringify(res));
    link.href = "data:" + data;
    link.click();
  }

}
