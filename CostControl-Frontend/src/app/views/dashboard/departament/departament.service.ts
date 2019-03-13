import { Injectable } from '@angular/core';
import { GenericService } from '../../../generic.service';
import { Observable } from 'rxjs';
import { Departament } from '../../../shared/models/departament.model';
import { ResultModel } from '../../../shared/models/result.model';

@Injectable()
export class DepartamentService{
    
    constructor(private service: GenericService){}

    getAll(): Observable<Array<Departament>>{
        return this.service.getAll('departaments');
    }

    saveDepartament(departament: Departament): Observable<ResultModel>{
        return this.service.save(departament, 'departaments');
    }

    deleteDepartament(id: number): Observable<ResultModel>{
        return this.service.delete(id, 'departaments');
    }
}