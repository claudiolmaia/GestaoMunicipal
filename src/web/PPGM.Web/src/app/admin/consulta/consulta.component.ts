import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef, ContentChild, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormControlName, ValidationErrors } from '@angular/forms';
import { CustomValidators } from 'ngx-custom-validators';
import { CustomValidator } from "src/app/validators/custom.validator";
import { AdminService } from '../services/admin.service';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';
import { Consulta } from '../models/consulta';
import { FormBaseComponent } from 'src/app/base-components/form-base.component';
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { getAttrsForDirectiveMatching } from '@angular/compiler/src/render3/view/util';

@Component({
  selector: 'app-consulta',
  templateUrl: './consulta.component.html'
})
export class ConsultaComponent extends FormBaseComponent implements OnInit, AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  errors: any[] = [];
  cadastroForm: FormGroup;
  consulta: Consulta;
  consultas: Consulta[];
  currentId: number;

  constructor(private fb: FormBuilder,
    private adminService: AdminService,
    private router: Router,
    private toastr: ToastrService,
    private modal: NgbModal) {

    super();

    this.validationMessages = {
      cpf: {
        required: 'Informe o cpf do usuário',
        onlyNumber: 'Digitar apenas números',
        equalDigits: 'CPF deve ser valido',
        length: 'CPF deve conter 11 digitos',
        digit: 'CPF deve ser valido'
      },
      medico: {
        required: 'Informe o nome do médico',
      },
      unidade: {
        required: 'Informe o número do unidade',
      },
      consultorio: {
        required: 'Informe o número do consultório',
        onlyNumber: 'Digitar apenas números'
      },
      dataConsulta: {
        required: 'Informe a data para a consulta',
        date: 'Formato de data invalido'
      },
      horaConsulta: {
        required: 'Informe o horario para a consulta'
      }
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);
  }

  ngOnInit(): void {
    let cpf = new FormControl('', [Validators.required, CustomValidator.cfpValidator, CustomValidators.number])
    let medico = new FormControl('', [Validators.required])
    let unidade = new FormControl('', [Validators.required])
    let consultorio = new FormControl('', [Validators.required, CustomValidators.number])
    let dataConsulta = new FormControl('', [Validators.required, CustomValidators.date])
    let horaConsulta = new FormControl('', [Validators.required])

    this.cadastroForm = this.fb.group({
      cpf: cpf,
      medico: medico,
      unidade: unidade,
      consultorio: consultorio,
      dataConsulta: dataConsulta,
      horaConsulta: horaConsulta
    });

    this.adminService.obterConsulta()
      .subscribe(
        res => this.consultas = res,
        error => { this.processarFalha(error) });
  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.cadastroForm);
  }

  processarFalha(fail: any) {
    this.errors = fail.error.errors;
    this.toastr.error('Ocorreu um erro!', 'Erro');
  }

  openModalAdicionar(content) {
    this.modal.open(content, { ariaLabelledBy: 'modal-basic-title' })
      .result.then((result) => {
        this.cadastroForm.reset();
      }, (reason) => {
        this.cadastroForm.reset();
      });
  }

  openModalRemover(content, id) {
    this.currentId = id;
    this.modal.open(content, { ariaLabelledBy: 'modal-basic-title' })
      .result.then((result) => {
        this.removerConsulta(this.currentId);
      }, (reason) => {
        this.currentId = 0;
      });
  }

  adicionarConsulta() {
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
      const dataConsulta = this.cadastroForm.value.dataConsulta;
      const horaConsulta = this.cadastroForm.value.horaConsulta;
      var parseDate = new Date(dataConsulta.year, dataConsulta.month - 1, dataConsulta.day, horaConsulta.hour, horaConsulta.minute, horaConsulta.second);
      this.consulta = Object.assign({}, this.consulta, this.cadastroForm.value);
      this.consulta.dataConsulta = (new Date(parseDate.getTime() - (parseDate.getTimezoneOffset() * 60 * 1000))).toISOString();

      this.adminService.adicionarConsulta(this.consulta)
        .subscribe(
          sucesso => { this.processarSucesso(sucesso) },
          falha => { this.processarFalha(falha) }
        );
    } else {
      this.getFormValidationErrors();      
    }
  }

  getFormValidationErrors() {
    let currentErrors = new Map();

    Object.keys(this.cadastroForm.controls).forEach(key => {
      const controlErrors: ValidationErrors = this.cadastroForm.get(key).errors;
      let validation = this.validationMessages[key];
      if (controlErrors != null) {
        currentErrors.set(key, []);
        Object.keys(controlErrors).forEach(x => {
          var message = validation[x];
          currentErrors.get(key).push(message)
        })
        // Object.keys(controlErrors).forEach(keyError => {
        //   console.log('Key control: ' + key + ', keyError: ' + keyError + ', err value: ', controlErrors[keyError]);
        // });
      }
    });

    this.errors = Array.from(currentErrors, ([name, value]) => ({ name, value }));

  }

  processarSucesso(response: any) {
    this.cadastroForm.reset();
    this.modal.dismissAll();
    this.toastr.success('Registro realizado com Sucesso!');
    this.ngOnInit();

    this.errors = [];
  }

  removerConsulta(id) {
    this.adminService.removerConsulta(id)
      .subscribe(
        x => {
          this.toastr.success("Consulta removida com sucesso.");
          this.ngOnInit();
        },
        falha => { this.processarFalha(falha) }
      );
  }

}
