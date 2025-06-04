import { Component } from '@angular/core';
import { AuthService } from '../../shared/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone: false,
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

    user = {
    email: '',
    name: '',
    phoneNumber: '',
    password: '',
    role: ''
  };
  constructor(private authService:AuthService,private router:Router) { }

  register() {
  this.authService.register(this.user).subscribe({
    next: () => {
      // Call assign role only after successful registration
      this.authService.assignRole(this.user).subscribe({
        next: () => {
          alert('Registration and role assignment successful');
          this.router.navigate(['/login']);
        },
        error: () => alert('Role assignment failed')
      });
    },
    error: () => alert('Registration failed')
  });
}
}
