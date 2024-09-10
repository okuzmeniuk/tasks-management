import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { TaskTicket } from './task-ticket.model';
import { TaskTicketComponent } from './task-ticket/task-ticket.component';

@Component({
  selector: 'app-task-tickets',
  standalone: true,
  imports: [RouterOutlet, TaskTicketComponent],
  templateUrl: './task-tickets.component.html',
  styleUrl: './task-tickets.component.css',
})
export class TaskTicketsComponent implements OnInit {
  private activatedRotue = inject(ActivatedRoute);
  taskTickets$ = signal<TaskTicket[]>([]);
  error$ = signal<string | undefined>(undefined);

  ngOnInit() {
    this.activatedRotue.data.subscribe({
      next: (data) => this.taskTickets$.set(data['user'].tickets),
      error: (error) => this.error$.set(error),
    });
  }
}
