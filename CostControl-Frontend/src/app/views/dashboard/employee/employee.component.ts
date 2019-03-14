import { Component, OnInit } from '@angular/core';
import { EmployeeService } from './employee.service';
import { Employee } from '../../../shared/models/employee.model';
import { DepartamentService } from '../departament/departament.service';
import { Departament } from '../../../shared/models/departament.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResultModel } from '../../../shared/models/result.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styles: [],
  providers: [EmployeeService, DepartamentService]
})
export class EmployeeComponent implements OnInit {

  isEmployeesCollapsed: boolean = false;
  employeesCollapse: string = 'fa fa-minus';
  employees: Employee[] = [];
  employeeForEdit: Employee;
  departaments: Departament[] = [];
  formCreateEmployee: FormGroup;
  formEditEmployee: FormGroup;

  constructor(private service: EmployeeService, private depService: DepartamentService) { }

  ngOnInit() {
    this.getEmployees();
    this.getDepartaments();
  }

  toggleCollapse(): void {
    this.isEmployeesCollapsed = !this.isEmployeesCollapsed;
    this.employeesCollapse = this.isEmployeesCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }

  createForm(): void{
    this.getDepartaments();
    this.formCreateEmployee = new FormGroup({
      'name': new FormControl(null, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]),
      'departament': new FormControl(null,[Validators.required])
    })
  }

  getEmployees(): void {
    this.service.getAll().subscribe(
      (employees: Employee[]) => {
        this.employees = employees;
      }
    )
  }

  getDepartaments(): void {
    this.depService.getAll().subscribe(
      (departaments: Departament[]) => {
        this.departaments = departaments
      }
    )
  }

  submitForm(): void{
    if(this.formCreateEmployee.status === 'INVALID'){
      this.formCreateEmployee.get('name').markAsTouched();
      this.formCreateEmployee.get('departament').markAsTouched();
    } else {
      let employee = new Employee(this.formCreateEmployee.get('name').value, this.formCreateEmployee.get('departament').value)
      this.service.saveEmployee(employee).subscribe(
        (result: ResultModel) => {
          this.getEmployees();
          this.formCreateEmployee.reset();
        }
      )
    }
  }

  editEmployee(employee: Employee): void {
    this.employeeForEdit = employee;
    this.getDepartaments();
    this.formEditEmployee = new FormGroup({
      'name': new FormControl(employee.name, [Validators.required, Validators.minLength(3), Validators.maxLength(200)]),
      'departament': new FormControl(employee.departamentId,[Validators.required])
    })
  }

  updateEmployee(): void {
    this.employeeForEdit.name = this.formEditEmployee.get('name').value;
    this.employeeForEdit.departamentId = this.formEditEmployee.get('departament').value;
    
    this.service.updateEmployee(this.employeeForEdit).subscribe(
      (result: ResultModel) => {
        this.formEditEmployee.reset();
        this.getEmployees()
      }
    )
  }

  deleteEmployee(id: number): void {
    this.service.deleteEmployee(id).subscribe(
      () => {
        this.getEmployees();
      }
    )
  }
}
