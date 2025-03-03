import { Component } from '@angular/core';
import { PurchaseorderService } from '../../services/purchaseorder.service';
import { Router, RouterModule } from '@angular/router';
import { PurchaseOrder } from '../../Models/PurchaseOrder';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-addpurchaseorder',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './addpurchaseorder.component.html',
  styleUrl: './addpurchaseorder.component.scss'
})
export class AddpurchaseorderComponent {
  constructor(private purchaseOrderService: PurchaseorderService, private router: Router) { }
  purchaseOrder: PurchaseOrder = {
    purchaseOrderId: 0,
    supplierId: 0,
    productId: 0,
    userId: 0,
    quantityPurchased: 0,
    totalPurchaseAmount: 0
  };
  submitHandler(event: Event) {
    event.preventDefault();
    this.purchaseOrderService.addpurchase(this.purchaseOrder).subscribe({
      next: (res) => {
        console.log(res);

        alert("Purchase Order Added Successfully");
        this.router.navigate(['/purchase'])
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

}
