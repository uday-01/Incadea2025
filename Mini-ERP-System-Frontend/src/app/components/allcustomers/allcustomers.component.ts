import { Component, OnInit } from '@angular/core';
import { CUstomers } from '../../Models/Customers';
import { CustomerService } from '../../services/customer.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-allcustomers',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './allcustomers.component.html',
  styleUrl: './allcustomers.component.scss'
})
export class AllcustomersComponent implements OnInit {
  customer: CUstomers[] = [];
  constructor(private customerService: CustomerService, private router: Router) { }
  ngOnInit() {
    this.fetchCustomers()
  }
  deleteHandler(custId: any) {
    this.customerService.deleteCustomer(custId).subscribe({
      next: (response) => {
        console.log("Customer deleted successfully:", response);
        alert("Customer Deleted Successfully");
        this.router.navigate(['admin/allcustomers']);
      },
      error: (error) => {
        console.error("Error while deleting customer:", error);
      }
    });
  }
  fetchCustomers() {
    this.customerService.getAllCustomers().subscribe({
      next: (response) => {
        console.log('Customer fetched successfully:', response);
        this.customer = response;
      },
      error: (error) => {
        console.error('Error fetching Customers:', error);
      }
    });
  }
}
