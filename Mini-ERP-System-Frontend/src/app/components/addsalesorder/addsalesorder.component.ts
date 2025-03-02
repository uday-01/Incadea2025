import { Component } from '@angular/core';
import { SalesorderService } from '../../services/salesorder.service';
import { Router, RouterModule } from '@angular/router';
import { SalesOrder } from '../../Models/salesOrder';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-addsalesorder',
  standalone: true,
  imports: [FormsModule, RouterModule, CommonModule],
  templateUrl: './addsalesorder.component.html',
  styleUrl: './addsalesorder.component.scss'
})
export class AddsalesorderComponent {
  constructor(private salesOrderservice: SalesorderService, private router: Router) { }
  salesOrder: SalesOrder = {
    salesOrderId: 0,
    customerId: 0,
    productId: 0,
    userId: 0,
    quantitySold: 0,
    totalSalesAmount: 0
  };
  submitHandler(event: Event) {
    event.preventDefault();
    this.salesOrderservice.addSales(this.salesOrder).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/sales'])
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
