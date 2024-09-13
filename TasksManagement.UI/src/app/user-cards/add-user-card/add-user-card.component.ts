import { Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-user-card',
  standalone: true,
  imports: [ReactiveFormsModule],
  templateUrl: './add-user-card.component.html',
  styleUrl: './add-user-card.component.css',
})
export class AddUserCardComponent {
  private formBuilder = inject(FormBuilder);
  showForm = signal<boolean>(false);

  addUserCardForm = this.formBuilder.group({
    username: [
      '',
      [Validators.required, Validators.minLength(3), Validators.maxLength(20)],
    ],
  });

  onAddClick() {
    this.showForm.set(true);
  }
}
