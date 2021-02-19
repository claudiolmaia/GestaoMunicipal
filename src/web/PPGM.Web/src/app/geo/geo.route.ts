import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GeoAppComponent } from './geo.app.component';
import { GeoGuard } from './services/geo.guard';
import { ListaComponent } from "./lista/lista.component";

const geoRouterConfig: Routes = [
    {
        path: '', component: GeoAppComponent,
        children: [
            { path: 'principal', component: ListaComponent },            
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(geoRouterConfig)
    ],
    exports: [RouterModule]
})
export class GeoRoutingModule { }