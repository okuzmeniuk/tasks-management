import { Component, inject, OnInit, signal } from '@angular/core';
import { User } from './user.model';
import { UserCardComponent } from './user-card/user-card.component';
import { UsersService } from './users.service';
import { AddUserCardComponent } from './add-user-card/add-user-card.component';

@Component({
  selector: 'app-user-cards',
  standalone: true,
  imports: [UserCardComponent, AddUserCardComponent],
  templateUrl: './user-cards.component.html',
  styleUrl: './user-cards.component.css',
})
export class UserCardsComponent implements OnInit {
  users$ = signal<User[]>([]);
  error$ = signal<string | undefined>(undefined);
  private usersService = inject(UsersService);

  ngOnInit() {
    this.usersService.getUsers().subscribe({
      next: (users) => this.users$.set(users),
      error: (error) => this.error$.set(error),
    });
  }
}
