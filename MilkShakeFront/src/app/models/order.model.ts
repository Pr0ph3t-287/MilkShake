export interface Order {
  order_id?: number;
  user_id: number;
  order_date: Date;
  total_amount: number;
  created_at?: Date;
  updated_at?: Date;
}