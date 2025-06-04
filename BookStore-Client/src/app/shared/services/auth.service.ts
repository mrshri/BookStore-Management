import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7030/api/auth';

  constructor(private http:HttpClient) { }


register(user: any): Observable<any> {
  return this.http.post('https://localhost:7030/api/auth/register', user);
}

assignRole(user: any): Observable<any> {
  return this.http.post('https://localhost:7030/api/auth/AssignRole', user);
}

  login(credentials: any): Observable<any> {
     return this.http.post(`${this.apiUrl}/login`, credentials).pipe(
      tap((res: any) => {
        // Store the token in localStorage
        localStorage.setItem('token', res.token);
      })
    );
  }

  logout() {
    localStorage.removeItem('token');
  }

  isLoggedIn(): boolean {
    return !!localStorage.getItem('token');
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }
}
