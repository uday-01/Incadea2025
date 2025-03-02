import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { Users } from '../../Models/Users';
import { LoginService } from '../../services/login.service';
import { jwtDecode } from 'jwt-decode';
import { AuthService } from '../../services/auth.service';

interface LoginResponse {
  jwtToken: string;
}

interface DecodedToken {
  name?: string;
  role?: string;
  exp?: number;
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
  providers: [LoginService]
})
export class LoginComponent {
  user: Users = new Users();
  token: string = "";
  userRole: string = "";
  userName: string = '';

  constructor(
    private loginService: LoginService,
    private authService: AuthService,
    private router: Router
  ) { }

  submitHandler(event: Event) {
    event.preventDefault();

    this.loginService.userLogin(this.user).subscribe({
      next: (res: LoginResponse) => {
        this.token = res.jwtToken;
        this.authService.setToken(this.token);

        const decodedToken: DecodedToken = jwtDecode(this.token);
        this.userRole = decodedToken.role || "";
        this.userName = decodedToken.name || "User";

        localStorage.setItem('role', this.userRole);

        console.log("User Role:", this.userRole);
        console.log("Token:", this.token);

        this.redirectUser();
      },
      error: (err) => {
        console.error("Login Error:", err);
        alert(err.error?.message || "Login failed. Please try again.");
      }
    });
  }

  redirectUser() {
    const routesMap: Record<string, string> = {
      admin: '/admin',
      sales: '/sales',
      purchase: '/purchase'
    };

    const redirectPath = routesMap[this.userRole] || '/';
    this.router.navigate([redirectPath]);
  }
}
