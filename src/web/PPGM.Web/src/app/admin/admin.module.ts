import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ListaComponent } from './lista/lista.component';
import { IptuComponent } from './iptu/iptu.component';
import { AdminAppComponent } from './admin.app.component';

import { AdminRoutingModule } from './admin.route';
import { AdminService } from './services/admin.service';

import { CustomFormsModule } from 'ngx-custom-validators'
import { AdminGuard } from './services/admin.guard';
import { ConsultaComponent } from './consulta/consulta.component';
import { NgbModule, NgbDatepickerI18n, NgbDateParserFormatter } from '@ng-bootstrap/ng-bootstrap';
import { I18n, CustomDatepickerI18n } from "src/app/providers/custom-datepicker-I18n";
import { NgbDatePTParserFormatter } from "src/app/providers/ngb-dateptbr-parser";
import { NgxSpinnerModule } from "ngx-spinner";

@NgModule({
  declarations: [
    AdminAppComponent,
    ListaComponent,
    IptuComponent,
    ConsultaComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    AdminRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CustomFormsModule,
    NgbModule,
    NgxSpinnerModule
    
  ],
  providers: [
    AdminService,
    AdminGuard,
    [I18n, { provide: NgbDatepickerI18n, useClass: CustomDatepickerI18n }],
    [{provide: NgbDateParserFormatter, useClass: NgbDatePTParserFormatter}],
  ]
})
export class AdminModule { }
