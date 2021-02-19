import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomFormsModule } from 'ngx-custom-validators'

import { GeoAppComponent } from './geo.app.component';
import { ListaComponent } from './lista/lista.component';

import { GeoRoutingModule } from './geo.route';
import { GeoService } from './services/geo.service';

import { GeoGuard } from './services/geo.guard';



@NgModule({
  declarations: [
    GeoAppComponent,
    ListaComponent],
  imports: [
    CommonModule,
    RouterModule,
    GeoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CustomFormsModule
  ],
  providers: [
    GeoService,
    GeoGuard
  ]
})
export class GeoModule { }
