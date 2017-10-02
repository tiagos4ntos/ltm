import { AuthService } from './../services/auth.service';
import { Component, OnInit, ViewContainerRef } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastsManager } from 'ng2-toastr/ng2-toastr';

@Component({
    templateUrl: 'login.component.html'
})
export class LoginCompnent {
    model: any = {};
    loading = false;
    returnUrl: string;
    errorMessage: string = "";

    constructor(
        private route: ActivatedRoute,        
        private router: Router,
        private authenticationService: AuthService,
        private toastr: ToastsManager,
        vcr: ViewContainerRef) { 
            this.toastr.setRootViewContainerRef(vcr);
        }

    ngOnInit() {
        // reset login status
        this.authenticationService.logout();

        // get return url from route parameters or default to '/'
        this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';        
    }

    login() {
        this.loading = true;
        this.authenticationService.login(this.model.username, this.model.password)
            .subscribe(
                data => {                    
                    this.router.navigate([this.returnUrl]);
                },
                error => {
                    if (error.status === 404)
                        this.toastr.warning("Usuário e/ou Senha Inválidos");   
                    this.loading = false;
                });
    }
}