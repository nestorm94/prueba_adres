import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-historial',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatTableModule],
  templateUrl: './historial.component.html',
  styleUrls: ['./historial.component.css']
})
export class HistorialComponent {
  displayedColumns: string[] = ['id', 'descripcion'];
  data = [
    { id: 1, descripcion: 'Compra de impresora' },
    { id: 2, descripcion: 'Mantenimiento de equipos' },
    { id: 3, descripcion: 'Licencias de software' }
  ];
}
