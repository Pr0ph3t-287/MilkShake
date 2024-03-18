export interface Order {
  orderId?: number;
  userId: number;
  orderDate: Date;
  totalAmount: number;
  created_At?: Date;
  updated_At?: Date;
}