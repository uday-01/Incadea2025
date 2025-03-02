import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Suppliers } from '../Models/Suppliers';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {
  private addSuppUrl = "https://localhost:7213/api/supplier"
  private GetSuppsUrl = "https://localhost:7213/api/suppliers"
  private updateSupUrl = "https://localhost:7213/api/supplier";
  private deleteSuppUrl = "https://localhost:7213/api/supplier";
  constructor(private http: HttpClient, private authservice: AuthService) { }
  addSupplier(supp: Suppliers): Observable<string> {
    return this.http.post(this.addSuppUrl, supp, { responseType: 'text' });
  }
  getAllSuppliers(): Observable<Suppliers[]> {
    return this.http.get<Suppliers[]>(this.GetSuppsUrl);
  }
  updateSupplier(id: string, supp: Partial<Suppliers>): Observable<string> {
    return this.http.put(`${this.updateSupUrl}/${id}`, supp, { responseType: 'text' });
  }
  getSupplierById(id: any): Observable<Suppliers> {
    return this.http.get<Suppliers>(`${this.updateSupUrl}/${id}`)
  }
  deleteSupplier(suppId: string) {
    return this.http.delete(`${this.deleteSuppUrl}/${suppId}`, { responseType: 'text' });
  }
}
