import { Component, OnInit } from '@angular/core';
import { Movement } from '../../../shared/models/movement.model';
import { MovementService } from './movement.service';
import { DepartamentService } from '../departament/departament.service';
import { EmployeeService } from '../employee/employee.service';
import { Departament } from '../../../shared/models/departament.model';
import { Employee } from '../../../shared/models/employee.model';

@Component({
  selector: 'app-movement',
  templateUrl: './movement.component.html',
  styles: [],
  providers: [
    MovementService,
    DepartamentService,
    EmployeeService
  ]
})
export class MovementComponent implements OnInit {
  totalItems: number;
  currentPage: number = 1;
  movements: Movement[] = [];
  departaments: Departament[] = [];
  employees: Employee[] = [];
  
  isMovementsCollapsed: boolean = false;
  movementsCollapse: string = 'fa fa-minus';

  constructor(private service: MovementService, private depService: DepartamentService, private empService: EmployeeService) { }

  ngOnInit() {
    this.getMovements()
  }

  toggleCollapse(): void {
    this.isMovementsCollapsed = !this.isMovementsCollapsed;
    this.movementsCollapse = this.isMovementsCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }

  getMovements(): void {
    this.service.getAll(4, this.currentPage).subscribe(
      (movements: Movement[]) => {
        this.movements = movements;
        this.totalItems = movements.length;
      }
    )
  }

  getDepartaments(): void{
    this.depService.getAll().subscribe(
      (departaments: Departament[]) => this.departaments = departaments
    )
  }

  getEmployees(): void{
    this.empService.getAll().subscribe(
      (employees: Employee[]) => this.employees = employees
    )
  }
}
