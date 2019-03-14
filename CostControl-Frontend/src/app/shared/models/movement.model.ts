import { Employee } from './employee.model';

export class Movement{

    constructor(description: string, movementValue: number, employeeId: number ){
        this.description = description;
        this.movementValue = movementValue;
        this.employeeId = employeeId;
    }

    id: number;
    employeeId: number;
    employee: Employee;
    description: string;
    movementValue: number;
    creationDate: Date;
}