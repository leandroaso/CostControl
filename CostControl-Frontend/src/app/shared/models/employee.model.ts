import { Departament } from './departament.model';

export class Employee{
    
    constructor(name: string, departamentId: number){
        this.name = name;
        this.departamentId = departamentId;
    }

    id: number;
    name: string;
    creationDate: Date;
    departamentId: number;
    departament: Departament;
}