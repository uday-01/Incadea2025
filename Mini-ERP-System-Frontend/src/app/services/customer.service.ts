import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { CUstomers } from '../Models/Customers';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private addCusturl = "https://localhost:7213/api/customer"
  private getCustomersurl = "https://localhost:7213/api/customers"
  private updatecustUrl = "https://localhost:7213/api/customer";
  private deleteCustUrl = "https://localhost:7213/api/customer";
  constructor(private http: HttpClient, private authservice: AuthService) { }
  addCustomer(cust: CUstomers): Observable<string> {
    return this.http.post(this.addCusturl, cust, { responseType: 'text' });
  }
  getAllCustomers(): Observable<CUstomers[]> {
    return this.http.get<CUstomers[]>(this.getCustomersurl);
  }
  updateCustomer(id: string, cust: Partial<CUstomers>): Observable<string> {
    return this.http.put(`${this.updatecustUrl}/${id}`, cust, { responseType: 'text' });
  }
  getCustomerById(id: any): Observable<CUstomers> {
    return this.http.get<CUstomers>(`${this.updatecustUrl}/${id}`)
  }
  deleteCustomer(custId: string) {
    return this.http.delete(`${this.deleteCustUrl}/${custId}`, { responseType: 'text' });
  }
}
