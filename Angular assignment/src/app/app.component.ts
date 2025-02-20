import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet,FormsModule,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'FirstApp';
  username: string = "";
  password: string = "";
  isVisible = false;
  users = ['Ramya', 'Kavya', 'Bhavya'];
  selectedColor = '';
  isBold = false;
  Toggle() {
    this.isBold= !this.isBold;
  }

  toggleVisibility() {
    this.isVisible = !this.isVisible;
  }
}
