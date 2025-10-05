import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth';
import { LoginUser } from '../../Interfaces/LoginUser ';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router'; // ✅ Import Router

@Component({
  selector: 'app-register',
  standalone: true, // ✅ important
  templateUrl: './login.html',
  imports: [ReactiveFormsModule, CommonModule], // ✅ Add ReactiveFormsModule here
  styleUrl: './login.css'
})
export class LoginComponent {
  loginForm: FormGroup;
  successMessage = '';
  errorMessage = '';

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) { // ✅ Inject Router
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.loginForm.invalid) return;

    const loginUser: LoginUser = this.loginForm.value;

    this.authService.login(loginUser).subscribe({
      next: (res) => {
        if (res.isSuccess) {
          this.successMessage = 'Login successful!';
          this.errorMessage = '';
          console.log('Login Response:', res);
          // go to      { path: 'cuttingDownmMaster', component: CuttingDownMaster },
          // dashboard or home page
          //  this.router.navigate(['/cuttingDownMaster']);
          this.router.navigate(['/cuttingDownmMaster']);

           


          
          // You can add your logic here, e.g. saving tokens, redirect, etc.
        } else {
          this.errorMessage = res.message;
          this.successMessage = '';
        }
      },
      error: (err) => {
        this.errorMessage = err.error?.message || 'An error occurred during login.';
        this.successMessage = '';
      },
    });
  }
}
