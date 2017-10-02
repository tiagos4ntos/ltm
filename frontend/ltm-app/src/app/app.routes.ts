import { AuthGuard } from './services/auth.guard';
import { ProductsComponent } from './products/products.component';
import { LoginCompnent } from './login/login.component';
import { Routes, RouterModule } from '@angular/router';




export const appRoutes: Routes = [
    { path: '', component: ProductsComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginCompnent },    

    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];
