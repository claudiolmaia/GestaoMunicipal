import { Component, OnInit } from '@angular/core';
import { AdminService } from '../services/admin.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { NgbModal, ModalDismissReasons } from "@ng-bootstrap/ng-bootstrap";
import { Iptu } from '../models/iptu';

@Component({
  selector: 'app-iptu',
  templateUrl: './iptu.component.html'
})
export class IptuComponent implements OnInit {

  imagens: string = environment.imagensUrl;

  public iptus: Iptu[];
  errorMessage: string;
  closeResult: string;
  private modalCurrentId: number;

  constructor(private AdminService: AdminService, 
    private router: Router,
    private toastr: ToastrService,
    private modal: NgbModal) { }

  ngOnInit(): void {
    // let user = this.cidadaoService.LocalStorage.obterUsuario();
    // let id = user.claims.find(e=> e.type == 'sub')?.value;
    this.AdminService.obterIptu()
      .subscribe(
        iptus => this.iptus = iptus,
        error => {this.processarFalha(error)});
  }


  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

  
  OpenModal(content, Id) {
    this.modalCurrentId = Id;
    this.modal.open(content,  {ariaLabelledBy: 'modal-basic-title'})
      .result.then((result) => 
      {
        this.Baixar(this.modalCurrentId);
      }, (reason) => 
      {
        this.closeResult = `Dismissed`;
      });
  }

  private Baixar(Id){
    this.AdminService.baixarIptu(Id)
    .subscribe((x) =>
      {
        if(x) {
          this.toastr.success("Baixa efetuada.");
          this.ngOnInit();
        }
          
      },
      error => {this.processarFalha(error)});
  }



}
