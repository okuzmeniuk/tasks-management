import { Component, inject, OnInit, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TaskTicket } from './task-ticket.model';
import { TaskTicketComponent } from './task-ticket/task-ticket.component';
import { UsersService } from '../user-cards/users.service';

@Component({
  selector: 'app-task-tickets',
  standalone: true,
  imports: [RouterOutlet, TaskTicketComponent],
  templateUrl: './task-tickets.component.html',
  styleUrl: './task-tickets.component.css',
})
export class TaskTicketsComponent implements OnInit {
  private usersService = inject(UsersService);
  taskTickets$ = signal<TaskTicket[]>([]);
  error$ = signal<string | undefined>(undefined);
  personId = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

  ngOnInit() {
    this.usersService.getUser(this.personId).subscribe({
      next: (user) => this.taskTickets$.set(user.tickets),
      error: (error) => this.error$.set(error),
    });
  }
}
