import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';

import { Consulta } from '../models/consulta';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html'
})
export class ConsultaComponent implements OnInit {

  public consultas: Consulta[];

  constructor(private adminService: AdminService, 
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    this.adminService.obterConsultaPorCidadao()
      .subscribe(
        res => this.consultas = res,
        error => {this.processarFalha(error)});
  }

  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

}
