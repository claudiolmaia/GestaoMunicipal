import { Component, OnInit } from '@angular/core';
import { Iptu } from '../models/iptu';
import { CidadaoService } from '../services/cidadao.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html'
})
export class ListaComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public iptus: Iptu[];
  errorMessage: string;

  constructor(private cidadaoService: CidadaoService) { }

  ngOnInit(): void {
    this.cidadaoService.obterIptuPorCidadao()
      .subscribe(
        iptus => this.iptus = iptus,
        error => this.errorMessage);
  }
}
