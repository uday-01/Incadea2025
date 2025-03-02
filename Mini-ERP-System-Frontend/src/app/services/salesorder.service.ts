import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { SalesOrder } from '../Models/salesOrder';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SalesorderService {
  private addSalesOrderurl = "https://localhost:7213/api/salesorder"
  private GetAllSalesOrderUrl = "https://localhost:7213/api/salesorders"
  constructor(private http: HttpClient, private authservice: AuthService) { }
  addSales(salesorder: SalesOrder): Observable<string> {
    return this.http.post(this.addSalesOrderurl, salesorder, { responseType: 'text' });
  }
  getAllSalesOrders(): Observable<SalesOrder[]> {
    return this.http.get<SalesOrder[]>(this.GetAllSalesOrderUrl);
  }
}
