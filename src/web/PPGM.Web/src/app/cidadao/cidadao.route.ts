import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CidadaoAppComponent } from './cidadao.app.component';
import { ListaComponent } from './lista/lista.component';
import { IptuComponent } from './iptu/iptu.component';
import { CidadaoGuard } from './services/cidadao.guard';

const cidadaoRouterConfig: Routes = [
    {
        path: '', component: CidadaoAppComponent,
        children: [
            { path: 'principal', component: ListaComponent },
            { path: 'iptu', component: IptuComponent },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(cidadaoRouterConfig)
    ],
    exports: [RouterModule]
})
export class CidadaoRoutingModule { }