import { IUser } from './../../models/user.model';
import { IProduct } from './../../models/product.model';
import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';


@Injectable()
export class ProductService{
    currentUser: IUser;
    
    constructor(private http: Http, @Inject('baseApiUrl') private baseUrl: string) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    listAll(): Observable<IProduct[]> {
        let customHeaders = new Headers({
            'Content-Type': 'application/json; charset=utf-8',
            'Authorization': 'Bearer ' + this.currentUser.Token
        });

        let options = new RequestOptions({
            headers: customHeaders,
            withCredentials: true
        });

        return this.http.get(this.baseUrl + '/api/v1/products', options)
            .map((response: Response) => {
                return <IProduct[]>response.json();
            });
    }
}
