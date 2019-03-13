import { Injectable } from '@angular/core';
import { GenericService } from '../../../generic.service';
import { Observable } from 'rxjs';
import { Departament } from '../../../shared/models/departament.model';

@Injectable()
export class DepartamentService{
    
    constructor(private service: GenericService){}

    getAll(): Observable<Array<Departament>>{
        return this.service.getAll('departaments');
    }
}