import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms'; // <-- Importa esto

@Component({
  selector: 'app-consulta',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './consulta.component.html',
  styleUrls: ['./consulta.component.css']
})
export class ConsultaComponent {
  // Lista de datos simulada con todos los campos del registro
  datosConsulta = [
    {
      Id: 1,
      presupuesto: 1000000,
      unidad: 'Dirección de Medicamentos y Tecnologías en Salud',
      tipo: 'Medicamentos',
      cantidad: '10.000 unidades',
      valorUnitario: '$1.000',
      valorTotal: '$10.000.000',
      fecha: new Date('2023-07-20'),
      proveedor: 'Laboratorios Bayer S.A.',
      documentacion: 'Orden de compra No. 2023-07-20-001, factura No. 2023-07-20-001'
    },
    {
      Id: 2,
      presupuesto: 5000000,
      unidad: 'Oficina TIC',
      tipo: 'Equipos de Cómputo',
      cantidad: '500 unidades',
      valorUnitario: '$2.000.000',
      valorTotal: '$1.000.000.000',
      fecha: new Date('2023-06-15'),
      proveedor: 'Lenovo Colombia S.A.S.',
      documentacion: 'Orden No. 2023-06-15-002, factura No. 2023-06-16-005'
    }
  ];

  busquedaProveedor = '';

  mostrarModal = false;
  mostrarModalEditar = false;

  itemSeleccionado: any = null;
  itemEditable: any = {
    Id: '',
    presupuesto: '',
    unidad: '',
    tipo: '',
    cantidad: '',
    valorUnitario: '',
    valorTotal: '',
    fecha: '',
    proveedor: '',
    documentacion: ''
  };

  // Métodos
  verDetalle(item: any) {
    this.itemSeleccionado = item;
    this.mostrarModal = true;
  }

  cerrarModal() {
    this.mostrarModal = false;
    this.itemSeleccionado = null;
  }

  editar(item: any) {
    this.itemEditable = { ...item };
    this.mostrarModalEditar = true;
  }

  cerrarModalEditar() {
    this.mostrarModalEditar = false;
  }

  eliminar(item: any) {
    const confirmacion = confirm(`¿Estás seguro de eliminar el ítem ID ${item.Id}?`);
    if (confirmacion) {
      this.datosConsulta = this.datosConsulta.filter(d => d.Id !== item.Id);
    }
  }

  guardarCambios() {
    const index = this.datosConsulta.findIndex(i => i.Id === this.itemEditable.Id);
    if (index !== -1) {
      this.datosConsulta[index] = { ...this.itemEditable };
    }
    this.cerrarModalEditar();
  }
}