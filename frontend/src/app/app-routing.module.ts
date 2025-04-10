// src/app/app-routing.module.ts
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ConsultaComponent } from './pages/consulta/consulta.component';
import { HistorialComponent } from './pages/historial/historial.component';
import { RegistroComponent } from './pages/registro/registro.component';

const routes: Routes = [
  { path: 'consulta', component: ConsultaComponent },
  { path: 'historial', component: HistorialComponent },
  { path: 'registro', component: RegistroComponent },
  { path: '', redirectTo: 'consulta', pathMatch: 'full' }, // Ruta por defecto
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
