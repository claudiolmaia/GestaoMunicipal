import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormControlName } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';
import { CustomValidator } from "src/app/validators/custom.validator";
import { AdminService } from '../services/admin.service';
import { environment } from 'src/environments/environment';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { Consulta } from '../models/consulta';
import { FormBaseComponent } from 'src/app/base-components/form-base.component';
import { NgbModal, ModalDismissReasons } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html'
})
export class ConsultaComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  cadastroForm: FormGroup;
  public consultas: Consulta[];

  constructor(private fb: FormBuilder,
    private adminService: AdminService, 
    private router: Router,
    private toastr: ToastrService,
    private modal: NgbModal) { 
      super();

      this.validationMessages = {
        nome: {
          required: 'Informe o nome do usuário',
        },
        cpf: {
          required: 'Informe o cpf do usuário',
          onlyNumber: 'Digitar apenas números',
          equalDigits: 'CPF deve ser valido',
          length: 'CPF deve conter 11 digitos',
          digit: 'CPF deve ser valido'
        },
        email: {
          required: 'Informe o e-mail',
          email: 'Email inválido',
  
        },
        senha: {
          required: 'Informe a senha',
          rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
        },
        senhaConfirmacao: {
          required: 'Informe a senha novamente',
          rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
          equalTo: 'As senhas não conferem'
        }
      };

      super.configurarMensagensValidacaoBase(this.validationMessages);
    }

  ngOnInit(): void {
    let cpf = new FormControl('', [Validators.required, CustomValidator.cfpValidator, CustomValidators.number])
    
    this.cadastroForm = this.fb.group({
      cpf: cpf,
      medico: ['', [Validators.required]],
      unidade: ['', [Validators.required]],
      consultorio: ['', [Validators.required, CustomValidators.number]],
      dataConsulta: ['', []]
      
    });

    this.adminService.obterConsulta()
      .subscribe(
        res => this.consultas = res,
        error => {this.processarFalha(error)});

        
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.cadastroForm);
  }

  processarFalha(fail: any){
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

  OpenModalAdicionar(content) {
    this.modal.open(content,  {ariaLabelledBy: 'modal-basic-title'})
      .result.then((result) => 
      {
        
      }, (reason) => 
      {
        
      });
  }

  OpenModalRemover(content) {
    this.modal.open(content,  {ariaLabelledBy: 'modal-basic-title'})
      .result.then((result) => 
      {
        
      }, (reason) => 
      {
        
      });
  }

}
