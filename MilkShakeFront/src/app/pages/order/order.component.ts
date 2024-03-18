import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Consistency } from 'src/app/models/consistency.model';
import { Flavor } from 'src/app/models/flavor.model';
import { Topping } from 'src/app/models/topping.model';
import { ShakeService } from 'src/app/services/shake.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  loginForm: FormGroup;
  currentYear: number = Date.now();
  consistencies: Array<Consistency> = [];
  flavors: Array<Flavor> = [];
  toppings: Array<Topping> = [];
  shakes: Array<string> = [];

  constructor( 
    private formBuilder: FormBuilder,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private shakeService: ShakeService,
    ) {       
        // Initialize the FormGroup with form controls and validation
        this.loginForm = this.formBuilder.group({
          email: ['', Validators.required],
          password: ['', Validators.required],
          consistency: [[]],
          flavor: [[]],
          toppings: [[]], // Define toppings control as an array
          
        });

        for (let i = 0; i < 10; i++) {
          this.shakes.push("milkshake");
        }
        
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


  login(): void {

  }
}
