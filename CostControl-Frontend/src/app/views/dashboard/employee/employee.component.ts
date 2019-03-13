import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styles: []
})
export class EmployeeComponent implements OnInit {
  private isEmployeesCollapsed: boolean = false;
  private employeesCollapse: string = 'fa fa-minus';

  constructor() { }

  ngOnInit() {
  }

  toggleCollapse(): void {
    this.isEmployeesCollapsed = !this.isEmployeesCollapsed;
    this.employeesCollapse = this.isEmployeesCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }
}
