import { Injectable } from '@angular/core';
import { GenericService } from '../../../generic.service';
import { Observable, BehaviorSubject, Subject } from 'rxjs';
import { switchMap } from 'rxjs/operators';
import { Departament } from '../../../shared/models/departament.model';
import { ResultModel } from '../../../shared/models/result.model';

@Injectable()
export class DepartamentService{

    response: any = []

    constructor(private service: GenericService){}

    getAll(): Observable<Array<Departament>>{
        return this.service.getAll('departaments');
    }

    saveDepartament(departament: Departament): Observable<ResultModel>{
        return this.service.save(departament, 'departaments');
    }

    updateDepartament(departament: Departament): Observable<ResultModel>{
        return this.service.update(departament, 'departaments');
    }

    deleteDepartament(id: number): Observable<ResultModel>{
        return this.service.delete(id, 'departaments');
    }
    
}