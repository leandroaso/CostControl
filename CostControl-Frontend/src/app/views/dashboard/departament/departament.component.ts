import { Component, OnInit } from '@angular/core';
import { DepartamentService } from './departament.service';
import { Departament } from '../../../shared/models/departament.model';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ResultModel } from '../../../shared/models/result.model';

@Component({
  selector: 'app-departament',
  templateUrl: './departament.component.html',
  styles: [],
  providers: [ DepartamentService ]
})
export class DepartamentComponent implements OnInit {

  isDepartamentsCollapsed: boolean = false;
  departamentsCollapse: string = 'fa fa-minus';
  departaments: Departament[] = [];
  formCreateDepartament: FormGroup;
  formEditDepartament: FormGroup;
  departamentForEdit: Departament;

  constructor(private service: DepartamentService) { }

  ngOnInit() {
    this.getDepartaments();
    this.createForm();
  }

  toggleCollapse(): void {
    this.isDepartamentsCollapsed = !this.isDepartamentsCollapsed;
    this.departamentsCollapse = this.isDepartamentsCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }

  getDepartaments(): void {
    this.service.getAll().subscribe(
      (departaments: Departament[]) => { 
        this.departaments = departaments
      }
    )
  }

  createForm(): void {
    this.formCreateDepartament = new FormGroup({
      'name': new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(100)])
    });
  }

  submitForm(): void {
    if(this.formCreateDepartament.status === 'INVALID')
    {
      this.formCreateDepartament.get('name').markAsTouched();
    } else {
      let departament = new Departament(this.formCreateDepartament.get('name').value);
      
      this.service.saveDepartament(departament).subscribe(
        (result: ResultModel) => {
          this.getDepartaments();
          this.formCreateDepartament.reset();
        }
      )
    }
  }

  deleteDepartament(id: number): void {
    this.service.deleteDepartament(id).subscribe(
      (result: ResultModel) => {
        this.getDepartaments();
      }
    )
  }

  editDepartament(departament: Departament): void{
    this.departamentForEdit = departament;
    this.formEditDepartament = new FormGroup({
      'name': new FormControl(departament.name, [Validators.required, Validators.minLength(2), Validators.maxLength(100)])
    })
  }

  updateDepartament(): void{
    this.departamentForEdit.name = this.formEditDepartament.get('name').value;

    this.service.updateDepartament(this.departamentForEdit).subscribe(
      (result: ResultModel) => {
        this.formEditDepartament.controls['name'].setValue(null);
        this.formEditDepartament.reset();
      }
    )
  }
}
