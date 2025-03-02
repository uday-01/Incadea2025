import { Component } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { SupplierService } from '../../services/supplier.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-updatesupplier',
  standalone: true,
  imports: [FormsModule, RouterModule, CommonModule],
  templateUrl: './updatesupplier.component.html',
  styleUrl: './updatesupplier.component.scss'
})
export class UpdatesupplierComponent {
  suppId: string | null = null;

  constructor(private route: ActivatedRoute, private supplierservice: SupplierService, private router: Router) { }
  updatedSupplier = {
    supplierName: "",
    supplierEmail: "",
    supplierAddress: ""
  };
  updateSupplier() {
    this.supplierservice.updateSupplier(this.suppId || '', this.updatedSupplier).subscribe({
      next: (response) => {
        alert("Supplier Updated Successfully")
        this.router.navigate(['/admin/allsuppliers']);
      },
      error: (error) => {
        console.error("Error updating Supplier:", error);
      }
    });
  }

  updateHandler(event: Event) {
    event.preventDefault();
    console.log(this.updatedSupplier)
    this.updateSupplier();
  }
  ngOnInit() {
    this.suppId = this.route.snapshot.paramMap.get('id');
    console.log('Updating Supplier with ID:', this.suppId);
    this.supplierservice.getSupplierById(this.suppId || '').subscribe({
      next: (supplierData) => {
        this.updatedSupplier = supplierData;
        console.log(supplierData);
      },
      error: (error) => {
        console.error("Error fetching Supplier data:", error);
      }
    });

  }

}
