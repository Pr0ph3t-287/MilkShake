export interface OrderItem {
  order_item_id?: number;
  order_id: number;
  description: string;
  quantity: number;
  price: number;
  created_at?: Date;
  updated_at?: Date;
}