import { Component } from '@angular/core';
import { HeaderComponent } from "../header/header.component";
import { RouterModule } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-purchase',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './purchase.component.html',
  styleUrl: './purchase.component.scss'
})
export class PurchaseComponent {
  userRole: string = "purchase";
  constructor(private authservice: AuthService) { }
  logout() {
    this.authservice.logout()
  }
}
