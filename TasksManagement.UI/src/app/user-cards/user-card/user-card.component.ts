import { Component, input } from '@angular/core';
import { User } from '../user.model';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-user-card',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './user-card.component.html',
  styleUrl: './user-card.component.css',
})
export class UserCardComponent {
  user = input.required<User>();
}
