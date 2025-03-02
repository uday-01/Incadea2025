import { Component } from '@angular/core';
import { Users } from '../../Models/Users';
import { UserService } from '../../services/user.service';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-adduser',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './adduser.component.html',
  styleUrl: './adduser.component.scss'
})
export class AdduserComponent {
  user: Users = new Users();
  constructor(
    private Userservice: UserService,
    private authService: AuthService,
    private router: Router
  ) { }

  submitHandler(event: Event) {
    event.preventDefault();

    this.Userservice.addUser(this.user).subscribe({
      next: (response) => {
        console.log('User added successfully:', response);
        this.router.navigate(['admin']);
      },
      error: (error) => {
        console.error('Error adding user:', error);
      },
      complete: () => {
        console.log('User addition process completed.');
      }
    });
  }

  redirectUser() {
    const routesMap: Record<string, string> = {
      admin: '/admin',
      sales: '/sales',
      purchase: '/purchase'
    };

    const redirectPath = routesMap[this.user.Role] || '/admin';
    this.router.navigate([redirectPath]);
  }

}
