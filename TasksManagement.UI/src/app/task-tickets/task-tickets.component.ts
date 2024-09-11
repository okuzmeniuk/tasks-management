import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterOutlet } from '@angular/router';
import { TaskTicket } from './task-ticket.model';
import { TaskTicketComponent } from './task-ticket/task-ticket.component';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { TaskTicketsService } from './task-tickets.service';
import { UsersService } from '../user-cards/users.service';

@Component({
  selector: 'app-task-tickets',
  standalone: true,
  imports: [RouterOutlet, TaskTicketComponent, ReactiveFormsModule],
  templateUrl: './task-tickets.component.html',
  styleUrl: './task-tickets.component.css',
})
export class TaskTicketsComponent implements OnInit {
  private activatedRoute = inject(ActivatedRoute);
  private formBuilder = inject(FormBuilder);
  private usersService = inject(UsersService);
  private taskTicketsService = inject(TaskTicketsService);

  taskTickets$ = signal<TaskTicket[]>([]);
  error$ = signal<string | undefined>(undefined);
  showForm = signal<boolean>(false);
  formErrors = signal<string[]>([]);
  currentUserId = signal<string>('');

  addTaskTicketForm = this.formBuilder.group({
    title: ['', [Validators.required, Validators.minLength(3)]],
    description: ['', Validators.required],
    opened: true,
  });

  ngOnInit() {
    this.activatedRoute.params.subscribe({
      next: (params) => {
        this.currentUserId.set(params['id']);
        this.resetForm();

        this.usersService.getUser(this.currentUserId()).subscribe({
          next: (user) => this.taskTickets$.set(user.tickets),
          error: (error) => this.error$.set(error),
        });
      },
    });
  }

  onAddButtonClick() {
    this.showForm.set(true);
  }

  resetForm() {
    this.addTaskTicketForm.reset();
    this.showForm.set(false);
  }

  onFormSubmit() {
    if (this.addTaskTicketForm.invalid) {
      return;
    }

    const title = this.addTaskTicketForm.get('title')!.value!;
    const description = this.addTaskTicketForm.get('description')!.value!;
    const opened =
      this.addTaskTicketForm.get('opened')?.value ?? false ? 'Open' : 'Closed';

    const taskTicketToAdd: TaskTicket = {
      id: '',
      title,
      description,
      status: opened,
      personId: this.currentUserId(),
    };

    this.taskTicketsService.postTaskTicket(taskTicketToAdd).subscribe({
      next: (taskTicket) =>
        this.taskTickets$.set([...this.taskTickets$(), taskTicket]),
      error: (error) => console.log(error),
    });

    this.resetForm();
  }
}
