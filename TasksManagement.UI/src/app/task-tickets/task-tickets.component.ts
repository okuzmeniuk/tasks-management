import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-task-tickets',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './task-tickets.component.html',
  styleUrl: './task-tickets.component.css',
})
export class TaskTicketsComponent {}
