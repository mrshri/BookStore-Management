import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: false,
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  constructor(private route: Router) { }
isLoggedIn(): boolean {
  return !!localStorage.getItem('token');
}
logout() {
  localStorage.removeItem('token');
  this.route.navigate(['/login']); // redirect to login
}
}
