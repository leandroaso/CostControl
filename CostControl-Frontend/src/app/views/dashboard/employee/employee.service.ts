import { Injectable } from '@angular/core';
import { GenericService } from '../../../generic.service';

@Injectable()
export class EmployeeService{
    
    constructor(private service: GenericService){}
}