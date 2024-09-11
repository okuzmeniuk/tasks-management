import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { TaskTicket } from './task-ticket.model';
import { TaskTicketComponent } from './task-ticket/task-ticket.component';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-task-tickets',
  standalone: true,
  imports: [RouterOutlet, TaskTicketComponent, ReactiveFormsModule],
  templateUrl: './task-tickets.component.html',
  styleUrl: './task-tickets.component.css',
})
export class TaskTicketsComponent implements OnInit {
  private activatedRotue = inject(ActivatedRoute);
  private formBuilder = inject(FormBuilder);
  taskTickets$ = signal<TaskTicket[]>([]);
  error$ = signal<string | undefined>(undefined);
  isButtonClicked = signal<boolean>(false);

  addTaskTicketForm = this.formBuilder.group({
    title: '',
    description: '',
    opened: true,
  });

  ngOnInit() {
    this.activatedRotue.data.subscribe({
      next: (data) => this.taskTickets$.set(data['user'].tickets),
      error: (error) => this.error$.set(error),
    });
  }

  onAddButtonClick() {
    this.isButtonClicked.set(true);
  }
}
