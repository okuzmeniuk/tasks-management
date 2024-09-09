import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TaskTicket } from './task-ticket.model';
import { TaskTicketComponent } from './task-ticket/task-ticket.component';

@Component({
  selector: 'app-task-tickets',
  standalone: true,
  imports: [RouterOutlet, TaskTicketComponent],
  templateUrl: './task-tickets.component.html',
  styleUrl: './task-tickets.component.css',
})
export class TaskTicketsComponent {
  taskTickets: TaskTicket[] = [
    {
      id: '1',
      title: 'Task 1',
      description: 'bbbbbb',
      status: 'Open',
      personId: '1',
    },
    {
      id: '2',
      title: 'Task 2',
      description: 'aaaa',
      status: 'Closed',
      personId: '2',
    },
  ];
}
