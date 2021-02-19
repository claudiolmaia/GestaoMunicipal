import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, CanDeactivate } from '@angular/router';
import { BaseGuard } from 'src/app/services/base.guard';


@Injectable()
export class GeoGuard extends BaseGuard implements CanActivate {
    constructor(protected router: Router){ super(router); }

    canActivate(routeAc: ActivatedRouteSnapshot) {
        return super.validarClaims(routeAc);
    }  
    
}