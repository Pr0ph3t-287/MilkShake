import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = `${environment.apiEndpoint}/user`;

  constructor(private http: HttpClient) { }

  login(email: string, password: string): Observable<any> {
    const body = {
      email: email,
      password: password
    };
    return this.http.post<any>(`${this.apiUrl}/login`, body);
  }

  register(user: User): Observable<any> {
    const body = user;
    return this.http.post<any>(`${this.apiUrl}`, body);
  }
}
