import { Component, input } from '@angular/core';
import { TaskTicket } from '../task-ticket.model';

@Component({
  selector: 'app-task-ticket',
  standalone: true,
  imports: [],
  templateUrl: './task-ticket.component.html',
  styleUrl: './task-ticket.component.css',
})
export class TaskTicketComponent {
  taskTicket = input.required<TaskTicket>();
}
