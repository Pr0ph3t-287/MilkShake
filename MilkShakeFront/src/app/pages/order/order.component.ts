import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Consistency } from 'src/app/models/consistency.model';
import { Flavor } from 'src/app/models/flavor.model';
import { OrderItem } from 'src/app/models/order-item.model';
import { Order } from 'src/app/models/order.model';
import { Topping } from 'src/app/models/topping.model';
import { ShakeService } from 'src/app/services/shake.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  orderForm: FormGroup;
  paymentForm: FormGroup;
  
  consistencies: Array<Consistency> = [];
  flavors: Array<Flavor> = [];
  toppings: Array<Topping> = [];
  shakes: Array<OrderItem> = [];
  locations: Array<string> = ['Rivonia', 'Woodmead', 'Waterfront', 'Waterkloof'];
  complete: boolean = false;
  order: Order = {} as Order;
  
  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private shakeService: ShakeService,
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.orderForm = this.formBuilder.group({
          location: ['', Validators.required],
          time: ['', Validators.required],
          amount: [0, [Validators.required, Validators.max(10), Validators.min(1)]],
        });

        this.paymentForm = this.formBuilder.group({
          discount: [''],
          totalAmount: [''],
        });
    }


  ngOnInit(): void {
    this.shakeService.getConsistencies().subscribe(
      (response) => {
        console.log('Response:', response);
        this.consistencies = response;
      },
      (error) => {
        console.error('Error:', error);
      });

      this.shakeService.getFlavors().subscribe(
        (response) => {
          console.log('Response:', response);
          this.flavors = response;
        },
        (error) => {
          console.error('Error:', error);
        });

        this.shakeService.getToppings().subscribe(
          (response) => {
            console.log('Response:', response);
            this.toppings = response;
          },
          (error) => {
            console.error('Error:', error);
          });
  }

  createOrder(): void {
    let amount = this.orderForm.get('amount')?.value;

    if (amount > this.shakes.length) {
      while (amount > this.shakes.length) {
        const item: OrderItem = {} as OrderItem;
        this.shakes.push(item);
      }
    } else if (amount < this.shakes.length) {
      while (amount < this.shakes.length) {
        this.shakes.pop();
      }
    }

    this.calculateTotal();
  }

  calculateTotal(): void {
    let total = 0;
    this.shakes.forEach(shake =>{
      if (shake.quantity === 1) {
        total += shake.price;
        this.complete = true;
      } else {
        this.complete = false;
      }
    });

    const discount = this.calculateDiscount(total); 

    this.paymentForm.get('discount')?.setValue(discount);

    this.paymentForm.get('totalAmount')?.setValue(total - discount);
  }

  calculateDiscount(total: number): number {
    if (this.shakes.length > 2 /* && orders for userID > 2 */) {
      // 10% off
      total *= .1;
    } else if (this.shakes.length > 4 /* && orders for userID > 4 */) {
      // 20% off
      total *= .2;
    } else if (this.shakes.length > 6 /* && orders for userID > 6 */) {
      // 30% off
      total *= .3;
    } else {
      total *= .0;
    }

    return total;
  }

  placeOrder(): void {
    this.order.totalAmount = this.paymentForm.get('totalAmount')?.value;
    this.order.userId = 1; // FIX THIS
    this.order.orderDate = new Date(Date.now());
    this.order.created_At = new Date(Date.now());
    this.order.updated_At = new Date(Date.now());

    this.shakeService.postOrder(this.order).subscribe(
      (response) => {
        console.log('Response:', response);
        this.order = response;

        this.shakes.forEach(shake => {
          shake.orderId = this.order.orderId ?? 0;
          shake.createdAt = new Date(Date.now());
          shake.updatedAt = new Date(Date.now());
        });

        this.shakeService.postOrderItems(this.shakes).subscribe(
          (response) => {
            console.log('Response:', response);
          },
          (error) => {
            console.error('Error:', error);
          });
      },
      (error) => {
        console.error('Error:', error);
      });
  }
}
