import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { ListaComponent } from './lista/lista.component';
import { CidadaoAppComponent } from './cidadao.app.component';

import { CidadaoRoutingModule } from './cidadao.route';
import { CidadaoService } from './services/cidadao.service';

import { CustomFormsModule } from 'ngx-custom-validators'
import { CidadaoGuard } from './services/cidadao.guard';

@NgModule({
  declarations: [
    CidadaoAppComponent,
    ListaComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    CidadaoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CustomFormsModule
  ],
  providers: [
    CidadaoService,
    CidadaoGuard
  ]
})
export class CidadaoModule { }