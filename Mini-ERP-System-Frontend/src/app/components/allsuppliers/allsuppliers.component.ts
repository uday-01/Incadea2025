import { Component, OnInit } from '@angular/core';
import { Suppliers } from '../../Models/Suppliers';
import { SupplierService } from '../../services/supplier.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-allsuppliers',
  standalone: true,
  imports: [RouterModule, CommonModule, FormsModule],
  templateUrl: './allsuppliers.component.html',
  styleUrl: './allsuppliers.component.scss'
})
export class AllsuppliersComponent implements OnInit {
  supplier: Suppliers[] = [];
  constructor(private supplierService: SupplierService, private router: Router) { }
  ngOnInit() {
    this.fetchSuppliers()
  }
  deleteHandler(suppId: any) {
    this.supplierService.deleteSupplier(suppId).subscribe({
      next: (response) => {
        console.log("Supplier deleted successfully:", response);
        alert("Supplier Deleted Successfully");
        this.router.navigate(['admin/allsuppliers']);
      },
      error: (error) => {
        console.error("Error while deleting suppliers:", error);
      }
    });
  }
  fetchSuppliers() {
    this.supplierService.getAllSuppliers().subscribe({
      next: (response) => {
        console.log('Supplier fetched successfully:', response);
        this.supplier = response;
      },
      error: (error) => {
        console.error('Error fetching Suppliers:', error);
      }
    });
  }
}
