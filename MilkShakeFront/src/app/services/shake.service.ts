import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Topping } from '../models/topping.model';
import { Flavor } from '../models/flavor.model';
import { Consistency } from '../models/consistency.model';

@Injectable({
  providedIn: 'root'
})
export class ShakeService {
  private apiUrl = `${environment.apiEndpoint}`
  constructor(private http: HttpClient) { }

  getConsistencies(): Observable<Consistency[]> {
    return this.http.get<Consistency[]>(`${this.apiUrl}/consistency`);
  }

  getFlavors(): Observable<Flavor[]> {
    return this.http.get<Flavor[]>(`${this.apiUrl}/flavor`);
  }

  getToppings(): Observable<Topping[]> {
    return this.http.get<Topping[]>(`${this.apiUrl}/topping`);
  }
}