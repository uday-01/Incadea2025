import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../services/product.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-updateproduct',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './updateproduct.component.html',
  styleUrl: './updateproduct.component.scss'
})
export class UpdateproductComponent implements OnInit {
  productId: string | null = null;

  constructor(private route: ActivatedRoute, private productservice: ProductService, private router: Router) { }
  updatedProduct = {
    productName: "",
    productDescription: "",
    stocksAvailable: 0,
    price: 0
  };
  updateProduct() {
    this.productservice.updateProducts(this.productId || '', this.updatedProduct).subscribe({
      next: (response) => {
        alert("Product Updated Successfully")
        this.router.navigate(['/admin/allproducts']);
      },
      error: (error) => {
        console.error("Error updating product:", error);
      }
    });
  }

  updateHandler(event: Event) {
    event.preventDefault();
    console.log(this.updatedProduct)
    this.updateProduct();
  }
  ngOnInit() {
    this.productId = this.route.snapshot.paramMap.get('id');
    console.log('Updating Product with ID:', this.productId);
    this.productservice.getProductById(this.productId || '').subscribe({
      next: (productData) => {
        this.updatedProduct = productData;
        console.log(productData);
      },
      error: (error) => {
        console.error("Error fetching Product data:", error);
      }
    });

  }
}
