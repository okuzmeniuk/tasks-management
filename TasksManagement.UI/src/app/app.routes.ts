import { Routes } from '@angular/router';
import { AppComponent } from './app.component';
import { NoTicketsComponent } from './task-tickets/no-tickets/no-tickets.component';
import { TaskTicketsComponent } from './task-tickets/task-tickets.component';

export const routes: Routes = [
  { path: '', pathMatch: 'full', component: NoTicketsComponent },
  {
    path: 'users/:id',
    pathMatch: 'full',
    component: TaskTicketsComponent,
  },
];
