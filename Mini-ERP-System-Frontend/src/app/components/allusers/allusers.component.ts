import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Users } from '../../Models/Users';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

interface UserData {
  password: string
  role: string
  userId: number
  userName: string
}
@Component({
  selector: 'app-allusers',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './allusers.component.html',
  styleUrl: './allusers.component.scss'
})
export class AllusersComponent implements OnInit {
  users: UserData[] = [];

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.fetchUsers();
  }
  deleteHandler(userId: number) {
    this.userService.deleteUser(userId).subscribe({
      next: (response) => {
        console.log("User deleted successfully:", response);
        alert("User Deleted Successfully");
        this.router.navigate(['/admin/allusers']);
      },
      error: (error) => {
        console.error("Error while deleting user:", error);
      }
    });
  }
  fetchUsers() {
    this.userService.getAllUsers().subscribe({
      next: (response) => {
        console.log('Users fetched successfully:', response);
        this.users = response;
      },
      error: (error) => {
        console.error('Error fetching users:', error);
      }
    });
  }
}
