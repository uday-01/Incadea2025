import { Component, OnInit } from '@angular/core';
import { Products } from '../../Models/Products';
import { ProductService } from '../../services/product.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-allproducts',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './allproducts.component.html',
  styleUrl: './allproducts.component.scss'
})
export class AllproductsComponent implements OnInit {
  products: Products[] = [];
  constructor(private productService: ProductService, private router: Router) { }
  ngOnInit() {
    this.fetchProducts()
  }
  deleteHandler(productId: any) {
    this.productService.deleteProduct(productId).subscribe({
      next: (response) => {
        console.log("Product deleted successfully:", response);
        alert("Product Deleted Successfully");
        this.router.navigate(['/admin/allproducts']);
      },
      error: (error) => {
        console.error("Error while deleting product:", error);
      }
    });
  }
  fetchProducts() {
    this.productService.getAllProducts().subscribe({
      next: (response) => {
        console.log('Products fetched successfully:', response);
        this.products = response;
      },
      error: (error) => {
        console.error('Error fetching users:', error);
      }
    });
  }
}
