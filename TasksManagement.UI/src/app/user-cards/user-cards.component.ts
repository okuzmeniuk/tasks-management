import { Component } from '@angular/core';
import { User } from './user.model';
import { UserCardComponent } from './user-card/user-card.component';

@Component({
  selector: 'app-user-cards',
  standalone: true,
  imports: [UserCardComponent],
  templateUrl: './user-cards.component.html',
  styleUrl: './user-cards.component.css',
})
export class UserCardsComponent {
  users: User[] = [
    { id: '1', username: 'user1', tickets: [] },
    { id: '2', username: 'user2', tickets: [] },
    { id: '3', username: 'user3', tickets: [] },
    { id: '4', username: 'user4', tickets: [] },
  ];
}
