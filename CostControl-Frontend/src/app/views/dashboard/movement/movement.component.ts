import { Component, OnInit } from '@angular/core';
import { Movement } from '../../../shared/models/movement.model';
import { MovementService } from './movement.service';

@Component({
  selector: 'app-movement',
  templateUrl: './movement.component.html',
  styles: [],
  providers: [MovementService]
})
export class MovementComponent implements OnInit {
  totalItems: number;
  currentPage: number = 1;
  movements: Movement[] = [];
  
  isMovementsCollapsed: boolean = false;
  movementsCollapse: string = 'fa fa-minus';

  constructor(private service: MovementService) { }

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
}
