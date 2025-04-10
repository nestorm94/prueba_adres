// src/app/app.routes.ts
import { Routes } from '@angular/router';
import { ConsultaComponent } from './pages/consulta/consulta.component';
import { HistorialComponent } from './pages/historial/historial.component';
import { RegistroComponent } from './pages/registro/registro.component';

export const appRoutes: Routes = [
  { path: 'consulta', component: ConsultaComponent },
  { path: 'historial', component: HistorialComponent },
  { path: 'registro', component: RegistroComponent },
  { path: '', redirectTo: 'consulta', pathMatch: 'full' }
];
