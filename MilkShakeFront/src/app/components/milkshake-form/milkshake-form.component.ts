import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Consistency } from 'src/app/models/consistency.model';
import { Flavor } from 'src/app/models/flavor.model';
import { OrderItem } from 'src/app/models/order-item.model';
import { Topping } from 'src/app/models/topping.model';
import { ShakeService } from 'src/app/services/shake.service';

@Component({
  selector: 'app-milkshake-form',
  templateUrl: './milkshake-form.component.html',
  styleUrls: ['./milkshake-form.component.scss']
})
export class MilkshakeFormComponent {
  @Input() consistencies!: Array<Consistency>;
  @Input() flavors!: Array<Flavor>;
  @Input() toppings!: Array<Topping>;
  @Input() shake!: OrderItem;
  @Output() shakeChange = new EventEmitter<OrderItem>();
  @Input() calculateTotal!: () => void;

  shakeForm: FormGroup;

  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private shakeService: ShakeService,
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.shakeForm = this.formBuilder.group({
          consistency: [[], Validators.required],
          flavor: [[], Validators.required],
          toppings: [[], Validators.required],
          price: [''],
        });

      this.shakeForm.get('flavor')?.valueChanges.subscribe(() => this.calculatePrice());
      this.shakeForm.get('consistency')?.valueChanges.subscribe(() => this.calculatePrice());
      this.shakeForm.get('toppings')?.valueChanges.subscribe(() => this.calculatePrice());

      // this.shakeForm.valueChanges.subscribe(() => this.shakeChange.emit(this.shake));
    }

    calculatePrice() {
      // Get the values of the selected options
      const flavor = this.shakeForm.get('flavor')?.value;
      const consistency = this.shakeForm.get('consistency')?.value;
      const toppings = this.shakeForm.get('toppings')?.value;
  
      const flavorPrice = this.flavors?.find(obj => obj['name'] === flavor)?.price ?? 0;
      const consistencyPrice = this.consistencies?.find(obj => obj['name'] === consistency)?.price ?? 0;
      const toppingsPrice = this.toppings?.find(obj => obj['name'] === toppings)?.price ?? 0;

      let totalPrice = flavorPrice + consistencyPrice + toppingsPrice;
      totalPrice += 40;
  
      this.shakeForm.get('price')?.setValue(totalPrice);

      this.shake.price = totalPrice;
      this.shake.description = `${consistency} ${flavor} with ${toppings}`;
      
      // this.shakeChange.emit(this.shake);
    }

    addMilkshake(): void {
      this.shake.quantity = 1;
      this.shakeChange.emit(this.shake);
      this.calculateTotal();
    }
}
