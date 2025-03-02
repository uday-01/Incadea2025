import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { Users } from '../Models/Users';
import { Observable } from 'rxjs';

interface UserData {
  userId: number;
  userName: string;
  password: string;
  role: string;
}
@Injectable({
  providedIn: 'root'
})
export class UserService {
  private adduserUrl = "https://localhost:7213/api/user";
  private getUsersUrl = "https://localhost:7213/api/users";
  private updateUserUrl = "https://localhost:7213/api/user";
  private getUserUrl = "https://localhost:7213/api/user";
  private deleteUrl = "https://localhost:7213/api/user";
  constructor(private http: HttpClient, private authservice: AuthService) {
  }
  addUser(user: Users): Observable<Users> {
    return this.http.post<Users>(this.adduserUrl, user)
  }
  getAllUsers(): Observable<UserData[]> {
    return this.http.get<UserData[]>(this.getUsersUrl);
  }
  updateUser(id: string, user: Partial<UserData>): Observable<string> {
    return this.http.put(`${this.updateUserUrl}/${id}`, user, { responseType: 'text' });
  }
  getUserById(id: string): Observable<UserData> {
    return this.http.get<UserData>(`${this.getUserUrl}/${id}`)
  }
  deleteUser(userId: number) {
    return this.http.delete(`${this.deleteUrl}/${userId}`, { responseType: 'text' });
  }


}
