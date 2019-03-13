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

  private isDepartamentsCollapsed: boolean = false;
  private departamentsCollapse: string = 'fa fa-minus';
  private departaments: Departament[] = [];
  private formDepartament: FormGroup;

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
    this.formDepartament = new FormGroup({
      'name': new FormControl(null, [Validators.required, Validators.minLength(2), Validators.maxLength(100)])
    });
  }

  submitForm(): void {
    if(this.formDepartament.status === 'INVALID')
    {
      this.formDepartament.get('name').markAsTouched();
    } else {
      let departament = new Departament(this.formDepartament.get('name').value);
      
      this.service.saveDepartament(departament).subscribe(
        (result: ResultModel) => {
          this.getDepartaments();
          this.createForm();
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
}
