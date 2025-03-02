import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { PurchaseOrder } from '../../Models/PurchaseOrder';
import { PurchaseorderService } from '../../services/purchaseorder.service';
import { SupplierService } from '../../services/supplier.service';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-allpurchaseorder',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './allpurchaseorder.component.html',
  styleUrl: './allpurchaseorder.component.scss'
})
export class AllpurchaseorderComponent implements OnInit {
  purchaseOrders: PurchaseOrder[] = [];
  suppliers: any[] = [];
  products: any[] = [];
  isLoading: boolean = true;
  errorMessage: string | null = null;

  constructor(
    private purchaseOrderService: PurchaseorderService,
    private supplierService: SupplierService,
    private productService: ProductService,
    private router: Router
  ) { }

  ngOnInit() {
    this.fetchPurchaseOrders();
    this.fetchSuppliers();
    this.fetchProducts();
  }

  fetchPurchaseOrders() {
    this.purchaseOrderService.getAllPurchaseOrders().subscribe({
      next: (response) => {
        console.log('Purchase Orders fetched successfully:', response);
        this.purchaseOrders = response.map(order => ({
          ...order,
          totalPurchaseAmount: this.calculateTotalAmount(order.productId, order.quantityPurchased)
        }));
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching Purchase Orders:', error);
        this.errorMessage = 'Failed to load purchase orders. Please try again.';
        this.isLoading = false;
      }
    });
  }

  fetchSuppliers() {
    this.supplierService.getAllSuppliers().subscribe({
      next: (response) => {
        this.suppliers = response;
      },
      error: (error) => {
        console.error('Error fetching suppliers:', error);
      }
    });
  }

  fetchProducts() {
    this.productService.getAllProducts().subscribe({
      next: (response) => {
        this.products = response;
      },
      error: (error) => {
        console.error('Error fetching products:', error);
      }
    });
  }

  getSupplierName(supplierId: number): string {
    const supplier = this.suppliers.find(s => s.supplierId === supplierId);
    return supplier ? supplier.supplierName : 'Unknown Supplier';
  }

  getProductName(productId: number): string {
    const product = this.products.find(p => p.productId === productId);
    return product ? product.productName : 'Unknown Product';
  }

  calculateTotalAmount(productId: number, quantity: number): number {
    const product = this.products.find(p => p.productId === productId);
    return product ? product.price * quantity : 0;
  }


  trackByPurchaseOrder(index: number, order: PurchaseOrder): number {
    return order.purchaseOrderId;
  }
}
