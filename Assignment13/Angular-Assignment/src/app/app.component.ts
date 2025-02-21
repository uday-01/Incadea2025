import { CommonModule, UpperCasePipe } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular-Assignment';
  name: string = "";
  companyName: string = "Incadea.com"
  isLoggedIn: boolean = false;
  loginOrlogout: string = "Login";
  Data = ["Yashas", "Likith", "Anand"];
  selectedColor: string = "";
  isActive: boolean = true;
  today = new Date();
  upperCase = new UpperCasePipe();
  toggleclass() {
    console.log("BUTTON CLICKED")
    this.isLoggedIn = !this.isLoggedIn;
    this.loginOrlogout = this.isLoggedIn ? "LogOut" : "LogIn";
  }
}
