import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { GeoService } from '../services/geo.service';

import { IndicadorIbge } from '../models/indicador-ibge';
import { LocalidadeIbge } from '../models/localidade-ibge';
import { number } from 'ngx-custom-validators/src/app/number/validator';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
})
export class ListaComponent implements OnInit {

  public result: string;
  public malhaGeografica: string;
  public localidade: LocalidadeIbge;
  public indicadores: IndicadorIbge[];
  errorMessage: string;

  constructor(private geoService: GeoService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  ObterMalhaGeografica() {
    this.geoService.obterMalhaGeografica()
      .subscribe(
        res => { this.processarSucesso(res, "geo-malha-geografica") },
        error => { this.processarFalha(error) });
  }

  ObterIndicadoresPopulacao() {
    this.geoService.obterIndicadoresPopulacao()
      .subscribe(
        res => { this.processarSucesso(res, "geo-indicadores-populacao") },
        error => { this.processarFalha(error) });
  }

  ObterLocalidade() {
    this.geoService.obterLocalidades()
      .subscribe(
        res => { this.processarSucesso(res, "geo-localidades") },
        error => { this.processarFalha(error) });
  }

  processarSucesso(res: any, fileName: string) {    
    var link = document.createElement("a");
    link.download = `${fileName}.json`;
    var data = "text/json;charset=utf-8," + encodeURIComponent(res);
    link.href = "data:" + data;
    link.click();
  }

  processarFalha(fail: any) {
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

}
