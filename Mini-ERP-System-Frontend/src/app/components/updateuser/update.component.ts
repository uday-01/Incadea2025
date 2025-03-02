import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../services/user.service';
import { Users } from '../../Models/Users';

@Component({
  selector: 'app-update',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './update.component.html',
  styleUrl: './update.component.scss'
})
export class UpdateComponent implements OnInit {
  userId: string | null = null;

  constructor(private route: ActivatedRoute, private userService: UserService, private router: Router) { }
  updatedUser = {
    userName: "",
    role: "",
    password: ""
  };
  updateUser() {
    this.userService.updateUser(this.userId || '', this.updatedUser).subscribe({
      next: (response) => {
        alert("User Updated Successfully")
        this.router.navigate(['/admin/allusers']);
      },
      error: (error) => {
        console.error("Error updating user:", error);
      }
    });
  }

  updateHandler() {
    console.log(this.updatedUser)
    this.updateUser();
  }
  ngOnInit() {
    this.userId = this.route.snapshot.paramMap.get('id');
    console.log('Updating user with ID:', this.userId);
    this.userService.getUserById(this.userId || '').subscribe({
      next: (userData) => {
        this.updatedUser = userData;
        console.log(userData);
        // this.redirectUser();
      },
      error: (error) => {
        console.error("Error fetching user data:", error);
      }
    });

  }
  redirectUser() {
    const routesMap: Record<string, string> = {
      admin: '/admin',
      sales: '/sales',
      purchase: '/purchase'
    };

    const redirectPath = routesMap[this.updatedUser.role] || '/admin';
    this.router.navigate([redirectPath]);
  }
}
