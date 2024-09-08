import { Component, input } from '@angular/core';
import { User } from '../user.model';

@Component({
  selector: 'app-user-cards',
  standalone: true,
  imports: [],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css',
})
export class UserCardComponent {
  user = input.required<User>();
}
