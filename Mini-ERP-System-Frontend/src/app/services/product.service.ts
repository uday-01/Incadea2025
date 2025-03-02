import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Products } from '../Models/Products';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private addProUrl = "https://localhost:7213/api/product";
  private getProsUrl = "https://localhost:7213/api/products"
  private updateProUrl = "https://localhost:7213/api/product";
  private deleteprodUrl = "https://localhost:7213/api/product";
  constructor(private http: HttpClient, private authservice: AuthService) {
  }
  addProduct(Product: Products): Observable<string> {
    return this.http.post(this.addProUrl, Product, { responseType: 'text' });
  }
  getAllProducts(): Observable<Products[]> {
    return this.http.get<Products[]>(this.getProsUrl);
  }
  updateProducts(id: string, product: Partial<Products>): Observable<string> {
    return this.http.put(`${this.updateProUrl}/${id}`, product, { responseType: 'text' });
  }
  getProductById(id: any): Observable<Products> {
    return this.http.get<Products>(`${this.updateProUrl}/${id}`)
  }
  deleteProduct(productId: string) {
    return this.http.delete(`${this.deleteprodUrl}/${productId}`, { responseType: 'text' });
  }
}
