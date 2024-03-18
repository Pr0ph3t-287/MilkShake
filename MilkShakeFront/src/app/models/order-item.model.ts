export interface OrderItem {
  orderItemId?: number;
  orderId: number;
  description: string;
  quantity: number;
  price: number;
  createdAt?: Date;
  updatedAt?: Date;
}