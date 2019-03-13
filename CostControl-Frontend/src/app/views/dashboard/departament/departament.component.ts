import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-departament',
  templateUrl: './departament.component.html',
  styles: []
})
export class DepartamentComponent implements OnInit {

  private isDepartamentsCollapsed: boolean = false;
  private departamentsCollapse: string = 'fa fa-minus';

  constructor() { }

  ngOnInit() {
  }

  toggleCollapse(): void {
    this.isDepartamentsCollapsed = !this.isDepartamentsCollapsed;
    this.departamentsCollapse = this.isDepartamentsCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }
}
