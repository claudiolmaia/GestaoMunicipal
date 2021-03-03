import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { ToastrService } from 'ngx-toastr';

import { AdminService } from './services/admin.service';

@Component({
  selector: 'admin-app-root',
  template: '<router-outlet></router-outlet>'
})
export class AdminAppComponent implements OnInit {

  constructor(private adminService: AdminService,
    private router: Router,
    private toastr: ToastrService) { }

  ngOnInit(): void {
    if(!this.adminService.LocalStorage.usuarioLogado()) {
      this.toastr.warning('Acesso restrito, apenas para usuários autenticados!', 'Alerta');
      this.router.navigate(["/conta/login"]);
    }
  }

}
