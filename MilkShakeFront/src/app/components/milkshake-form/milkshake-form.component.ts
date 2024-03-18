import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Consistency } from 'src/app/models/consistency.model';
import { Flavor } from 'src/app/models/flavor.model';
import { Topping } from 'src/app/models/topping.model';
import { ShakeService } from 'src/app/services/shake.service';

@Component({
  selector: 'app-milkshake-form',
  templateUrl: './milkshake-form.component.html',
  styleUrls: ['./milkshake-form.component.css']
})
export class MilkshakeFormComponent {
  @Input() consistencies!: Array<Consistency>;
  @Input() flavors!: Array<Flavor>;
  @Input() toppings!: Array<Topping>;

  shakeForm: FormGroup;

  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private shakeService: ShakeService,
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.shakeForm = this.formBuilder.group({
          consistency: [[]],
          flavor: [[]],
          toppings: [[]], // Define toppings control as an array
        });        
    }

    addMilkshake(): void {

    }
}
