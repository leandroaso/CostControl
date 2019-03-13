import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
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
}