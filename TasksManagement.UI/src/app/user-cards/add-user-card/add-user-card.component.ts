import { Component, inject, output, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { UsersService } from '../users.service';
import { User } from '../user.model';

@Component({
  selector: 'app-add-user-card',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-user-card.component.html',
  styleUrl: './add-user-card.component.css',
})
export class AddUserCardComponent {
  private formBuilder = inject(FormBuilder);
  private usersService = inject(UsersService);
  showForm = signal<boolean>(false);
  userAdded = output<User>();

  addUserCardForm = this.formBuilder.group({
    username: [
      '',
      [Validators.required, Validators.minLength(3), Validators.maxLength(20)],
    ],
  });

  onAddClick() {
    this.showForm.set(true);
  }

  resetForm() {
    this.addUserCardForm.reset();
    this.showForm.set(false);
  }

  onFormSubmit() {
    if (this.addUserCardForm.invalid) {
      return;
    }

    const username: string = this.addUserCardForm.get('username')?.value!;
    this.usersService
      .postUser({ username: username, id: '', tickets: [] })
      .subscribe({
        next: (user) => {
          this.userAdded.emit(user);
        },
      });
    this.resetForm();
  }
}
