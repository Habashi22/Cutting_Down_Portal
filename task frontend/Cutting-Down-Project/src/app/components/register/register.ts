import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth';
import { CommonModule } from '@angular/common'; // for *ngIf, etc.

@Component({
  selector: 'app-register',
  standalone: true, // ✅ important
  templateUrl: './register.html',
  imports: [ReactiveFormsModule, CommonModule], // ✅ Add ReactiveFormsModule here
  styleUrl: './register.css'
})
export class RegisterComponent {
  registerForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';

  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      userName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]],
      confirmPassword: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.registerForm.invalid) return;

    this.authService.register(this.registerForm.value).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.successMessage = res.message;
          this.errorMessage = '';
        } else {
          this.errorMessage = res.message;
          this.successMessage = '';
        }
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'An error occurred';
        this.successMessage = '';
      }
    });
  }
}
