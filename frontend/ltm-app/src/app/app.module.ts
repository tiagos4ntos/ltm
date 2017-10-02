import { ProductService } from './services/products.service';
import { AuthService } from './services/auth.service';
import { AuthGuard } from './services/auth.guard';
import { appRoutes } from './app.routes';
import { RouterModule } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { LoginCompnent } from './login/login.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from "@angular/http";
import { FormsModule }    from '@angular/forms';
import { ToastModule } from 'ng2-toastr/ng2-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginCompnent,
    ProductsComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpModule,
    ToastModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    AuthGuard,    
    AuthService,
    ProductService,
    {
      provide: 'baseApiUrl',
      useValue: 'http://localhost:58370'
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
