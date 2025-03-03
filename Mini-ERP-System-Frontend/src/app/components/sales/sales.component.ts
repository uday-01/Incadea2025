import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-sales',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './sales.component.html',
  styleUrl: './sales.component.scss'
})
export class SalesComponent {
  userRole: string = "sales";
  constructor(private authservice: AuthService) { }
  logout() {
    this.authservice.logout()
  }
}
