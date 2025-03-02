import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { CustomerService } from '../../services/customer.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-updatecustomer',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './updatecustomer.component.html',
  styleUrl: './updatecustomer.component.scss'
})
export class UpdatecustomerComponent {
  custId: string | null = null;

  constructor(private route: ActivatedRoute, private customerService: CustomerService, private router: Router) { }
  updatedCustomer = {
    customerName: "",
    customerEmail: "",
    customerAddress: ""
  };
  updateCustomer() {
    this.customerService.updateCustomer(this.custId || '', this.updatedCustomer).subscribe({
      next: (response) => {
        alert("Customer Updated Successfully")
        this.router.navigate(['/admin/allcustomers']);
      },
      error: (error) => {
        console.error("Error updating Customer:", error);
      }
    });
  }

  updateHandler(event: Event) {
    event.preventDefault();
    console.log(this.updatedCustomer)
    this.updateCustomer();
  }
  ngOnInit() {
    this.custId = this.route.snapshot.paramMap.get('id');
    console.log('Updating Customer with ID:', this.custId);
    this.customerService.getCustomerById(this.custId || '').subscribe({
      next: (customerData) => {
        this.updatedCustomer = customerData;
        console.log(customerData);
      },
      error: (error) => {
        console.error("Error fetching Customer data:", error);
      }
    });

  }

}
