import { Component, OnInit } from '@angular/core';
import { Products } from '../../Models/Products';
import { FormsModule } from '@angular/forms';
import { ProductService } from '../../services/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addproduct',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './addproduct.component.html',
  styleUrl: './addproduct.component.scss'
})
export class AddproductComponent {
  constructor(private productService: ProductService, private router: Router) { }
  products: Products = {
    productId: 0,
    productName: "",
    productDescription: '',
    price: 0,
    stocksAvailable: 0
  };
  submitHandler(event: Event) {
    event.preventDefault();
    this.productService.addProduct(this.products).subscribe({
      next: (res) => {
        console.log(res);
        alert("Product Added Successfully");
        this.router.navigate(['/admin'])
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
