import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { SalesOrder } from '../../Models/salesOrder';
import { SalesorderService } from '../../services/salesorder.service';
import { CustomerService } from '../../services/customer.service';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-allsalesorder',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './allsalesorder.component.html',
  styleUrl: './allsalesorder.component.scss'
})
export class AllsalesorderComponent implements OnInit {
  salesOrder: SalesOrder[] = [];
  customers: any[] = [];
  products: any[] = [];
  isLoading: boolean = true;
  errorMessage: string | null = null;

  constructor(
    private salesOrderService: SalesorderService,
    private customerService: CustomerService,
    private productService: ProductService,
    private router: Router
  ) { }

  ngOnInit() {
    this.fetchSalesOrders();
    this.fetchCustomers();
    this.fetchProducts();
  }

  fetchSalesOrders() {
    this.salesOrderService.getAllSalesOrders().subscribe({
      next: (response) => {
        console.log('Sales Orders fetched successfully:', response);
        this.salesOrder = response.map(order => ({
          ...order,
          totalSalesAmount: this.calculateTotalAmount(order.productId, order.quantitySold)
        }));
        this.isLoading = false;
      },
      error: (error) => {
        console.error('Error fetching Sales Orders:', error);
        this.errorMessage = 'Failed to load sales orders. Please try again.';
        this.isLoading = false;
      }
    });
  }

  fetchCustomers() {
    this.customerService.getAllCustomers().subscribe({
      next: (response) => {
        this.customers = response;
      },
      error: (error) => {
        console.error('Error fetching customers:', error);
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


  getCustomerName(customerId: number): string {
    const customer = this.customers.find(c => c.customerId === customerId);
    return customer ? customer.customerName : 'Unknown Customer';
  }

  getProductName(productId: number): string {
    const product = this.products.find(p => p.productId === productId);
    return product ? product.productName : 'Unknown Product';
  }

  calculateTotalAmount(productId: number, quantity: number): number {
    const product = this.products.find(p => p.productId === productId);
    return product ? product.price * quantity : 0;
  }

  trackBySalesOrder(index: number, order: SalesOrder): number {
    return order.salesOrderId;
  }
}
