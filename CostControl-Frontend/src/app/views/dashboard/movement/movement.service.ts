import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { GenericService } from '../../../generic.service';
import { Movement } from '../../../shared/models/movement.model';
import { ResultModel } from '../../../shared/models/result.model';

@Injectable()
export class MovementService{

    constructor(private service: GenericService){}
    
    getAll(pageSize:number, pageNumber: number): Observable<ResultModel>{
        return this.service.getAllWithPagination('movements', pageSize, pageNumber);
    }

    saveMovement(movement: Movement): Observable<ResultModel>{
        return this.service.save(movement, 'movements');
    }

    updateMovement(movement: Movement): Observable<ResultModel>{
        return this.service.update(movement, 'movements');
    }

    deleteMovement(id: number): Observable<ResultModel>{
        return this.service.delete(id, 'movements');
    }
}