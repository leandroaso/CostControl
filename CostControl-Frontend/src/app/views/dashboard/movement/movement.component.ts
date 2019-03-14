import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-movement',
  templateUrl: './movement.component.html',
  styles: []
})
export class MovementComponent implements OnInit {
  
  isMovementsCollapsed: boolean = false;
  movementsCollapse: string = 'fa fa-minus';

  constructor() { }

  ngOnInit() {
  }

  toggleCollapse(): void {
    this.isMovementsCollapsed = !this.isMovementsCollapsed;
    this.movementsCollapse = this.isMovementsCollapsed ? 'fa fa-window-restore' : 'fa fa-minus';
  }
}
