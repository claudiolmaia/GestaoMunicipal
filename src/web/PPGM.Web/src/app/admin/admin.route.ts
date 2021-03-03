import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAppComponent } from './admin.app.component';
import { ListaComponent } from './lista/lista.component';
import { IptuComponent } from './iptu/iptu.component';
import { ConsultaComponent } from './consulta/consulta.component';
import { AdminGuard } from './services/admin.guard';

const AdminRouterConfig: Routes = [
    {
        path: '', component: AdminAppComponent,
        children: [
            { 
                path: 'principal', component: ListaComponent,
                canActivate: [AdminGuard],
                data: [{ claim: { nome: 'role', valor: 'Admin'}}]
            },
            { 
                path: 'iptu', component: IptuComponent,
                canActivate: [AdminGuard],
                data: [{ claim: { nome: 'role', valor: 'Admin'}}]
            },
            { 
                path: 'consulta', component: ConsultaComponent,
                canActivate: [AdminGuard],
                data: [{ claim: { nome: 'role', valor: 'Admin'}}]
            },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(AdminRouterConfig)
    ],
    exports: [RouterModule]
})
export class AdminRoutingModule { }