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

  login(username: string, password: string): Observable<any> {
    const body = {
      username: username,
      password: password
    };
    return this.http.get<any>(`${this.apiUrl}`);
  }

  register(user: User): Observable<any> {
    const body = user;
    return this.http.post<any>(`${this.apiUrl}`, body);
  }
}
