import { MovementsService } from './../../services/movements.service';
import { Component, OnInit } from '@angular/core';


interface Movements {
  id: number;
  fecha: Date;
  monto: number;
  TipoDeTransaccion: {
    id: number;
    nombre: string;
  };
}

@Component({
  selector: 'app-last-movements',
  templateUrl: './last-movements.component.html',
  styleUrls: ['./last-movements.component.scss']
})
export class LastMovementsComponent implements OnInit {

  showError = false;

  lastMovements: Movements[] = [];

  constructor(private movemenetsService: MovementsService) { }

  ngOnInit(): void {
    this.movemenetsService.getLastMovoments().subscribe((response) => {
      this.showError = false;
      this.lastMovements = response.data as Movements[];
    }, error => {
      this.showError = true;
    });
  }
}
