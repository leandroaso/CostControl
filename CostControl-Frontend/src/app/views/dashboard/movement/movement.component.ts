import { Component, OnInit } from '@angular/core';
import { Movement } from '../../../shared/models/movement.model';
import { MovementService } from './movement.service';
import { DepartamentService } from '../departament/departament.service';
import { EmployeeService } from '../employee/employee.service';
import { Departament } from '../../../shared/models/departament.model';
import { Employee } from '../../../shared/models/employee.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResultModel } from '../../../shared/models/result.model';

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
  movementForEdit: Movement;
  employees: Employee[] = [];
  formCreateMovement: FormGroup;
  formEditMovement: FormGroup;
  
  isMovementsCollapsed: boolean = false;
  movementsCollapse: string = 'fa fa-minus';

  constructor(private service: MovementService, private depService: DepartamentService, private empService: EmployeeService) { }

  ngOnInit() {
    this.getMovements()
    this.getEmployees();
  }

  toggleCollapse(): void {
    this.isMovementsCollapsed = !this.isMovementsCollapsed;
    this.movementsCollapse = this.isMovementsCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }

  pageChanged($event): void {
      this.service.getAll($event.itemsPerPage, $event.page).subscribe(
        (result: ResultModel) => {
          this.movements = result.data.movements;
          this.totalItems = result.data.length;
          this.currentPage = $event.page;
        }
      )
  }

  getMovements(): void {
    this.service.getAll(10, this.currentPage).subscribe(
      (result: ResultModel) => {
        this.movements = result.data.movements;
        this.totalItems = result.data.length;
      }
    )
  }

  createForm(): void{
    this.formCreateMovement = new FormGroup({
      'description': new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(500)]),
      'movementValue': new FormControl(null, [Validators.required]),
      'employeeId': new FormControl(null, [Validators.required])
    })
  }

  getEmployees(): void{
    this.empService.getAll().subscribe(
      (employees: Employee[]) => this.employees = employees
    )
  }

  submitForm(): void {
    if(this.formCreateMovement.status === 'INVALID'){
      this.formCreateMovement.get('description').markAsTouched();
      this.formCreateMovement.get('movementValue').markAsTouched();
      this.formCreateMovement.get('employeeId').markAsTouched();
    } else {

      let movement = new Movement(
        this.formCreateMovement.get('description').value, 
        this.formCreateMovement.get('movementValue').value, 
        this.formCreateMovement.get('employeeId').value
        )
      this.service.saveMovement(movement).subscribe(
        (result: ResultModel) => {
          this.getMovements();
          this.formCreateMovement.reset();
        }
      )
    }
  }

  editMovement(movement: Movement): void {
    this.movementForEdit = movement;

    this.formEditMovement = new FormGroup({
      'description': new FormControl(movement.description, [Validators.required, Validators.minLength(3), Validators.maxLength(500)]),
      'movementValue': new FormControl(movement.movementValue, [Validators.required]),
      'employeeId': new FormControl(movement.employeeId, [Validators.required])
    })
  }

  deleteMovement(id: number): void {
    this.service.deleteMovement(id).subscribe(
      () => {
        this.getMovements();
      }
    )
  }

  updateMovement(): void{
    this.movementForEdit.description = this.formEditMovement.get('description').value;
    this.movementForEdit.movementValue = this.formEditMovement.get('movementValue').value;
    this.movementForEdit.employeeId = this.formEditMovement.get('employeeId').value;

    this.service.updateMovement(this.movementForEdit).subscribe(
      (result: ResultModel) => {
        this.getMovements();
        this.formEditMovement.reset();
      }
    )
  }
}
