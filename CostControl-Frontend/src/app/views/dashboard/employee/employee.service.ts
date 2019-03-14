import { Injectable } from '@angular/core';
import { GenericService } from '../../../generic.service';
import { Observable } from 'rxjs';
import { Employee } from '../../../shared/models/employee.model';
import { ResultModel } from '../../../shared/models/result.model';

@Injectable()
export class EmployeeService{
    
    constructor(private service: GenericService){}

    getAll(): Observable<Array<Employee>>{
        return this.service.getAll('employees');
    }

    saveEmployee(employee: Employee): Observable<ResultModel>{
        return this.service.save(employee, 'employees');
    }

    updateEmployee(employee: Employee): Observable<ResultModel>{
        return this.service.update(employee, 'employees');
    }

    deleteEmployee(id: number): Observable<ResultModel>{
        return this.service.delete(id, 'employees');
    }
}