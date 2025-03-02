import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor() { }

  setToken(token: string): void {
    localStorage.setItem('token', token);
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isLoggedIn(): boolean {
    const token = this.getToken();
    return token ? !this.isTokenExpired(token) : false;
  }

  isTokenExpired(token: string): boolean {
    try {
      const decoded: any = jwtDecode(token);
      return decoded.exp * 1000 < Date.now();
    } catch (error) {
      return true;
    }
  }

  getUserRole(): string {
    const token = this.getToken();
    if (!token) return '';

    try {
      const decoded: any = jwtDecode(token);
      return decoded.role || '';
    } catch (error) {
      return '';
    }
  }

  logout(): void {
    localStorage.removeItem('token');
    localStorage.removeItem('role');
    window.location.href = '/';
  }
}
