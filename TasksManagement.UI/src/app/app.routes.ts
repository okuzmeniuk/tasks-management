import { Routes } from '@angular/router';
import { TaskTicketsComponent } from './task-tickets/task-tickets.component';

export const routes: Routes = [
  // { path: '', pathMatch: 'full' },
  {
    path: 'users/:id',
    pathMatch: 'full',
    component: TaskTicketsComponent,
  },
];
