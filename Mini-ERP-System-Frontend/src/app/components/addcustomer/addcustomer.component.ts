import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';
import { Router } from '@angular/router';
import { CUstomers } from '../../Models/Customers';

@Component({
  selector: 'app-addcustomer',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './addcustomer.component.html',
  styleUrl: './addcustomer.component.scss'
})
export class AddcustomerComponent {
  constructor(private customerService: CustomerService, private router: Router) { }
  customer: CUstomers = {
    customerId: 0,
    customerName: "",
    customerEmail: '',
    customerAddress: ''
  };
  submitHandler(event: Event) {
    event.preventDefault();
    this.customerService.addCustomer(this.customer).subscribe({
      next: (res) => {
        console.log(res);
        alert("Customer Added Successfully");
        this.router.navigate(['/admin'])
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

}
