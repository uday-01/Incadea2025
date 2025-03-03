import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { PurchaseOrder } from '../Models/PurchaseOrder';
import { Observable } from 'rxjs';
import { Quantity } from '../Models/Quantity';

@Injectable({
  providedIn: 'root'
})
export class PurchaseorderService {

  private addPurchaseUrl = "https://localhost:7213/api/purchaseorder"
  private GetAllPurchaseOrderUrl = "https://localhost:7213/api/purchaseorders"
  constructor(private http: HttpClient, private authservice: AuthService) { }
  addpurchase(purchaseOrder: PurchaseOrder): Observable<string> {
    return this.http.post(this.addPurchaseUrl, purchaseOrder, { responseType: 'text' });
  }
  getAllPurchaseOrders(): Observable<PurchaseOrder[]> {
    return this.http.get<PurchaseOrder[]>(this.GetAllPurchaseOrderUrl);
  }

}
