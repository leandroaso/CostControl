import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Utils } from './shared/utils';

@Injectable()
export class GenericService{
    
    private headers: HttpHeaders;
    private url: string;

    constructor(private http: HttpClient){
        this.url = Utils.url;
        this.headers = new HttpHeaders().set('Content-Type', 'application/json');
    }

    getById(id: number, route: string): Observable<any>{
        return this.http.get(`${this.url}/${route}/${id}`);
    }

    getAllWithPagination(route: string, pageSize:number, pageNumber: number): Observable<any>{
        return this.http.get(`${this.url}/${route}/${pageSize}/${pageNumber}`);
    }

    getAll(route: string): Observable<any>{
        return this.http.get(`${this.url}/${route}`, { headers: this.headers});
    }

    save(data: any, route: string): Observable<any>{
        return this.http.post(`${this.url}/${route}`, data);
    }

    update(data: any, route: string): Observable<any>{
        return this.http.put(`${this.url}/${route}`, data);
    }

    delete(id: number, route: string): Observable<any>{
        return this.http.delete(`${this.url}/${route}/${id}`);
    }

    getToken(username: string, password: string): Observable<any>{
        let user = {
            username: username,
            password: password
        };
        
        return this.http.post(`${this.url}/login`, user);
    }
}