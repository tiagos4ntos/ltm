import { ToastsManager } from 'ng2-toastr/ng2-toastr';
import { Router } from '@angular/router';
import { ProductService } from './../services/products.service';
import { IProduct } from './../../models/product.model';
import { IUser } from './../../models/user.model';
import { Component, ViewContainerRef } from '@angular/core';
@Component({
    templateUrl: 'products.component.html'
})
export class ProductsComponent {
    currentUser: IUser;
    products: IProduct[] = [];

    constructor(private productService: ProductService,
        private router: Router,
        private toastr: ToastsManager,
        vcr: ViewContainerRef) {
        this.toastr.setRootViewContainerRef(vcr);
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadProducts();
    }


    private loadProducts() {
        this.productService
            .listAll()
            .subscribe(products => {
                this.products = products;
            }
            , error => {
                this.toastr.warning("Sessão expirada!");
                this.router.navigate(['login']);
            });
    }
}