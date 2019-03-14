import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { PaginationModule } from 'ngx-bootstrap/pagination';

import { DashboardComponent } from './dashboard.component';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { EmployeeComponent } from './employee/employee.component';
import { DepartamentComponent } from './departament/departament.component';
import { MovementComponent } from './movement/movement.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DashboardRoutingModule,
    ChartsModule,
    BsDropdownModule,
    ReactiveFormsModule,
    ButtonsModule.forRoot(),
    PopoverModule.forRoot(),
    PaginationModule.forRoot()
  ],
  declarations: [ DashboardComponent, EmployeeComponent, DepartamentComponent, MovementComponent ]
})
export class DashboardModule { }
