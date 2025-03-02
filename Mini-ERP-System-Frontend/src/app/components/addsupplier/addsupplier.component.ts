import { Component } from '@angular/core';
import { SupplierService } from '../../services/supplier.service';
import { Router, RouterModule } from '@angular/router';
import { Suppliers } from '../../Models/Suppliers';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-addsupplier',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './addsupplier.component.html',
  styleUrl: './addsupplier.component.scss'
})
export class AddsupplierComponent {
  constructor(private supplierService: SupplierService, private router: Router) { }
  supplier: Suppliers = {
    supplierId: 0,
    supplierName: "",
    supplierEmail: '',
    supplierAddress: ''
  };
  submitHandler(event: Event) {
    event.preventDefault();
    this.supplierService.addSupplier(this.supplier).subscribe({
      next: (res) => {
        console.log(res);
        this.router.navigate(['/admin'])
      },
      error: (err) => {
        console.log(err);
      }
    })
  }

}
