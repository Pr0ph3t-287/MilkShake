import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from "@angular/common/http";
import { environment } from 'src/environments/environment';
import { Topping } from '../models/topping.model';
import { Flavor } from '../models/flavor.model';
import { Consistency } from '../models/consistency.model';
import { Order } from '../models/order.model';
import { OrderItem } from '../models/order-item.model';
import { MilkshakeConfig } from '../models/config.model';

@Injectable({
  providedIn: 'root'
})
export class ShakeService {
  private apiUrl = `${environment.apiEndpoint}`
  constructor(private http: HttpClient) { }

  getConfig(): Observable<MilkshakeConfig> {
    return this.http.get<MilkshakeConfig>(`${this.apiUrl}/config/1`);
  }

  getConsistencies(): Observable<Consistency[]> {
    return this.http.get<Consistency[]>(`${this.apiUrl}/consistency`);
  }

  getFlavors(): Observable<Flavor[]> {
    return this.http.get<Flavor[]>(`${this.apiUrl}/flavor`);
  }

  getToppings(): Observable<Topping[]> {
    return this.http.get<Topping[]>(`${this.apiUrl}/topping`);
  }

  postOrder(order: Order): Observable<Order> {
    const body = order;
    return this.http.post<Order>(`${this.apiUrl}/order`, body);
  }

  postOrderItems(orderItems: Array<OrderItem>): Observable<Array<OrderItem>> {
    const body = orderItems;
    return this.http.post<Array<OrderItem>>(`${this.apiUrl}/OrderItem/CreateOrderItems`, body);
  }

  getOrderByUserId(userId: number): Observable<Array<Order>> {
    return this.http.get<Array<Order>>(`${this.apiUrl}/Order/UserId?userId=${userId}`);
  }
}