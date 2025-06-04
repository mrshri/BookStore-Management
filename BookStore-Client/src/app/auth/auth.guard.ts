import { CanActivateFn } from '@angular/router';

export const authGuard: CanActivateFn = (route, state) => {
  const token = localStorage.getItem('token'); // or sessionStorage.getItem('token');
  return !!token; // true if token exists, false otherwise
};
