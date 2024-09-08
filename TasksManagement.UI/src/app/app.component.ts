import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { TaskTicketsComponent } from './task-tickets/task-tickets.component';
import { UserCardsComponent } from './user-card/user-cards/user-cards.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    HeaderComponent,
    TaskTicketsComponent,
    UserCardsComponent,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'TasksManagement.UI';
}
