import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Users } from '../Models/Users';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { AuthService } from './auth.service';

interface LoginResponse {
  jwtToken: string;
}

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private url = "https://localhost:7213/auth/userlogin";

  constructor(private http: HttpClient, private authService: AuthService) { }

  userLogin(user: Users): Observable<LoginResponse> {
    return this.http.post<LoginResponse>(this.url, user).pipe(
      tap(response => {
        if (response.jwtToken) {
          this.authService.setToken(response.jwtToken);
        }
      })
    );
  }
}
